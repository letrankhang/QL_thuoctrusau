using QL_CuaHangBanThuocTruSau.Views;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main () {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new Frm_DANGNHAP ());
        }
    }
}
