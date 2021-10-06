using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public class ventaDatos
    {
        public int ID_VENTA { get; set; }
        public string VOUCHER { get; set; }
        public string PERSONAL { get; set; }
        public string PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public Nullable<decimal> IMPORTE { get; set; }
        public Nullable<decimal> DESCT_TOTAL { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<System.DateTime> FEC_VENTA { get; set; }
        public Nullable<int> ANIO { get; set; }
        public Nullable<int> MES { get; set; }
        public decimal Total_Importe { get; set; }
    }
}
