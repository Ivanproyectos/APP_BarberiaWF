using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Entidad
{
    public class Cls_Ent_Usuario : Cls_Ent_Base
    {

        public long ID_USUARIO { get; set; }
        public int ID_SISTEMA { get; set; }
        public int ID_PERFIL { get; set; }
        public string ID_OFICINA { get; set; }
        public string DEPENDENCIA { get; set; }
        public string COD_USUARIO { get; set; }
        public string CLAVE_USUARIO { get; set; }

        public string FECHA_ACTIVACION { get; set; }
        public string FECHA_DESACTIVACION { get; set; }
        public string TOKEN { get; set; }
        public string FLG_ACTIVEDIRECTORY { get; set; }

        public Cls_Ent_Personal Persona { get; set; }

        public int ID_TIPO_USUARIO { get; set; }
        public int ID_EMPRESA { get; set; }
    }
}
