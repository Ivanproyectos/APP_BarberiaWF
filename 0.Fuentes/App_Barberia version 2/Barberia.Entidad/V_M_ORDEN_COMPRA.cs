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
    
    public partial class V_M_ORDEN_COMPRA
    {
        public int ID_ORDEN_COMPRA { get; set; }
        public int ID_EMPRESA { get; set; }
        public string EMPRESA_EXTERNA { get; set; }
        public string NUM_COTIZACION_REF { get; set; }
        public string NUM_ORDEN_COMPRA { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string NOMBRES { get; set; }
        public string ASUNTO { get; set; }
        public string FORMA_PAGO { get; set; }
        public string GARANTIA { get; set; }
        public Nullable<int> CANT_DIAS_VALIDES { get; set; }
        public Nullable<decimal> SUBTOTAL { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public Nullable<decimal> DESCUENTO { get; set; }
        public Nullable<decimal> TOTAL { get; set; }

        public string DIRECCION_EXTERNO { get; set; }
        public string NUMDOC_EXTERNO { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    }
}