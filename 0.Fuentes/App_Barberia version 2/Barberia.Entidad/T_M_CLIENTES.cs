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
    
    public partial class T_M_CLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_CLIENTES()
        {
            this.T_M_VENTA = new HashSet<T_M_VENTA>();
        }
    
        public int ID_CLIENTE { get; set; }
        public int ID_EMPRESA { get; set; }
        public string TIPO_PERSONA { get; set; }
        public string R_SOCIAL { get; set; }
        public string REPRESENTANTE_LEGAL { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PAT { get; set; }
        public string APELLIDO_MAT { get; set; }
        public string TIPO_DOC { get; set; }
        public string NUM_DOC { get; set; }
        public string FLG_TIPO { get; set; }
        public string COD_DEPARTAMENTO { get; set; }
        public string COD_PROVINCIA { get; set; }
        public string COD_DISTRITO { get; set; }
        public string DIRECCION { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_M_VENTA> T_M_VENTA { get; set; }
    }
}
