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

namespace Barberia.Presentacion.Frm_DashBoards
{
    public partial class Frm_Buscar : Form
    {
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        //private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private T_M_CLIENTES entCliente = new T_M_CLIENTES();
        //private T_M_PERSONAL entPersonal = new T_M_PERSONAL();
        private string _opcion;
        public string DevolverNombre;
        public Frm_Buscar(string opcion)
        {
            InitializeComponent();
            _opcion = opcion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblNota.Visible = true;

            List<string> lista = new List<string>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (_opcion == "CLIENTE")
            {
                entCliente.NOMBRES = txtNombre.Text.Trim().ToUpper();
                lista = ObjCliente.Buscar_Clientes(entCliente, ref auditoria).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    if (auditoria.RECHAZAR)
                    {
                        Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                    }
                }
                else
                {
                    dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
                }

            }
            else if (_opcion == "PERSONAL")
            {
                //entPersonal.NOMBRES = txtNombre.Text.Trim().ToUpper();
                //lista = ObjPersonal.Buscar_Personal(entPersonal, ref auditoria).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
                //dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            }

            for (int i = 0; i < lista.Count(); i++)
            {
                dataGridView1.Rows.Add(lista[i]);
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Frm_ReporteCorte form = (Frm_ReporteCorte)this.Owner;

            if (dataGridView1.Rows.Count > 0)
            {
                if (_opcion == "CLIENTE")
                {
                    //form.cmbCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                else if(_opcion == "PERSONAL")
                {
                    //form.cmbPersonal.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Buscar_Load(object sender, EventArgs e)
        {

        }
    }
}
