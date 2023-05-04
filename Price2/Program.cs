using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using AutoUpdateLib;
using System.Diagnostics;

namespace Price2
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 判断是否更新成功
            bool AutoUpdateSuccess = AutoUpdate.CheckSuccess(args);
            if (!AutoUpdateSuccess)
            {
                Process Aup = AutoUpdate.CheckRunning();
                // 判断更新程序是否在运行
                if (Aup != null)
                {
                    SwitchToThisWindow(Aup.MainWindowHandle, true);    // 激活，显示在最前
                    return;
                }
                if (!AutoUpdateSuccess)
                {
                    try
                    {
                        // ClickOnce 发布后的 xxx.application http请求路径
                        string CheckUpdatesUrl = "http://192.168.10.205:8084/Price2.application";
                        if (AutoUpdate.CheckUpdates(CheckUpdatesUrl, args))
                        {
                            return;
                        }
                    }
                    catch (AutoUpdaterFileNotExistException e)
                    {
                        MessageBox.Show(e.Message, "提示");
                    }
                }
            }



            //高DPI設定
            if (System.Environment.OSVersion.Version.Major >= 6) { SetProcessDPIAware(); }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.DialogResult == DialogResult.OK)

            {
                //線上程中開啟主窗體
                Application.Run(new frmMain());
            }

        }
    }
}
