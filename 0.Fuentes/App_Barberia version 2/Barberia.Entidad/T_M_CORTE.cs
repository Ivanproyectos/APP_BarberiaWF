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
    
    public partial class T_M_CORTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_CORTE()
        {
            this.T_D_CORTE = new HashSet<T_D_CORTE>();
        }
    
        public int ID_CORTE { get; set; }
        public int ID_EMPRESA { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_PERSONAL { get; set; }
        public string VOUCHER { get; set; }
        public Nullable<decimal> TOTAL_IMPORTE { get; set; }
        public Nullable<decimal> DESCT_TOTAL { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public string EFECTIVO { get; set; }
        public string VUELTO { get; set; }
        public string USUARIO { get; set; }
        public string FLG_ESTADO { get; set; }
        public Nullable<System.DateTime> FEC_CORTE { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_D_CORTE> T_D_CORTE { get; set; }
    }
}
