using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Ventas
{
    public partial class Frm_Visor_PDF : Form
    {
        string _ruta;
        public Frm_Visor_PDF(string ruta)
        {
            InitializeComponent();
            _ruta = ruta;
        }

        private void Frm_Visor_PDF_Load(object sender, EventArgs e)
        {
            //axAcroPDF1.src = Environment.CurrentDirectory + "\\prueba.pdf";
            axAcroPDF1.src = _ruta;
        }
    }
}
