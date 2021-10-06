using System;

namespace Barberia.Entidad
{
    public class Cls_Ent_Producto
    {
        public int ID_PRODUCTO { get; set; }
        public string COD_PRODUCTO { get; set; }
        public string PRODUCTO { get; set; }
        public Nullable<int> ID_UNIDAD_MEDIDA { get; set; }
        public Nullable<int> ID_MODELO { get; set; }
        public Nullable<int> ID_MARCA { get; set; }
        public string NOM_FILE { get; set; }
        public string RUTA { get; set; }
        public Nullable<int> STOCK { get; set; }
        public Nullable<decimal> PRECIO_COMPRA { get; set; }
        public Nullable<decimal> PRECIO_VENTA { get; set; }
        public Nullable<System.DateTime> FEC_COMPRA { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    }
}
