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
    
    public partial class T_M_SERIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_SERIE()
        {
            this.T_M_COMPROBANTE_SUNAT = new HashSet<T_M_COMPROBANTE_SUNAT>();
        }
    
        public int ID_SERIE { get; set; }
        public Nullable<int> ID_EMPRESA { get; set; }
        public Nullable<int> ID_TIPO_COMPROBANTE { get; set; }
        public string SERIE { get; set; }
        public Nullable<int> CORRELATIVO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_M_COMPROBANTE_SUNAT> T_M_COMPROBANTE_SUNAT { get; set; }
    }
}
