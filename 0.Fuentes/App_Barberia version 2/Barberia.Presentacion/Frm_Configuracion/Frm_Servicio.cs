using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Configuracion
{
    public partial class Frm_Servicio : Form
    {
        private Cls_Rule_Servicio ObjServicio = new Cls_Rule_Servicio();
        string user; //usuario logeado
        public Frm_Servicio(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        #region Helper

        private void Boton_Enabled(bool estado)
        {
            if (estado)
            {
                btnActualizar.Enabled = true;
                btnActualizar.BackColor = Color.SeaGreen;
                btnEliminar.Enabled = true;
                btnEliminar.BackColor = Color.SeaGreen;
            }
            else
            {
                btnActualizar.Enabled = false;
                btnActualizar.BackColor = Color.Gray;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Gray;
            }
        }

        private void Limpiar()
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            txtDescripcion.Text = string.Empty;
            lblIdServicio.Text = string.Empty;
            Boton_Enabled(false);
            btnGuardar.Enabled = true;
            dataGridView1.DataSource = ObjServicio.Listar_Servicio(ref auditoria);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        #endregion
        private void Frm_Servicio_Load(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            dataGridView1.DataSource = ObjServicio.Listar_Servicio(ref auditoria);
            dataGridView1.Columns["ID_SERVICIO"].Visible = false;
            //dataGridView1.Columns["T_M_PERSONAL"].Visible = false;
            dataGridView1.Columns["FLG_ESTADO"].Visible = false;
            dataGridView1.Columns["DES_SERVICIO"].HeaderText = "SERVICIO";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            if (dataGridView1.Rows.Count > 0)
            {
                //dataGridView1.SelectedRows[0].Selected = false;
                dataGridView1.ClearSelection();
            }
            Boton_Enabled(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                bool exito = false;
                T_M_SERVICIO entidad = new T_M_SERVICIO();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.DES_SERVICIO = txtDescripcion.Text.Trim().ToUpper();
                entidad.FLG_ESTADO = "1";
                entidad.USU_CREACION = user;
                entidad.FEC_CREACION = DateTime.Now;
                exito = ObjServicio.Insertar_Servicio(entidad, ref auditoria);
                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La descripción ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                T_M_SERVICIO entidad = new T_M_SERVICIO();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.ID_SERVICIO = int.Parse(lblIdServicio.Text);
                entidad.DES_SERVICIO = txtDescripcion.Text.Trim().ToUpper();
                //entidad.USU_CREACION = lblUserCreacion.Text;
                //entidad.FEC_CREACION = DateTime.Parse(lblFecCreacion.Text);
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                //entidad.FLG_ESTADO = lblFlag.Text;
                exito = ObjServicio.Actualizar_Servicio(entidad, ref auditoria);
                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La descripción ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //T_M_PERSONAL entPersonal = new T_M_PERSONAL();

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                T_M_SERVICIO entidad = new T_M_SERVICIO();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.ID_SERVICIO = int.Parse(lblIdServicio.Text);
                entidad.FLG_ESTADO = "0";
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = ObjServicio.Eliminar_Servicio(entidad, ref auditoria);
                    if (exito)
                    {
                        //entPersonal.ID_CARGO = entidad.ID_CARGO;
                        //entPersonal.USU_MODIFICA = entidad.USU_MODIFICA;
                        //entPersonal.FEC_MODIFICA = entidad.FEC_MODIFICA;
                        //exito = ObjPersonal.Eliminar_Personal(entPersonal);
                        Limpiar();
                        MessageBox.Show("El registro ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            T_M_SERVICIO entidad = new T_M_SERVICIO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entidad.DES_SERVICIO = txtDescripcion.Text.Trim().ToUpper();
            dataGridView1.DataSource = ObjServicio.Buscar_Servicio(entidad, ref auditoria);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                lblIdServicio.Text = dataGridView1.CurrentRow.Cells["ID_SERVICIO"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DES_SERVICIO"].Value.ToString();
                lblUserCreacion.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFecCreacion.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                lblFlag.Text = dataGridView1.CurrentRow.Cells["FLG_ESTADO"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
