namespace Barberia.Entidad
{
    public class Cls_Ent_V_Producto
    {
        public int ID_EMPRESA { get; set; }
        public string DESC_CATEGORIA { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string COD_PRODUCTO { get; set; }
        public string DES_ALMACEN { get; set; }
        public string DES_CLASE { get; set; }
        public string PRODUCTO { get; set; }
        public string DES_UNIDAD_MEDIDA { get; set; }
        public string DES_MODELO { get; set; }
        public string DES_MARCA { get; set; }
        public int STOCK { get; set; }
        public decimal PRECIO_COMPRA { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public string FEC_COMPRA { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public string FEC_MODIFICA { get; set; }
        public int ANIO { get; set; }
        public int MES { get; set; }
    }
}
