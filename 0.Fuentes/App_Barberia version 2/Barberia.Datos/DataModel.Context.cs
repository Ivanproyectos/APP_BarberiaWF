//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Barberia.Datos
{
    using Barberia.Entidad;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_BARBERIAEntities1 : DbContext
    {
        public DB_BARBERIAEntities1()
            : base("name=DB_BARBERIAEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_ACTUALIZAR_STOCK> T_ACTUALIZAR_STOCK { get; set; }
        public virtual DbSet<T_ANULAR_CORTE> T_ANULAR_CORTE { get; set; }
        public virtual DbSet<T_ANULAR_VENTA> T_ANULAR_VENTA { get; set; }
        public virtual DbSet<T_BOLETA> T_BOLETA { get; set; }
        public virtual DbSet<T_C_ANULAR> T_C_ANULAR { get; set; }
        public virtual DbSet<T_CORRELATIVO_COTIZACION> T_CORRELATIVO_COTIZACION { get; set; }
        public virtual DbSet<T_CORRELATIVO_ORDENCOMPRA> T_CORRELATIVO_ORDENCOMPRA { get; set; }
        public virtual DbSet<T_CORRELATIVO_PRODUCTO> T_CORRELATIVO_PRODUCTO { get; set; }
        public virtual DbSet<T_D_COTIZACION> T_D_COTIZACION { get; set; }
        public virtual DbSet<T_D_DOCUMENTOS_VENTAS> T_D_DOCUMENTOS_VENTAS { get; set; }
        public virtual DbSet<T_D_ENVIO_RESUMEN> T_D_ENVIO_RESUMEN { get; set; }
        public virtual DbSet<T_D_KARDEX> T_D_KARDEX { get; set; }
        public virtual DbSet<T_D_ORDEN_COMPRA> T_D_ORDEN_COMPRA { get; set; }
        public virtual DbSet<T_D_PARAMETRO> T_D_PARAMETRO { get; set; }
        public virtual DbSet<T_D_VENTA> T_D_VENTA { get; set; }
        public virtual DbSet<T_FACTURA> T_FACTURA { get; set; }
        public virtual DbSet<T_FORMA_PAGO> T_FORMA_PAGO { get; set; }
        public virtual DbSet<T_M_ALMACEN> T_M_ALMACEN { get; set; }
        public virtual DbSet<T_M_CATEGORIA> T_M_CATEGORIA { get; set; }
        public virtual DbSet<T_M_CLASE> T_M_CLASE { get; set; }
        public virtual DbSet<T_M_CLIENTES> T_M_CLIENTES { get; set; }
        public virtual DbSet<T_M_COMPROBANTE> T_M_COMPROBANTE { get; set; }
        public virtual DbSet<T_M_COMPROBANTE_SUNAT> T_M_COMPROBANTE_SUNAT { get; set; }
        public virtual DbSet<T_M_COTIZACION> T_M_COTIZACION { get; set; }
        public virtual DbSet<T_M_CUOTA> T_M_CUOTA { get; set; }
        public virtual DbSet<T_M_DEPARTAMENTO> T_M_DEPARTAMENTO { get; set; }
        public virtual DbSet<T_M_DISTRITO> T_M_DISTRITO { get; set; }
        public virtual DbSet<T_M_DOCUMENTO_SUNAT> T_M_DOCUMENTO_SUNAT { get; set; }
        public virtual DbSet<T_M_EMPRESA> T_M_EMPRESA { get; set; }
        public virtual DbSet<T_M_ENVIO_RESUMEN> T_M_ENVIO_RESUMEN { get; set; }
        public virtual DbSet<T_M_KARDEX> T_M_KARDEX { get; set; }
        public virtual DbSet<T_M_MARCA> T_M_MARCA { get; set; }
        public virtual DbSet<T_M_MODELO> T_M_MODELO { get; set; }
        public virtual DbSet<T_M_MONEDA> T_M_MONEDA { get; set; }
        public virtual DbSet<T_M_ORDEN_COMPRA> T_M_ORDEN_COMPRA { get; set; }
        public virtual DbSet<T_M_PARAMETRO> T_M_PARAMETRO { get; set; }
        public virtual DbSet<T_M_PRODUCTO> T_M_PRODUCTO { get; set; }
        public virtual DbSet<T_M_PROVINCIA> T_M_PROVINCIA { get; set; }
        public virtual DbSet<T_M_SERIE> T_M_SERIE { get; set; }
        public virtual DbSet<T_M_SERVICIO> T_M_SERVICIO { get; set; }
        public virtual DbSet<T_M_UNIDAD_MEDIDA> T_M_UNIDAD_MEDIDA { get; set; }
        public virtual DbSet<T_M_VENTA> T_M_VENTA { get; set; }
        public virtual DbSet<T_STOCK_ANULAR> T_STOCK_ANULAR { get; set; }
        public virtual DbSet<T_TIPO_AFECTACION> T_TIPO_AFECTACION { get; set; }
        public virtual DbSet<T_TIPO_COMPROBANTE> T_TIPO_COMPROBANTE { get; set; }
        public virtual DbSet<T_TIPO_DOCUMENTO> T_TIPO_DOCUMENTO { get; set; }
        public virtual DbSet<T_TIPO_PERSONA> T_TIPO_PERSONA { get; set; }
        public virtual DbSet<T_VOUCHER> T_VOUCHER { get; set; }
        public virtual DbSet<V_ACTUALIZAR_STOCK> V_ACTUALIZAR_STOCK { get; set; }
        public virtual DbSet<V_CLIENTE> V_CLIENTE { get; set; }
        public virtual DbSet<V_COTIZACION> V_COTIZACION { get; set; }
        public virtual DbSet<V_EMPRESA> V_EMPRESA { get; set; }
        public virtual DbSet<V_KARDEX> V_KARDEX { get; set; }
        public virtual DbSet<V_M_COTIZACION> V_M_COTIZACION { get; set; }
        public virtual DbSet<V_M_ORDEN_COMPRA> V_M_ORDEN_COMPRA { get; set; }
        public virtual DbSet<V_M_PARAMETRO> V_M_PARAMETRO { get; set; }
        public virtual DbSet<V_M_VENTA> V_M_VENTA { get; set; }
        public virtual DbSet<V_ORDEN_COMPRA> V_ORDEN_COMPRA { get; set; }
        public virtual DbSet<V_PARAMETRO> V_PARAMETRO { get; set; }
        public virtual DbSet<V_PRODUCTO> V_PRODUCTO { get; set; }
        public virtual DbSet<V_VENTA> V_VENTA { get; set; }
    }
}
