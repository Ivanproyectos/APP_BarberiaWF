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
    
    public partial class T_ANULAR_VENTA
    {
        public int ID_ANULAR { get; set; }
        public string DESC_ANULAR { get; set; }
        public string VOUCHER { get; set; }
        public string PERSONAL { get; set; }
        public string CLIENTE { get; set; }
        public Nullable<decimal> SUBTOTAL { get; set; }
        public Nullable<decimal> DESC_TOTAL { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<System.DateTime> FEC_OPERACION { get; set; }
        public Nullable<System.DateTime> FEC_ANULAR { get; set; }
        public string USER_OPERACION { get; set; }
        public string USER_ANULAR { get; set; }
    }
}
