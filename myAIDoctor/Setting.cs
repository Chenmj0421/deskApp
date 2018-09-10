using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace myAIDoctor
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Channel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static bool TRUE = true;
        private static bool FALSE = false;
        private static string AI_DOCTOR = "AIDoctor";
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (runOpen.Checked)
            {
                AutoRun(TRUE);
            } else {
                AutoRun(FALSE);
            }

            if (autoOpenWindow.Checked)
            {
                AutoOpenWinow(TRUE);
            }
            else
            {
                AutoOpenWinow(FALSE);
            }

            if (autoLogin.Checked)
            {
                AutoLogin(1);
            }
            else
            {
                AutoLogin(0);
            }
            this.Close();
        }

        private void AutoRun(bool status)
        {
            try
            {
                //获取程序执行路径..
                string starupPath = Application.ExecutablePath;

                RegistryKey loca = Registry.CurrentUser;
                RegistryKey run = loca.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                if (status)
                {
                    run.SetValue(AI_DOCTOR, starupPath);//设置开机运行
                }
                else
                {
                    run.SetValue(AI_DOCTOR, FALSE.ToString());//取消开机运行
                }
                loca.Close();
            }
            catch
            { }
        }

        private void AutoOpenWinow(bool status)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["autoOpenWindow"] != null)
            {
                config.AppSettings.Settings["autoOpenWindow"].Value = status.ToString();
            }
            else
            {
                config.AppSettings.Settings.Add("autoOpenWindow", status.ToString());
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
        }

        private void AutoLogin(int status)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["loginInfo"] != null)
            {
                string[] array = (config.AppSettings.Settings["loginInfo"].Value).Split('|');
                string newInfo = "";
                if (array.Length == 3) {
                    newInfo = array[0] +"|"+ array[1] +"|"+ status;
                    config.AppSettings.Settings["loginInfo"].Value = newInfo;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                }
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width-36;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height-40;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示

            //开机自启动
            string path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey locaChek = Registry.CurrentUser;
            RegistryKey runCheck = locaChek.CreateSubKey(path);
            if (runCheck.GetValue(AI_DOCTOR).ToString() != FALSE.ToString())
            {
                    runOpen.Checked = TRUE;
            }

            //自动弹出
            String isAutoOpenWindow = ConfigurationManager.AppSettings["autoOpenWindow"];
            if (Boolean.Parse(isAutoOpenWindow)) {
                autoOpenWindow.Checked = TRUE;
            }

            //自动登录
            String isAutoLogin = ConfigurationManager.AppSettings["loginInfo"];
            if (isAutoLogin != null)
            {
                string[] array = isAutoLogin.Split('|');
                if (array.Length == 3 && array[2] == "1" )
                {
                    autoLogin.Checked = TRUE;
                }
            }

        }

    }
}
