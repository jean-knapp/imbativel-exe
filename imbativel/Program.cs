using imbativel.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace imbativel
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bitmap = Resources.background;
            while (true)
            {
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "background.jpg";
                bitmap.Save(file_name);
                DisplayPicture(file_name);
                Thread.Sleep(10000);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        private static void DisplayPicture(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }
    }
}
