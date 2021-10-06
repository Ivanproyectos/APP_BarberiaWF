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
    public partial class Frm_ReporteCorte : Form
    {
        private Cls_Rule_V_Corte objVCorte = new Cls_Rule_V_Corte();
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Servicio ObjServicio = new Cls_Rule_Servicio();
        private Cls_Rule_Boleta ObjVoucher = new Cls_Rule_Boleta();
        public Frm_ReporteCorte()
        {
            InitializeComponent();
        }

        void EventoCarga()
        {
            List<T_M_CLIENTES> lisCliente = new List<T_M_CLIENTES>();
            List<T_M_PERSONAL> lisPersonal = new List<T_M_PERSONAL>();
            List<T_M_SERVICIO> lisServicio = new List<T_M_SERVICIO>();
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
                cmbCliente.DataSource = lisCliente;
                cmbCliente.DisplayMember = "NOMBRES";
                cmbCliente.ValueMember = "ID_CLIENTE";
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
            cmbPersonal.DataSource = lisPersonal;
            cmbPersonal.DisplayMember = "NOMBRES";
            cmbPersonal.ValueMember = "ID_PERSONAL";

            lisServicio = ObjServicio.Listar_Servicio(ref auditoria).OrderBy(x => x.DES_SERVICIO).Select(x => new T_M_SERVICIO
            {
                DES_SERVICIO = x.DES_SERVICIO,
                ID_SERVICIO = x.ID_SERVICIO
            }).ToList();

            lisServicio.Insert(0, new T_M_SERVICIO
            {
                ID_SERVICIO = 0,
                DES_SERVICIO = "-- SELECCIONE --"
            });
            cmbServicio.DataSource = lisServicio;
            cmbServicio.DisplayMember = "DES_SERVICIO";
            cmbServicio.ValueMember = "DES_SERVICIO";
        }

        Task tarea;
        private void Frm_Reporte_Load(object sender, EventArgs e)
        {
            //Application.DoEvents();
            CheckForIllegalCrossThreadCalls = false;
            tarea = Task.Run(() => EventoCarga()).ContinueWith(t =>  t.Dispose());
            
        }



        private void cmbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = 0;
            cmbPersonal.SelectedIndex = 0;
            txtVoucher.Text = string.Empty;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            V_CORTE entidad = new V_CORTE();

            string fechaInicio, fechaFin;
            List<DataTotal> dataTotal = new List<DataTotal>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entidad.CLIENTE = cmbCliente.SelectedIndex == 0 ? "" : cmbCliente.Text;
            entidad.PERSONAL = cmbPersonal.SelectedIndex == 0 ? "" : cmbPersonal.Text;
            entidad.VOUCHER = txtVoucher.Text;
            if (cmbServicio.SelectedIndex > 0)
            {
                entidad.DES_SERVICIO = cmbServicio.Text;
            }
            
            fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");

            List<V_CORTE> lista = new List<V_CORTE>();
            lista = objVCorte.Buscar_Corte(entidad, fechaInicio, fechaFin, ref auditoria);


            if (entidad.CLIENTE != "" || entidad.PERSONAL != "" || fechaInicio != "" || fechaFin != "")
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.Reporte.rdlc";
                
                ReportDataSource rds1 = new ReportDataSource("DataCorte", lista);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds1);

                this.reportViewer1.RefreshReport();
            }

        }

        private void picBusPersonal_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("PERSONAL");
            //AddOwnedForm(form);
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbPersonal.SelectedIndex = 0;
            else
                cmbPersonal.Text = form.DevolverNombre;
        }

        private void picBusCliente_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("CLIENTE");
            //AddOwnedForm(form);
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbCliente.SelectedIndex = 0;
            else
                cmbCliente.Text = form.DevolverNombre;
        }

        private void btnReporteDia_Click(object sender, EventArgs e)
        {
            V_CORTE entidad = new V_CORTE();
            string fechaInicio, fechaFin;

            fechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
            fechaFin = DateTime.Now.ToString("dd/MM/yyyy");
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<V_CORTE> lista = new List<V_CORTE>();
            lista = objVCorte.Buscar_Corte(entidad, fechaInicio, fechaFin, ref auditoria);


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteXDia.rdlc";

                ReportDataSource rds1 = new ReportDataSource("DataCorte", lista);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds1);

                this.reportViewer1.RefreshReport();

        }
    }
}
