using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace myAIDoctor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
            if (IsRunning())
            {
                MessageBox.Show("尊敬的用户：您好！认识医生客户端已开启，请直接使用即可。");
                return;
            }
            Application.Run(new Login());
        }


        public static bool IsRunning()
        {
            try
            {
                Process current = default(Process);
                current = System.Diagnostics.Process.GetCurrentProcess();
                Process[] processes = null;
                processes = System.Diagnostics.Process.GetProcessesByName(current.ProcessName);
                Process process = default(Process);
                foreach (Process tempLoopVar_process in processes)
                {
                    process = tempLoopVar_process;
                    if (process.Id != current.Id)
                    {
                        if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                        {
                            return true;
                        }
                    }
                }
            }
            catch {
            }
            return false;
        }
    }
}
