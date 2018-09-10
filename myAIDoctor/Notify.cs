using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using aiDoctor;
using aiDoctor.httpServer;
using CefSharp;
using CefSharp.WinForms;
using aiDoctor.webHandler;
using Microsoft.Win32;
using System.Diagnostics;
namespace myAIDoctor
{
    public partial class Notify : Form
    {
        public static Notify notify;
        NotifyIconAnimator trayAnimator;
        ChromiumWebBrowser web;
        public Notify() {
            InitializeComponent();
            InitializeWebBroser();
            this.Icon = (Icon)(myAIDoctor.Properties.Resources.aiDoctor);
            notifyIcon1.Icon = (Icon)(myAIDoctor.Properties.Resources.aiShow);
            trayAnimator = new NotifyIconAnimator(notifyIcon1);
        }

        private void InitializeWebBroser()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            string url = ConfigurationManager.AppSettings["url"];
            web = new ChromiumWebBrowser(url+"/#/desktopMin");
            //web = new ChromiumWebBrowser(Environment.CurrentDirectory + "/test.html");
            web.Dock = DockStyle.Fill;
            web.BackColor = Color.White;
            web.MenuHandler = new MenuHandler();
            web.DragHandler = new DragHandler();
            web.RegisterJsObject("JsEvent", this, new BindingOptions { CamelCaseJavascriptNames = false });
            this.Controls.Add(web);
        }
       
        private void Notify_Load(object sender, EventArgs e)
        {
           
            HttpServer();
            DefaultAutoRun();
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - 10;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - 10;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            IntPtr hDeskTop = FindWindow("Notify", "Notify");
            SetParent(this.Handle, hDeskTop);
            notify = this;
        }

        //窗体显示在最上层
        [DllImport("user32 ")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32 ")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /**
         * 拖动无窗体的控件
         */
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        private void Notify_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
 
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记该标记
        private const int AW_CENTER = 0x0010;//若应用了AW_HIDE标记,则使窗口向内重叠;不然向外扩大
        private const int AW_HIDE = 0x10000;//隐蔽窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口,在应用了AW_HIDE标记后不要应用这个标记
        private const int AW_SLIDE = 0x40000;//应用滑动类型动画结果,默认为迁移转变动画类型,当应用AW_CENTER标记时,这个标记就被忽视
        private const int AW_BLEND = 0x80000;//应用淡入淡出结果


        public void Spread(int type, int height)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (type == 1)
                {
                    this.Height = height;
                }
                else
                {
                    this.Height = 250;
                }
                int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - 10;
                int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - 10;
                this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            }));
        }

        //页面JS调用
        public void NoticeHandler()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (IsAutoOpenWindow())
                {
                    AutoWindowRemind();
                }
                else
                {
                    AutoFlashRemind();
                }
            }));
        }

        //页面JS调用
        public void ShowDetail(string patientId, string cardNum)
        {
            Invoke(new MethodInvoker(delegate()
            {
                ShowDetailForm(patientId, cardNum);
            }));
        }

        //页面JS调用
        public void HideApp()
        {
            Invoke(new MethodInvoker(delegate()
            {
                try
                {
                    this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
            }));
        }

        //页面JS调用
        public void Set()
        {
            Invoke(new MethodInvoker(delegate()
            {
                SetForm();
            }));
           
        }

        //详情页
        Detail detail;
        private void ShowDetailForm(string patientId, string cardNum)
        {
            try
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                if (detail != null && !detail.IsDisposed)
                {
                    detail.Dispose();
                }
                detail = new Detail(patientId, cardNum);
                detail.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // 设置
        Setting setting;
        private void SetForm()
        {
            try
            {
                if(setting == null || setting.IsDisposed)
                {
                    setting = new Setting();
                    setting.ShowInTaskbar = false;
                    setting.Show();
                } else
                {
                    setting.Activate();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // 切换用户
        SwitchUser user;
        private void SwitchUserForm()
        {
            try
            {
                if (user == null || user.IsDisposed)
                {
                    user = new SwitchUser();
                    user.ShowInTaskbar = false;
                    user.Show();
                }
                else
                {
                    user.Activate();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        // 闪烁提醒
        private void AutoFlashRemind()
        {

            Icon[] icons = new Icon[]{ (Icon)(myAIDoctor.Properties.Resources.aiShow), (Icon)(myAIDoctor.Properties.Resources.aiHide)}; // {"aiShow.ico", "aiHide.ico" }.Select(s => new Icon(s)).ToArray();
            trayAnimator.StartAnimation(icons, 500, -1);
        }
        
        // 自动弹窗
        private void AutoWindowRemind()
        {
            this.Activate();
            this.WindowState = FormWindowState.Normal;
            this.Show();
            
        }

        // 是否自动弹窗
        private bool IsAutoOpenWindow()
        {
            String isAutoOpenWindow = ConfigurationManager.AppSettings["autoOpenWindow"];
            return Boolean.Parse(isAutoOpenWindow);
        }

        
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
                else {
                    this.Hide();
                    this.WindowState = FormWindowState.Minimized;                    
                }
                trayAnimator.StopAnimation();
            }
            else if (e.Button == MouseButtons.Right)  
            {
                myMenu.Show();
            }
            
        }

        // 切换账号
        private void MentSwitchUser_Click(object sender, EventArgs e)
        {
            SwitchUserForm();
        }

        // 退出
        private void MenuQuit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hs != null)
                {
                    hs.Stop();
                }
                this.Close();
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("退出应用异常：" + ex.Message);
            }
        }
        // 设置
        private void MenuSetting_Click(object sender, EventArgs e)
        {
            SetForm();
        }

        private static string AI_DOCTOR = "AIDoctor";
        // 首次启动应用，默认设置自动开机运行
        private void DefaultAutoRun()
        {
            string starupPath = Application.ExecutablePath;
            RegistryKey loca = Registry.CurrentUser;
            RegistryKey run = loca.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (run.GetValue(AI_DOCTOR) == null)
            {
                run.SetValue(AI_DOCTOR, starupPath);//设置开机运行
            }
        }

        public static HttpServer hs;
        private void HttpServer() {
            int port = Int16.Parse(ConfigurationManager.AppSettings["monitorPort"]);
            hs = new HttpServer(port, (req) =>
            {
                return Response(req);
            });
        }

        CompactResponse Response(CompactRequest req)
        {
            if (req.Params == null && req.Body == null) {
                return new CompactResponse()
                {
                    ContentType = "text/html",
                    Data = Encoding.UTF8.GetBytes("{\"code\":\"-1\",\"message\":\"failed\"}")
                };
            }
            string cardInfo = "";
            if (req.Params != null)
            {
                cardInfo = req.Params["info"];
            }
            else
            {
                cardInfo = req.Body;
            }
            // cardInfo = "社保卡号,身份证号";
            //string[] infoArray = HttpUtility.UrlDecode(cardInfo).Split('|');
            string[] infoArray = HttpUtility.UrlDecode(cardInfo).Split(',');
            Invoke(new MethodInvoker(delegate ()
            {
               
                if (infoArray.Length == 2)
                {
                    string cardInfoMethed = "cardInfo(\"" + infoArray[1] + "\",\"" + infoArray[0] + "\")"; //cardInfo(身份证号，社保卡号）
                    web.ExecuteScriptAsync(cardInfoMethed);       
                }
            }));

            return new CompactResponse()
            {
                ContentType = "text/html",
                Data = Encoding.UTF8.GetBytes("{\"code\":\"0000\",\"message\":\"succeed\"}")
            };
        }

       
    }

}
