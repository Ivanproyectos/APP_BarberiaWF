using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Entidad
{
    public class Cls_Ent_UsuarioWForm
    {
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string CLAVE { get; set; }
        //public int ID_PERFIL { get; set; }
        public string PERFIL { get; set; }
        public int ID_PERSONAL { get; set; }
        public string PERSONAL { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public Nullable<DateTime> FEC_CREACION { get; set; }
        public string USU_MODIFICA { get; set; }
        public Nullable<DateTime> FEC_MODIFICA { get; set; }
    }
}
