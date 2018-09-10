using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using CefSharp;
using CefSharp.WinForms;
using aiDoctor.webHandler;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;

namespace myAIDoctor
{
    public partial class Login : Form
    {
        public static Login login;
        ChromiumWebBrowser web;
        int port = Int16.Parse(ConfigurationManager.AppSettings["monitorPort"]);
        public Login()
        {
            InitializeComponent();

            try {
                InitializeWebBroser();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return;
            }
            this.Icon = (Icon)(myAIDoctor.Properties.Resources.aiDoctor);//获取图标
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeWebBroser() {
            var settings = new CefSettings
            {
                Locale = "zh_cn",
                AcceptLanguageList = "zh_cn",
                MultiThreadedMessageLoop = true
            };
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            string url = ConfigurationManager.AppSettings["url"];
            web = new ChromiumWebBrowser(url+"/#/login");
            //web = new ChromiumWebBrowser(Environment.CurrentDirectory+"/test.html");
            web.Dock = DockStyle.Fill;
            web.MenuHandler = new MenuHandler();
            web.DragHandler = new DragHandler();
            web.RegisterJsObject("JsEvent", this, new BindingOptions { CamelCaseJavascriptNames = false });
            this.Controls.Add(web);
        }

        private bool PortListen(int port)
        {
            bool inUse = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }


        public string AutoLoginInfo()
        {
            string info = String.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["loginInfo"] != null)
                {
                    info = config.AppSettings.Settings["loginInfo"].Value;
                }
            return info;
        }

        public bool SaveLoginInfo(string userName, string password, int isAutoLogin)
        {
            try
            {
                string loginInfo = userName + "|" + password + "|" + isAutoLogin;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["loginInfo"] != null)
                {
                    config.AppSettings.Settings["loginInfo"].Value = loginInfo;
                }
                else
                {
                    config.AppSettings.Settings.Add("loginInfo", loginInfo);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        //页面JS调用
        public void LoginSuccess()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (PortListen(port))
                {
                    DialogResult dr = MessageBox.Show("监听端口：" + port + "已被占用，请项目实施人员更改后方能使用。");
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }

                }
                ShowNotifyForm();
            }));
           
        }

        //页面JS调用
        public void CloseApp()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    this.Close();
                    Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }));
        }

        // 打开窗口（右下解弹窗）
       // Notify notify;
        private void ShowNotifyForm()
        {
            try
            {
                Notify notify = new Notify();
                notify.ShowInTaskbar = false;
                notify.Show();
                this.Hide();
                login = this;
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

    }
}
