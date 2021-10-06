using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Entidad
{
    public class Cls_Ent_Base
    {
        public int FLG_ESTADO { get; set; }

        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string IP_CREACION { get; set; }

        public string USU_MODIFICACION { get; set; }
        public string FEC_MODIFICACION { get; set; }
        public string IP_MODIFICACION { get; set; }

        public string ACCION { get; set; }
    }
}
