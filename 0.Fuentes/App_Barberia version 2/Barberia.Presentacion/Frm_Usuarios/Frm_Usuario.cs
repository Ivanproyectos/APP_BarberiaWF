using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Usuarios
{
    public partial class Frm_Usuario : Form
    {
        Cls_Rule_Usuario ObjUsuario = new Cls_Rule_Usuario();
        Cls_Rule_M_Perfil ObjPerfil = new Cls_Rule_M_Perfil();
        Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();

        string user; //usuario logeado
        public Frm_Usuario(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

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
            lblIdUsuario.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbPerfil.SelectedIndex = 0;
            cmbPersonal.SelectedIndex = 0;
            Boton_Enabled(false);
            btnGuardar.Enabled = true;
            dataGridView1.DataSource = ObjUsuario.Listar_Usuario(1,ref auditoria);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }

        }

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {
            List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
            List<T_M_PERSONAL> lisPersonal = new List<T_M_PERSONAL>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lista = ObjPerfil.Listar_Perfil( ref auditoria).OrderBy(x => x.DESCRIPCION).ToList();
            cmbPerfil.DataSource = lista;
            lista.Insert(0, new T_M_PERFIL()
            {
                ID_PERFIL = 0,
                DESCRIPCION = "-- SELECCIONE --"
            });
            cmbPerfil.DisplayMember = "DESCRIPCION";
            cmbPerfil.ValueMember = "ID_PERFIL";

            lisPersonal = ObjPersonal.Listar_Personal(1, ref auditoria).OrderBy(x => x.NOMBRES).Select(x => new T_M_PERSONAL
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
            //cmbPersonal.SelectedIndex = _idPersonal;

            dataGridView1.DataSource = ObjUsuario.Listar_Usuario(1, ref auditoria);
            dataGridView1.Columns["ID_USUARIO"].Visible = false;
            dataGridView1.Columns["ID_PERSONAL"].Visible = false;
            dataGridView1.Columns["CLAVE"].Visible = false;
            dataGridView1.Columns["FLG_ESTADO"].Visible = false;
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            Boton_Enabled(false);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                lblIdUsuario.Text = dataGridView1.CurrentRow.Cells["ID_USUARIO"].Value.ToString();
                txtUsuario.Text = dataGridView1.CurrentRow.Cells["USUARIO"].Value.ToString();
                txtPassword.Text = dataGridView1.CurrentRow.Cells["CLAVE"].Value.ToString();
                cmbPerfil.Text = dataGridView1.CurrentRow.Cells["PERFIL"].Value.ToString();
                cmbPersonal.Text= dataGridView1.CurrentRow.Cells["PERSONAL"].Value.ToString();
                lblUser.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFecha.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                lblFlag.Text = dataGridView1.CurrentRow.Cells["FLG_ESTADO"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            T_M_USUARIO entUsuario = new T_M_USUARIO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtPassword.Text) 
                && (cmbPerfil.SelectedIndex > 0) && (cmbPersonal.SelectedIndex > 0))
            {
                entUsuario.USUARIO = txtUsuario.Text.Trim().ToUpper();
                entUsuario.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
                entUsuario.ID_PERSONAL = int.Parse(cmbPersonal.SelectedValue.ToString());
                entUsuario.USU_CREACION = user;
                entUsuario.FEC_CREACION = DateTime.Now;
                entUsuario.FLG_ESTADO = "1";
                entUsuario.CLAVE = encriptar(txtPassword.Text.Trim().ToUpper());
                exito = ObjUsuario.Insertar_Usuario(entUsuario, ref auditoria);
                
                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El usuario ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            T_M_USUARIO entUsuario = new T_M_USUARIO();

            if (lblIdUsuario.Text == "")
            {
                MessageBox.Show("Seleccione un registro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtPassword.Text)
                && (cmbPerfil.SelectedIndex > 0))
                {
                    entUsuario.ID_USUARIO = int.Parse(lblIdUsuario.Text);
                    entUsuario.USUARIO = txtUsuario.Text.Trim().ToUpper();
                    if (txtPassword.Text == dataGridView1.CurrentRow.Cells["CLAVE"].Value.ToString())
                    {
                        entUsuario.CLAVE = dataGridView1.CurrentRow.Cells["CLAVE"].Value.ToString();
                    }
                    else
                    {
                        entUsuario.CLAVE = encriptar(txtPassword.Text.Trim().ToUpper());
                    }
                    entUsuario.ID_USUARIO = int.Parse(lblIdUsuario.Text);
                    entUsuario.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
                    entUsuario.ID_PERSONAL = int.Parse(cmbPersonal.SelectedValue.ToString());
                    //entUsuario.USU_CREACION = lblUser.Text;
                    //entUsuario.FEC_CREACION = DateTime.Parse(lblFecha.Text);
                    entUsuario.USU_MODIFICA = user;
                    entUsuario.FEC_MODIFICA = DateTime.Now;
                    //entUsuario.FLG_ESTADO = lblFlag.Text;
                    exito = ObjUsuario.Actualizar_Usuario(entUsuario, ref auditoria);
                    if (exito)
                    {
                        Limpiar();
                        MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Rellene todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            T_M_USUARIO entUsuario = new T_M_USUARIO();
            if (lblIdUsuario.Text == "" )
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entUsuario.ID_USUARIO = int.Parse(lblIdUsuario.Text);
                entUsuario.FLG_ESTADO = "0";
                entUsuario.USU_MODIFICA = user;
                entUsuario.FEC_MODIFICA = DateTime.Now;

                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = ObjUsuario.Eliminar_Usuario(entUsuario, ref auditoria);
                    if (exito)
                    {
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
            T_M_USUARIO entUsuario = new T_M_USUARIO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<Cls_Ent_UsuarioWForm> lista = new List<Cls_Ent_UsuarioWForm>();
            entUsuario.USUARIO = txtUsuario.Text;
            entUsuario.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
            entUsuario.ID_PERSONAL = int.Parse(cmbPersonal.SelectedValue.ToString());
            lista = ObjUsuario.Buscar_Usuario(entUsuario, ref auditoria);

            dataGridView1.DataSource = lista;

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //txtPassword.Text = ""; 
        }

        #region metodos

        private string encriptar(string contrasena)
        {
            var md5 = MD5.Create();
            //byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text.Trim().ToUpper()));
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
            string result = BitConverter.ToString(hash).Replace("-", "");
            md5.Dispose();
            return result;
        }

        #endregion
    }

}
