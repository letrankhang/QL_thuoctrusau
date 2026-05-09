using System;
using System.IO;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public static class Logger
    {
        private static readonly string LogPath = Path.Combine(Application.StartupPath, "logs");

        static Logger()
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
        }

        public static void Log(Exception ex, string context = "")
        {
            try
            {
                string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
                string filePath = Path.Combine(LogPath, fileName);
                
                string logContent = $"[{DateTime.Now:HH:mm:ss}] [CONTEXT: {context}]\n" +
                                   $"Message: {ex.Message}\n" +
                                   $"StackTrace: {ex.StackTrace}\n" +
                                   $"------------------------------------------------------\n";

                File.AppendAllText(filePath, logContent);
            }
            catch
            {
                // Không thể log thì thôi, tránh gây crash thêm
            }
        }

        public static void Log(string message, string context = "")
        {
            LogContent("[INFO]", message, context);
        }

        public static void LogError(string message, string context = "")
        {
            LogContent("[ERROR]", message, context);
        }

        public static void LogInfo(string message, string context = "")
        {
            LogContent("[INFO]", message, context);
        }

        private static void LogContent(string level, string message, string context)
        {
            try
            {
                string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
                string filePath = Path.Combine(LogPath, fileName);

                string logContent = $"[{DateTime.Now:HH:mm:ss}] {level} [CONTEXT: {context}] {message}\n" +
                                   $"------------------------------------------------------\n";

                File.AppendAllText(filePath, logContent);
            }
            catch { }
        }
    }
}
