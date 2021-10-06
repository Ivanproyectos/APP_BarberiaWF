using System.Collections.Generic;

namespace Barberia.Entidad
{
    public class Cls_Ent_Anular_Fac
    {

        public string correlativo { get; set; }
        public string fecGeneracion { get; set; }
        public string fecComunicacion { get; set; }
        public Empresa company { get; set; }
        public List<DetalleAnular> details { get; set; }

        public class DetalleAnular
        {
            public string tipoDoc { get; set; } //Catálogo No. 01
            public string serie { get; set; }
            public string correlativo { get; set; }
            public string desMotivoBaja { get; set; }
        }
    }


}
