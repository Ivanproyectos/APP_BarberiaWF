using System.Collections.Generic;

namespace Barberia.Entidad
{
    public class Cls_Ent_Anular_Bol
    {

        public string correlativo { get; set; }
        public string fecGeneracion { get; set; }
        public string fecResumen { get; set; }
        public string moneda { get; set; }
        public Empresa company { get; set; }
        public List<DetalleAnular> details { get; set; }

        public class DetalleAnular
        {
            public string tipoDoc { get; set; } //Catálogo No. 01
            public string serieNro { get; set; }
            public string estado { get; set; } //3 = anulado
            public string clienteTipo { get; set; } //1 = boleta / 6 ruc
            public string clienteNro { get; set; }
            public decimal mtoOperGravadas { get; set; }
            public decimal mtoIGV { get; set; }
            public decimal total { get; set; }
        }
    }


}
