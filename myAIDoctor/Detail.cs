using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using CefSharp;
using CefSharp.WinForms;
using aiDoctor.webHandler;
namespace myAIDoctor
{
    public partial class Detail : Form
    {
        public string patientId = "";
        public string cardNum = "";
        ChromiumWebBrowser web;

        public Detail(string patientId, string cardNum)
        {
            InitializeComponent();
            InitWebBrowser();
            this.Icon = (Icon)(myAIDoctor.Properties.Resources.aiDoctor);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.patientId = patientId;
            this.cardNum = cardNum;
        }

        private void InitWebBrowser()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            //string path = Environment.CurrentDirectory + "\\WebBrowserJsTest.html";
            string url = ConfigurationManager.AppSettings["url"];
            web = new ChromiumWebBrowser(url+"/#/");
            web.Dock = DockStyle.Fill;
            web.MenuHandler = new MenuHandler();
            web.DragHandler = new DragHandler();
            web.RegisterJsObject("JsEvent", this, new BindingOptions { CamelCaseJavascriptNames = false });
            this.Controls.Add(web);
        }

        //页面JS调用
        public string GetID()
        {
            return this.patientId +"|"+ this.cardNum;
        }

        //页面JS调用
        public void CloseDetail()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                CloseAppForm();
            }));
        }

        private void CloseAppForm()
        {
            this.Close();
        }
    }
}
