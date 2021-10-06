using System;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public class DataTotal
    {
        public string VOUCHER { get; set; }
        public string PERSONAL { get; set; }
        public string PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal TOTAL { get; set; }
        public decimal TOTAL_DESCUENTO { get; set; }
        public decimal TOTAL_IMPORTE { get; set; }
        public DateTime FECH_VENTA { get; set; }
    }
}
