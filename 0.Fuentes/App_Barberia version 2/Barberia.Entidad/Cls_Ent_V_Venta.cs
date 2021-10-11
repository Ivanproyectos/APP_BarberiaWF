namespace Barberia.Entidad
{
    public class Cls_Ent_V_Venta
    {
        public int ID_VENTA { get; set; }
        public int ID_EMPRESA { get; set; }
        public string VOUCHER { get; set; }
        public string CLIENTE { get; set; }
        public decimal TOTAL_IMPORTE { get; set; }
        public decimal IGV { get; set; }
        public decimal DESCT_TOTAL { get; set; }
        public decimal TOTAL { get; set; }
        public decimal EFECTIVO { get; set; }
        public decimal VUELTO { get; set; }

        public string USUARIO { get; set; }
        public string FEC_VENTA { get; set; }
        public string CODIGO_ARCHIVO { get; set; }
        public string EXTENSION_ARCHIVO { get; set; }
    }
}
