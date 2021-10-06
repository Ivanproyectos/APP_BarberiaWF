using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Entidad
{
    public class Cls_Ent_sistemas_Usuarios : Cls_Ent_Base
    {
        public int ID_SISTEMAS_PERFIL_USUARIO { get; set; }
        public int ID_SISTEMA { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_EMPRESA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DESC_PERFIL { get; set; }
        public string FEC_ACTIVACION { get; set; }
        public string FEC_DESACTIVACION { get; set; }

        public string COD_USUARIO { get; set; }


        public int CODIGO_FILA { get; set; }

        public string NOMBRES_APE { get; set; }

    }
}
