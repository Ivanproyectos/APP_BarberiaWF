using System.Collections.Generic;

namespace Barberia.Entidad
{
    public class Cls_Ent_Boleta
    {
        public Cls_Ent_Boleta()
        {
            this.ublVersion = "2.1";
            this.tipoOperacion = "0101";
            this.tipoDoc = "03";
            this.serie = "BE01";
            this.correlativo = "00000001";
            this.tipoMoneda = "PEN";
        }
        public string ublVersion { get; set; }
        public string tipoOperacion { get; set; } //Catálogo No. 51
        public string tipoDoc { get; set; } //Catálogo No. 01 / 03 => boleta, 01=>factura
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string fechaEmision { get; set; }
        public FormaPago formaPago { get; set; }
        public string tipoMoneda { get; set; }
        public Cliente client { get; set; }
        public Empresa company { get; set; }
        public List<Descuento> descuentos { get; set; }
        public decimal sumOtrosDescuentos { get; set; }
        public decimal mtoOperGravadas { get; set; }
        public decimal mtoIGV { get; set; }
        public decimal valorVenta { get; set; }
        public decimal totalImpuestos { get; set; }
        public decimal subTotal { get; set; }
        public decimal mtoImpVenta { get; set; }
        public List<DetalleProducto> details { get; set; }
        public List<Leyenda> legends { get; set; }
    }

    public class Descuento
    {
        public Descuento()
        {
            this.codTipo = "03"; //Descuentos globales que no afectan la base imponible del IGV
            this.factor = "";
        }
        public string codTipo { get; set; } //Catálogo No. 53
        public decimal montoBase { get; set; }
        public decimal monto { get; set; }
        public string factor { get; set; }
    }

    public class FormaPago
    {
        public FormaPago()
        {
            this.moneda = "PEN";
            this.tipo = "CONTADO";
        }
        public string moneda { get; set; }
        public string tipo { get; set; }
    }

    public class Cliente
    {
        public string tipoDoc { get; set; } //Catálogo No. 06
        public string numDoc { get; set; }
        public string rznSocial { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public Address()
        {
            direccion = "";
            provincia = "";
            departamento = "";
            distrito = "";
            ubigueo = "";
        }
        public string direccion { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string distrito { get; set; }
        public string ubigueo { get; set; }
    }

    public class Empresa
    {
        
        public Empresa()
        {
            this.ruc = "20123123121";
            this.razonSocial = "YORDAN SAC";
            this.nombreComercial = "";
        }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public Address address { get; set; }
    }
    
    public class DetalleProducto
    {
        public string codProducto { get; set; }
        public string unidad { get; set; } //Tabla 6 del excel
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal mtoValorUnitario { get; set; }
        public decimal mtoValorVenta { get; set; }
        public decimal mtoBaseIgv { get; set; }
        public decimal porcentajeIgv { get; set; }
        public decimal igv { get; set; }
        public string tipAfeIgv { get; set; } //Catálogo No. 07
        public decimal totalImpuestos { get; set; }
        public decimal mtoPrecioUnitario { get; set; }
    }

    public class Leyenda
    {
        public Leyenda()
        {
            this.code = "1000";
        }
        public string code { get; set; } //Catálogo No. 15 / 1000 monto en letras
        public string value { get; set; }

    }
}
