using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attaysir
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
            //Application.Run(new officermain(49));
            //Application.Run(new adding(49));
/*forAdmns*///Application.Run(new adding(1,true));
            //Application.Run(new adminmain(1));
            //Application.Run(new TheListView());
            //Application.Run(new AreYouSure());
            //Application.Run(new deneme2());
            Application.Run(new the_lists());
        }
    }
}
