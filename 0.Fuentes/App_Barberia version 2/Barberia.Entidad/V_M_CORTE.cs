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
    
    public partial class V_M_CORTE
    {
        public int ID_CORTE { get; set; }
        public string VOUCHER { get; set; }
        public string PERSONAL { get; set; }
        public string CLIENTE { get; set; }
        public Nullable<decimal> TOTAL_IMPORTE { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public Nullable<decimal> DESCT_TOTAL { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public string EFECTIVO { get; set; }
        public string VUELTO { get; set; }
        public Nullable<System.DateTime> FEC_CORTE { get; set; }
        public string USUARIO { get; set; }
    }
}
