using System;
using System.Runtime.InteropServices;
using NLog;

namespace VetisLog.Checker
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SwHide = 0;

        //const int SwShow = 5;


        public static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);

            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var vetisLog = new VetisLog();
                vetisLog.Ping();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            Console.WriteLine("Ok");
        }
    }
}
