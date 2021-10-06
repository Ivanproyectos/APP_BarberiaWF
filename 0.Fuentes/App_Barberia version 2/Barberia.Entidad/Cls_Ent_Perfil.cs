using System;

namespace Barberia.Entidad
{
    public class Cls_Ent_Perfil
    {
        public int ID_CONFIG { get; set; }
        public Nullable<int> ID_PERFIL { get; set; }
        public string PERFIL { get; set; }
        public string DESCRIPCION { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<System.DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<System.DateTime> FEC_MODIFICA { get; set; }
    }
}
