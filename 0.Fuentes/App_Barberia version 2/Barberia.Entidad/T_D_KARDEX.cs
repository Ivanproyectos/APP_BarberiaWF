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
    
    public partial class T_D_KARDEX
    {
        public int ID_DETALLE { get; set; }
        public Nullable<int> ID_TIPO_COMPROBANTE { get; set; }
        public Nullable<int> ID_KARDEX { get; set; }
        public Nullable<System.DateTime> FEC_DETALLE_KARDEX { get; set; }
        public string NUM_DOCUMENTO { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<decimal> PRECIO_SOLES { get; set; }
        public Nullable<decimal> PRECIO_DOLAR { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public string TIPO_TRANSACCION { get; set; }
        public Nullable<decimal> CANTIDAD_SALDO { get; set; }
        public Nullable<decimal> PRECIO_SALDO { get; set; }
        public Nullable<decimal> TOTAL_SALDO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        public virtual T_M_KARDEX T_M_KARDEX { get; set; }
        public virtual T_TIPO_COMPROBANTE T_TIPO_COMPROBANTE { get; set; }
    }
}
