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
    public partial class Frm_Dashboard : Form
    {
        //private Cls_Rule_Venta objVenta = new Cls_Rule_Venta();
        private Cls_Rule_V_Corte objCorte = new Cls_Rule_V_Corte();
        public Frm_Dashboard()
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
            
            List<V_CORTE> lista = new List<V_CORTE>();
            V_CORTE entidad = new V_CORTE();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entidad.MES = cmbMes.SelectedIndex;
            entidad.ANIO = int.Parse(txtFechaInicio.Text);
            lista = objCorte.Buscar_Corte(entidad, "", "", ref auditoria);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.DashBoard.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSetCorte", lista);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
            //MessageBox.Show(index.ToString());
        }

        #region HELP

            void Cargar_Inicio()
            {
                List<V_CORTE> lista = new List<V_CORTE>();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                lista = objCorte.Listar_Corte(ref auditoria);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.DashBoard.rdlc";
                ReportDataSource rds1 = new ReportDataSource("DataSetCorte", lista);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.RefreshReport();
                cmbMes.SelectedIndex = 0;
                txtFechaInicio.Text = DateTime.Now.Year.ToString();
            }

        #endregion
    }

}
