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
    
    public partial class T_M_VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_VENTA()
        {
            this.T_D_DOCUMENTOS_VENTAS = new HashSet<T_D_DOCUMENTOS_VENTAS>();
            this.T_D_VENTA = new HashSet<T_D_VENTA>();
        }
    
        public int ID_VENTA { get; set; }
        public int ID_EMPRESA { get; set; }
        public int ID_CLIENTE { get; set; }
        public string VOUCHER { get; set; }
        public Nullable<decimal> TOTAL_IMPORTE { get; set; }
        public Nullable<decimal> DESCT_TOTAL { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public string EFECTIVO { get; set; }
        public string VUELTO { get; set; }
        public Nullable<decimal> IGV_ANIO_ACTUAL { get; set; }
        public string USUARIO { get; set; }
        public string FLG_ESTADO { get; set; }
        public Nullable<System.DateTime> FEC_VENTA { get; set; }
        public string FEC_ENVIO { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_D_DOCUMENTOS_VENTAS> T_D_DOCUMENTOS_VENTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_D_VENTA> T_D_VENTA { get; set; }
        public virtual T_M_CLIENTES T_M_CLIENTES { get; set; }
    }
}