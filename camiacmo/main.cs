using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;

using camiacmo.Properties;
using System.Security.Principal;

namespace camiacmo
{
    public partial class main : Form
    {
        private static NotifyIcon myNotifyIcon;
        private WmiChangeEventTester receiveEvent;
        private Dictionary<Device, HashSet<string>> currentActiveAppsPerDevice = getActiveAppsPerDevice();
        private long lastBeepTimestamp = 0;
        private int widthWithWebhooks = 0;
        private static string WindowsStartupEntryKey = "Camiacmo";
        private List<string> ballonTipMessages = new List<string>();

        private static Color colorActive = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        private static Color colorInactive = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

        public class WmiChangeEventTester
        {
            ManagementEventWatcher watcher = null;
            main mainForm;

            public WmiChangeEventTester(main mainForm)
            {
                try
                {
                    this.mainForm = mainForm;

                    WindowsIdentity identity = null;
                    identity = WindowsIdentity.GetCurrent();
                    string cameraPath = identity.User.ToString() + @"\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam";
                    string micPath = identity.User.ToString() + @"\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone";
                    string qry = String.Format("SELECT * FROM RegistryTreeChangeEvent WHERE Hive = \"HKEY_USERS\" AND (Rootpath = \"{0}\" OR Rootpath = \"{1}\")", cameraPath, micPath);
                    Console.WriteLine(qry);
                    WqlEventQuery query = new WqlEventQuery(qry);

                    watcher = new ManagementEventWatcher(query);

                    watcher.EventArrived += new EventArrivedEventHandler(HandleEvent);
                    watcher.Start();
                }
                catch (ManagementException managementException)
                {
                    Console.WriteLine("An error occurred: " + managementException.Message);
                }
            }

            public void Stop()
            {
                // Stop listening for events.
                if (watcher != null)
                    watcher.Stop();
            }

            private void HandleEvent(object sender, EventArrivedEventArgs e)
            {
                mainForm.Invoke(new Action(() =>
                {
                    mainForm.checkForChanges();
                }));
            }
        }

        private void checkForChanges()
        {
            Dictionary<Device, HashSet<string>> newState = getActiveAppsPerDevice();
            Dictionary<Device, HashSet<string>> oldState = currentActiveAppsPerDevice;
            currentActiveAppsPerDevice = newState;
            showState();

            HashSet<Device> changedDevices = new HashSet<Device>();
            foreach (Device device in Enum.GetValues(typeof(Device)))
            {
                List<string> newApps = newState[device].Where(x => !oldState[device].Contains(x)).ToList();
                List<string> oldApps = oldState[device].Where(x => !newState[device].Contains(x)).ToList();
                string deviceName = GetDeviceString(device);

                if (newApps.Count() > 0 || oldApps.Count() > 0)
                {
                    changedDevices.Add(device);
                    if (newState[device].Count() == 0)
                    {
                        ballonTipMessages.Add(deviceName + " deactivated");
                    } else
                    {
                        newApps.ForEach(x => ballonTipMessages.Add(deviceName + " used by " + x));
                        oldApps.ForEach(x => ballonTipMessages.Add(deviceName + " released by " + x));
                    }
                }
            }

            if (changedDevices.Any() && checkBoxBeep.Checked)
            {
                beep();
            }

            if (ballonTipMessages.Any())
            {
                Task.Run(async delegate
                {
                    await Task.Delay(500);
                    this.Invoke(new Action(() =>
                    {
                        this.showBallonTip();
                    }));
                });
            }
        }

        private void beep()
        {
            long now = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
            if (now - lastBeepTimestamp > 1000)
            {
                if (checkBoxBeep.Checked)
                {
                    Console.Beep();
                }
                lastBeepTimestamp = now;
            }
        }

        private void showState()
        {
            bool webcamActive = currentActiveAppsPerDevice[Device.Webcam].Count > 0;
            bool micActive = currentActiveAppsPerDevice[Device.Microphone].Count > 0;
            SetLabelState(lblCamActive, webcamActive);
            SetLabelState(lblMicActive, micActive);
            myNotifyIcon.Text = "Webcam " + (webcamActive ? "ON" : "OFF") + " - Mic " + (micActive ? "ON" : "OFF");
            if (webcamActive)
            {
                if (micActive)
                {
                    myNotifyIcon.Icon = Resources.icon_on_on;
                    Icon = Resources.icon_with_text_on_on;
                }
                else
                {
                    myNotifyIcon.Icon = Resources.icon_on_off;
                    Icon = Resources.icon_with_text_on_off;
                }
            }
            else
            {
                if (micActive)
                {
                    myNotifyIcon.Icon = Resources.icon_off_on;
                    Icon = Resources.icon_with_text_off_on;
                }
                else
                {
                    myNotifyIcon.Icon = Resources.icon_off_off;
                    Icon = Resources.icon_with_text_off_off;
                }
            }
        }

        private void showBallonTip()
        {
            if (ballonTipMessages.Any())
            {
                if (myNotifyIcon != null && checkBoxNotification.Checked)
                    myNotifyIcon.ShowBalloonTip(2000, "Camiacmo", String.Join("\n", ballonTipMessages), ToolTipIcon.Warning);
                ballonTipMessages.Clear();
            }
        }

        private static void SetLabelState(Label label, bool active)
        {
            label.Text = active ? "Active" : "Inactive";
            label.ForeColor = active ? colorActive : colorInactive;
        }

        private static Dictionary<Device, HashSet<string>> getActiveAppsPerDevice()
        {
            return Enum.GetValues(typeof(Device)).Cast<Device>()
                .ToDictionary(x => x, x => GetActivePrograms(x));
        }

        private static bool IsCurrentlyAccessing(RegistryKey appPathKey)
        {
            return appPathKey.GetValueNames()
                .Where(x => x.ToLower() == "LastUsedTimeStop".ToLower())
                .Select(x => (long)appPathKey.GetValue(x))
                .Any(x => x == 0);
        }

        private static HashSet<string> GetActivePrograms(Device device)
        {
            HashSet<string> result = new HashSet<string>();

            RegistryKey searchPath = Registry.CurrentUser
                .OpenSubKey("SOFTWARE")
                .OpenSubKey("Microsoft")
                .OpenSubKey("Windows")
                .OpenSubKey("CurrentVersion")
                .OpenSubKey("CapabilityAccessManager")
                .OpenSubKey("ConsentStore")
                .OpenSubKey(GetDeviceString(device));

            foreach (string key in searchPath.GetSubKeyNames().Where(x => x != "NonPackaged"))
            {
                try
                {
                    if (IsCurrentlyAccessing(searchPath.OpenSubKey(key)))
                    {
                        result.Add(key.Split('_')[0]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            searchPath = searchPath.OpenSubKey("NonPackaged");
            foreach (string key in searchPath.GetSubKeyNames())
            {
                try
                {
                    if (IsCurrentlyAccessing(searchPath.OpenSubKey(key)))
                    {
                        result.Add(key.Split('#').Last());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return result;
        }

        public main()
        {
            InitializeComponent();
            widthWithWebhooks = this.ClientSize.Width;
        }

        private void main_Load(object sender, EventArgs e)
        {
            receiveEvent = new WmiChangeEventTester(this);

            myNotifyIcon = new NotifyIcon();

            myNotifyIcon.Text = "";
            myNotifyIcon.Visible = true;

            myNotifyIcon.DoubleClick += MyNotifyIcon_DoubleClick;

            checkBoxBeep.Checked = Settings.Default.beep;
            checkBoxNotification.Checked = Settings.Default.notification;
            checkBoxWebhooks.Checked = Settings.Default.webhooks;

            showState();
        }

        private void RunOnStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chkStartup.Checked)
            {
                regKey.SetValue(WindowsStartupEntryKey, Application.ExecutablePath);
            }
            else
            {
                regKey.DeleteValue(WindowsStartupEntryKey, false);
            }
        }

        private bool CheckIfRunningInStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (regKey.GetValue(WindowsStartupEntryKey) != null)
            {
                chkStartup.Checked = true;
                return true;
            }
            return false;
        }

        private void MyNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //Hide();
            }
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            RunOnStartup();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            if (CheckIfRunningInStartup())
            {
                Hide();
            }
        }

        private void checkBoxBeep_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.beep = checkBoxBeep.Checked;
            Settings.Default.Save();
        }

        private void checkBoxNotification_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.notification = checkBoxNotification.Checked;
            Settings.Default.Save();
        }

        private void checkBoxWebhooks_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.webhooks = checkBoxWebhooks.Checked;
            Settings.Default.Save();
            this.ClientSize = new Size(checkBoxWebhooks.Checked ? widthWithWebhooks : 255, this.ClientSize.Height);
        }

        private enum Device
        {
            Webcam,
            Microphone
        }

        private static string GetDeviceString(Device device)
        {
            if (device == Device.Webcam)
                return "webcam";
            if (device == Device.Microphone)
                return "microphone";
            throw new System.ArgumentException("unknown device", "device");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            base.OnFormClosing(e);
        }
    }
}
