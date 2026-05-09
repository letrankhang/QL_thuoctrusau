using QL_CuaHangBanThuocTruSau.Utils;
using QL_CuaHangBanThuocTruSau.Views;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Thiết lập xử lý lỗi toàn cục
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_DANGNHAP());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        private static void HandleException(Exception ex)
        {
            // Log lỗi
            Logger.Log(ex, "Global Exception");

            // Hiển thị thông báo thân thiện
            MessageBox.Show("Đã xảy ra lỗi hệ thống không mong muốn. Vui lòng liên hệ kỹ thuật viên.\n\nChi tiết: " + ex.Message,
                "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
