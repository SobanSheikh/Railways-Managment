using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        /// <summary>

        ///  The main entry point for the application.
        /// </summary>
        public static int current_UserID = -1;
        public static int source = -1;
        public static int destination = -1;
        public static List<int> listofSeats = new List<int>();
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());   
        }
    }
}
