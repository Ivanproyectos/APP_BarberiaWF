using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Entidad
{
    public class Cls_Ent_Personal : Cls_Ent_Base
    {
        public int ID_PERSONAL { get; set; }
        public string NOMBRES_APELLIDO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string TELEFENO { get; set; }
        public string CELULAR { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
        public string DESC_DEPARTAMENTO { get; set; }
        public string DESC_PROVINCIA { get; set; }
        public string DESC_DISTRITO { get; set; }
        public string TIPO_PERSONA { get; set; }
        public string ID_DEPARTAMENTO { get; set; }
        public string ID_PROVINCIA { get; set; }
        public string ID_DISTRITO { get; set; }
        public string PERSONAL { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
        public string APE_PATERNO { get; set; }
        public string APE_MATERNO { get; set; }
        public string NOMBRES { get; set; }
        public int ID_SISTEMA { get; set; }
        public int ID_EMPRESA { get; set; }
    }
}
