using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barberia.Presentacion.Frm_Principal;
using Barberia.Presentacion.Frm_loggins;

namespace Barberia.Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Frm_Inicio("ADMIN"));
            Application.Run(new Frm_Loggin());
        }
    }
}
