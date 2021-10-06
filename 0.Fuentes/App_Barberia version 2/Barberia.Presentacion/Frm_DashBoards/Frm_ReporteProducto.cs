using Barberia.Entidad;
using Barberia.Negocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public partial class Frm_ReporteProducto : Form
    {
        private Cls_Rule_V_Venta objVVenta = new Cls_Rule_V_Venta();
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Producto ObjProducto = new Cls_Rule_Producto();
        //private Cls_Rule_Voucher_Venta ObjVoucherVenta = new Cls_Rule_Voucher_Venta();
        public Frm_ReporteProducto()
        {
            InitializeComponent();
        }

        void EventoCarga()
        {
            List<T_M_CLIENTES> lisCliente = new List<T_M_CLIENTES>();
            List<T_M_PERSONAL> lisPersonal = new List<T_M_PERSONAL>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();

            lisCliente = ObjCliente.Listar_Clientes(1,ref auditoria).Select(x => new T_M_CLIENTES
            {
                NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
                ID_CLIENTE = x.ID_CLIENTE
            }).ToList();
            if (!auditoria.EJECUCION_PROCEDIMIENTO)
            {
                if (auditoria.RECHAZAR)
                {
                    Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                }
            }
            else
            {
                lisCliente.Insert(0, new T_M_CLIENTES
                {
                    ID_CLIENTE = 0,
                    NOMBRES = "-- SELECCIONE --"
                });

            }

            lisPersonal = ObjPersonal.Listar_Personal(1, ref auditoria).Select(x => new T_M_PERSONAL
            {
                NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
                ID_PERSONAL = x.ID_PERSONAL
            }).ToList();

            lisPersonal.Insert(0, new T_M_PERSONAL
            {
                ID_PERSONAL = 0,
                NOMBRES = "-- SELECCIONE --"
            });

        }
        private void Frm_ReporteVenta_Load(object sender, EventArgs e)
        {
            Task tarea;
            CheckForIllegalCrossThreadCalls = false;
            tarea = Task.Run(() => EventoCarga()).ContinueWith(t => t.Dispose());
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            V_VENTA entidad = new V_VENTA();
            
            string fechaInicio, fechaFin;

            fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<DataProducto> dataProducto = new List<DataProducto>();
            List<V_VENTA> venta = new List<V_VENTA>();
            venta = objVVenta.Buscar_Venta(entidad, fechaInicio, fechaFin, ref auditoria);

            var grupo = venta.GroupBy(x => x.PRODUCTO).ToList();
            int cantidad = 0;
            decimal total = 0;
            venta.Clear();
            foreach (var item in grupo)
            {
                foreach (var producto in item)
                {
                    cantidad += (int)producto.CANTIDAD;
                    total += (decimal)producto.IMPORTE;
                }
                venta.Add(new V_VENTA
                {
                    CANTIDAD = cantidad,
                    PRODUCTO = item.Key,
                    TOTAL = total
                });
                cantidad = 0;
                total = 0;
            }
            List<V_VENTA> venta2 = venta.OrderByDescending(x => x.CANTIDAD).ToList();
            venta = venta.OrderByDescending(x => x.CANTIDAD).ToList();
            //venta.Add((V_VENTA)venta.OrderByDescending(x => x.CANTIDAD));

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteProducto.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds1 = new ReportDataSource("DataSetVenta", venta);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);

                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.RefreshReport();

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            T_M_PRODUCTO entidad = new T_M_PRODUCTO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            string fechaInicio, fechaFin;
            fechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
            fechaFin = DateTime.Now.ToString("dd/MM/yyyy");


            List<Cls_Ent_Producto> lista = new List<Cls_Ent_Producto>();
            lista = ObjProducto.Listar_Producto(1,ref auditoria);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteProductoStock.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds1 = new ReportDataSource("DataSetStock", lista);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.ZoomPercent = 115;
            this.reportViewer1.RefreshReport();
        }
    }
}
