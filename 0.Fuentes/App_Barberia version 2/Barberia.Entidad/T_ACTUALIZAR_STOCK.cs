//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Barberia.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_ACTUALIZAR_STOCK
    {
        public int ID_ACTUALIZAR { get; set; }
        public int ID_EMPRESA { get; set; }
        public string FACTURA { get; set; }
        public string GUIA { get; set; }
        public string NRO_BOLETA { get; set; }
        public string PRODUCTO { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public string UND_MEDIDA { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<decimal> PRE_COMPRA { get; set; }
        public Nullable<decimal> PRE_VENTA_UND { get; set; }
        public Nullable<System.DateTime> FEC_OPERACION { get; set; }
        public string USER_OPERACION { get; set; }
        public string FLG_ESTADO { get; set; }
        public string ALMACEN { get; set; }
        public string CLASE { get; set; }
    }
}
