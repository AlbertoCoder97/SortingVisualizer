using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    static class Program
    {

        public static Form1 main;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Need to get the instance of the form so I can pass it to another class
            main = new Form1();

            Application.Run(main);

        }

    }
}
