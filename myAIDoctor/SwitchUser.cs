using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace myAIDoctor
{
    public partial class SwitchUser : Form
    {
        public SwitchUser()
        {
            InitializeComponent();
        }

        private void SwitchUser_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - 36;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - 40;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void confirm_Click(object sender, EventArgs e)
        {
            // 清空账号
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["loginInfo"] != null)
            {
                config.AppSettings.Settings["loginInfo"].Value = "";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            this.Close();

            //关闭临听
            if (Notify.hs != null)
            {
                Notify.hs.Stop();
            }

            //关闭弹窗
            if (Notify.notify != null)
            {
                Notify.notify.Close();
            }
            //返回登录窗口
            if (Login.login != null)
            {
                Login.login.Show();
            }
        }

        
    }
}
