namespace Barberia.Entidad
{
    public class Cls_Ent_V_OrdenCompra
    {
        public int ID_ORDEN_COMPRA { get; set; }
        public int ID_EMPRESA { get; set; }
        public string EMPRESA_EXTERNA { get; set; }
        public string NUM_COTIZACION_REF { get; set; }
        public string NUM_ORDEN_COMPRA { get; set; }
        public string FECHA { get; set; }
        public string NOMBRES { get; set; }
        public string ASUNTO { get; set; }
        public string FORMA_PAGO { get; set; }
        public string GARANTIA { get; set; }
        public int CANT_DIAS_VALIDES { get; set; }
       
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public string FEC_MODIFICA { get; set; }
    }
}
