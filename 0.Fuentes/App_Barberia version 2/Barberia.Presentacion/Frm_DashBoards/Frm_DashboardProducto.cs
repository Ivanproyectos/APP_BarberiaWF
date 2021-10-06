using Barberia.Entidad;
using Barberia.Negocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public partial class Frm_DashboardProducto : Form
    {
        Cls_Rule_V_Venta objVenta = new Cls_Rule_V_Venta();

        public Frm_DashboardProducto()
        {
            InitializeComponent();
        }

        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            //Application.DoEvents();
            CheckForIllegalCrossThreadCalls = false;
            System.Threading.Tasks.Task.Run(() => Cargar_Inicio());
            //System.Threading.Thread.Sleep(2500);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            List<V_VENTA> lista = new List<V_VENTA>();
            V_VENTA entVenta = new V_VENTA();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entVenta.MES = cmbMes.SelectedIndex;
            entVenta.ANIO = int.Parse(txtFechaInicio.Text);
            lista = objVenta.Buscar_Venta(entVenta, "", "", ref auditoria);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.DashBoardProducto.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSetVenta", lista);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
            //MessageBox.Show(index.ToString());
        }

        #region HELP

            void Cargar_Inicio()
            {
                List<V_VENTA> lista = new List<V_VENTA>();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                lista = objVenta.Listar_Venta(ref auditoria);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.DashBoardProducto.rdlc";
                ReportDataSource rds1 = new ReportDataSource("DataSetVenta", lista);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.RefreshReport();
                cmbMes.SelectedIndex = 0;
                txtFechaInicio.Text = DateTime.Now.Year.ToString();
            }

        #endregion
    }

}
