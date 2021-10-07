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
    
    public partial class T_M_COTIZACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_M_COTIZACION()
        {
            this.T_D_COTIZACION = new HashSet<T_D_COTIZACION>();
        }
    
        public int ID_COTIZACION { get; set; }
        public int ID_EMPRESA { get; set; }
        public Nullable<int> ID_EMPRESA_INTERNA { get; set; }
        public Nullable<int> ID_EMPRESA_CONTRATA { get; set; }
        public string NUM_COTIZACION { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> ID_PERSONA { get; set; }
        public string ASUNTO { get; set; }
        public Nullable<int> ID_FORMA_PAGO { get; set; }
        public string GARANTIA { get; set; }
        public Nullable<int> CANT_DIAS_VALIDES { get; set; }
        public Nullable<decimal> SUBTOTAL { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public Nullable<decimal> DESCUENTO { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_D_COTIZACION> T_D_COTIZACION { get; set; }
    }
}