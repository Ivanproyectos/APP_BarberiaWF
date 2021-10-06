using Barberia.Entidad;
using Barberia.Negocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public partial class Frm_ReporteAnular : Form
    {
        private Cls_Rule_V_Venta objVVenta = new Cls_Rule_V_Venta();
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();

        public Frm_ReporteAnular()
        {
            InitializeComponent();
        }

        private void Frm_ReporteVenta_Load(object sender, EventArgs e)
        {
            //Task tarea;
            //CheckForIllegalCrossThreadCalls = false;
            //tarea = Task.Run(() => EventoCarga()).ContinueWith(t => t.Dispose());
            rdbAnularVenta.Checked = true;
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
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            string fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            string fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds1 = null;
            if (rdbAnularVenta.Checked)
            {
                Cls_Rule_Anular_Venta obj = new Cls_Rule_Anular_Venta();
                List<T_ANULAR_VENTA> listAnular = new List<T_ANULAR_VENTA>();
                listAnular = obj.BuscarReporte_Anular_Venta(fechaInicio, fechaFin, ref auditoria);
                rds1 = new ReportDataSource("DataAnularVenta", listAnular);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteAnularVenta.rdlc";
            }
            else if (rdbAnularServicio.Checked)
            {
                Cls_Rule_Anular_Corte obj = new Cls_Rule_Anular_Corte();
                List<T_ANULAR_CORTE> listAnular = new List<T_ANULAR_CORTE>();
                listAnular = obj.BuscarReporte_Anular_Corte(fechaInicio, fechaFin, ref auditoria);
                rds1 = new ReportDataSource("DataAnularCorte", listAnular);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteAnularCorte.rdlc";
            }
            else if (rdbAnularStock.Checked)
            {
                Cls_Rule_Anular_Stock obj = new Cls_Rule_Anular_Stock();
                List<T_STOCK_ANULAR> listAnular = new List<T_STOCK_ANULAR>();
                listAnular = obj.BuscarReporte_Anular_Stock(fechaInicio, fechaFin, ref auditoria);
                rds1 = new ReportDataSource("DataAnularStock", listAnular);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteAnularStock.rdlc";
            }

            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            //this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();

        }


    }
}
