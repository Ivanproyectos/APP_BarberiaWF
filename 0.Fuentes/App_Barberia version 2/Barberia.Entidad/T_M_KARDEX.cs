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
    
    public partial class T_M_KARDEX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_KARDEX()
        {
            this.T_D_KARDEX = new HashSet<T_D_KARDEX>();
        }
    
        public int ID_KARDEX { get; set; }
        public Nullable<int> ID_PRODUCTO { get; set; }
        public Nullable<System.DateTime> FEC_KARDEX { get; set; }
        public Nullable<int> ID_PERSONAL { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_D_KARDEX> T_D_KARDEX { get; set; }
        public virtual T_M_PRODUCTO T_M_PRODUCTO { get; set; }
    }
}
