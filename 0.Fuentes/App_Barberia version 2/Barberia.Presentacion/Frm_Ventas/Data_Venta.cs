using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Presentacion.Frm_Ventas
{
    public class Data_Venta
    {
        public string NUM_VAUCHER { get; set; }
        public string PRODUCTO { get; set; }
        public string PRECIO { get; set; }
        public string CANTIDAD { get; set; }
        public Decimal IMPORTE { get; set; }
        
        public string TOTAL { get; set; }
        public string IGV { get; set; }
    }
}
