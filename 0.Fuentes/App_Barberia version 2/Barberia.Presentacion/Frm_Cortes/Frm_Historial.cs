using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Cortes
{
    public partial class Frm_Historial : Form
    {
        private Cls_Rule_V_Corte ObjVistaCorte = new Cls_Rule_V_Corte();
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        public Frm_Historial()
        {
            InitializeComponent();
        }

        private void Frm_Historial_Load(object sender, EventArgs e)
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
                cmbCliente.DataSource = lisCliente;
                cmbCliente.DisplayMember = "NOMBRES";
                cmbCliente.ValueMember = "ID_CLIENTE";
            }
            

            lisPersonal = ObjPersonal.Listar_Personal(1, ref auditoria).Select(x => new T_M_PERSONAL
            {
                NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
                ID_PERSONAL = x.ID_PERSONAL
            }).ToList();
            cmbPersonal.DataSource = lisPersonal;
            lisPersonal.Insert(0, new T_M_PERSONAL
            {
                ID_PERSONAL = 0,
                NOMBRES = "-- SELECCIONE --"
            });
            cmbPersonal.DisplayMember = "NOMBRES";
            cmbPersonal.ValueMember = "ID_PERSONAL";

            dataGridView1.DataSource = ObjVistaCorte.ListarPagina_Corte(out int totalPagina, ref auditoria);
            dataGridView1.Columns["ID_DETALLE"].Visible = false;
            dataGridView1.Columns["ID_CORTE"].Visible = false;
            dataGridView1.Columns["EFECTIVO"].Visible = false;
            dataGridView1.Columns["VUELTO"].Visible = false;
            dataGridView1.Columns["ANIO"].Visible = false;
            dataGridView1.Columns["MES"].Visible = false;

            dataGridView1.Columns["DETALLE_CORTE"].HeaderText = "DETALLE CORTE";
            dataGridView1.Columns["FEC_CORTE"].HeaderText = "FECHA CORTE";
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            // Cargar la cantidad de pagina
            for (int i = 1; i <= totalPagina; i++)
            {
                cmbPagina.Items.Add(i);
            }
            cmbPagina.SelectedIndex = 0;
            
        }

        private void cmbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            int pagina = int.Parse(cmbPagina.Text) - 1;
            dataGridView1.DataSource = ObjVistaCorte.ListarPagina_Corte(out _, ref auditoria, pagina);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            V_CORTE entidad = new V_CORTE();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            string fechaInicio, fechaFin;

            entidad.CLIENTE = cmbCliente.SelectedIndex == 0 ? "" : cmbCliente.Text;
            entidad.PERSONAL = cmbPersonal.SelectedIndex == 0 ? "" : cmbPersonal.Text;
            fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");

            dataGridView1.DataSource = ObjVistaCorte.Buscar_Corte(entidad, fechaInicio, fechaFin, ref auditoria);
            dataGridView1.ClearSelection();
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            cmbCliente.SelectedIndex = 0;
            cmbPersonal.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            dataGridView1.DataSource = ObjVistaCorte.ListarPagina_Corte(out _, ref auditoria);
            dataGridView1.ClearSelection();
        }

        
    }
}
