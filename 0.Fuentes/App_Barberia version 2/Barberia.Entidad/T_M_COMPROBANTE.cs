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
    
    public partial class T_M_COMPROBANTE
    {
        public int ID_COMPROBANTE { get; set; }
        public int ID_EMPRESA { get; set; }
        public Nullable<int> ID_DOCUMENTO { get; set; }
        public string ANIO { get; set; }
        public string SERIE { get; set; }
        public Nullable<int> NUMERO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    
        public virtual T_M_DOCUMENTO_SUNAT T_M_DOCUMENTO_SUNAT { get; set; }
    }
}
