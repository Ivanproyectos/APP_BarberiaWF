using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Perfiles
{
    public partial class Frm_Perfil : Form
    {
        Cls_Rule_M_Perfil objMPerfil = new Cls_Rule_M_Perfil();
  
        string user; //usuario logeado
        public Frm_Perfil(string usuario)
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
            lblidPerfilM.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            lblFechaM.Text = string.Empty;
            lblUserM.Text = string.Empty;
            Boton_Enabled(false);
            btnGuardar.Enabled = true;
            dataGridView1.DataSource = objMPerfil.Listar_Perfil(ref auditoria);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        private void Frm_Perfil_Load(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            dataGridView1.DataSource = objMPerfil.Listar_Perfil(ref auditoria);
            dataGridView1.Columns["T_C_PERFIL"].Visible = false;
            dataGridView1.Columns["ID_PERFIL"].Visible = false;
            dataGridView1.Columns["T_M_USUARIO"].Visible = false;
            dataGridView1.Columns["FLG_ESTADO"].Visible = false;
            dataGridView1.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            
            Boton_Enabled(false);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                lblidPerfilM.Text = dataGridView1.CurrentRow.Cells["ID_PERFIL"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                lblUserM.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFechaM.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                lblFlagPerfil.Text = dataGridView1.CurrentRow.Cells["FLG_ESTADO"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (txtDescripcion.Text != string.Empty)
            {
                T_M_PERFIL entidad = new T_M_PERFIL();
                bool exito = false;
                
                entidad.DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
                entidad.USU_CREACION = user;
                entidad.FEC_CREACION = DateTime.Now;
                entidad.FLG_ESTADO = "1";

                exito = objMPerfil.Insertar_Perfil(entidad, ref auditoria);
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
                MessageBox.Show("Ingrese la descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            bool exito = false;
            T_M_PERFIL entidad = new T_M_PERFIL();
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Ingrese la descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                entidad.ID_PERFIL = int.Parse(lblidPerfilM.Text);
                entidad.DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
               // entidad.USU_CREACION = lblUserM.Text;
                //entidad.FEC_CREACION = DateTime.Parse(lblFechaM.Text);
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                //entidad.FLG_ESTADO = lblFlagPerfil.Text;
                exito = objMPerfil.Actualizar_Perfil(entidad, ref auditoria);
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
            T_M_PERFIL entidad = new T_M_PERFIL();
            Cls_Rule_Usuario objUser = new Cls_Rule_Usuario();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Ingrese la descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                entidad.ID_PERFIL = int.Parse(lblidPerfilM.Text);
                entidad.FLG_ESTADO = "0";
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                var res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    bool exito;
                    exito = objMPerfil.Eliminar_Perfil(entidad, ref auditoria);
                    if (exito)
                    {
                        
                        T_C_PERFIL entidadCPerfil = new T_C_PERFIL();
                        entidadCPerfil.ID_PERFIL = int.Parse(lblidPerfilM.Text);
                        entidadCPerfil.USU_MODIFICA = user;
                        entidadCPerfil.FEC_MODIFICA = DateTime.Now;
                        entidadCPerfil.FLG_ESTADO = "0";
                        exito = objCPerfil.Eliminar_Perfil(entidadCPerfil, ref auditoria);
                        if (exito)
                        {
                            MessageBox.Show("El registro ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        T_M_USUARIO entUser = new T_M_USUARIO();
                        entUser.ID_PERFIL = int.Parse(lblidPerfilM.Text);
                        entUser.USU_MODIFICA = user;
                        entUser.FEC_MODIFICA = DateTime.Now;
                        entUser.FLG_ESTADO = "0";
                        exito = objUser.Eliminar_Usuario(entUser, ref auditoria);

                    }
                    else
                    {
                        
                        MessageBox.Show("Ocurrió un problema al eliminar el registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Limpiar();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            T_M_PERFIL entidad = new T_M_PERFIL();
            entidad.DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
            dataGridView1.DataSource = objMPerfil.Buscar_Perfil(entidad, ref auditoria);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //=======================================================
        //------------SECION DEL TAB PERFIL CONFIGURACION--------
        //=======================================================

        Cls_Rule_C_Perfil objCPerfil = new Cls_Rule_C_Perfil();

        private void BotonTab_Enabled(bool estado)
        {
            if (estado)
            {
                btnActualizarSeccion.Enabled = true;
                btnActualizarSeccion.BackColor = Color.SeaGreen;
                btnEliminarSeccion.Enabled = true;
                btnEliminarSeccion.BackColor = Color.SeaGreen;
            }
            else
            {
                btnActualizarSeccion.Enabled = false;
                btnActualizarSeccion.BackColor = Color.Gray;
                btnEliminarSeccion.Enabled = false;
                btnEliminarSeccion.BackColor = Color.Gray;
            }
        }

        private void LimpiarTab()
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lblIdConfig.Text = string.Empty;
            lblIdPerfil.Text = string.Empty;
            cmbPerfil.SelectedIndex = 0;
            cmbModulo.SelectedIndex = 0;
            btnGuardarSeccion.Enabled = true;
            BotonTab_Enabled(false);
            dataGridView2.DataSource = objCPerfil.Listar_Perfil(ref auditoria);
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
        }

        private void tabPerfil_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (tabPerfil.SelectedIndex == 1)
            {
                List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
                lista = objMPerfil.Listar_Perfil(ref auditoria).OrderBy(x => x.DESCRIPCION).ToList();
                lista.Insert(0, new T_M_PERFIL
                {
                    ID_PERFIL = 0,
                    DESCRIPCION = "-- SELECCIONE --"
                });
                cmbPerfil.DataSource = lista;
                cmbPerfil.DisplayMember = "DESCRIPCION";
                cmbPerfil.ValueMember = "ID_PERFIL";

                cmbModulo.Items.Clear();
                cmbModulo.Items.Add("-- SELECCIONE --");
                cmbModulo.Items.Add("ANULAR");
                cmbModulo.Items.Add("CARGO");
                cmbModulo.Items.Add("CONFIGURACIÓN");
                cmbModulo.Items.Add("CLIENTE");
                cmbModulo.Items.Add("PERSONAL");
                cmbModulo.Items.Add("PERFIL");
                cmbModulo.Items.Add("PRODUCTOS");
                cmbModulo.Items.Add("REPORTE");
                cmbModulo.Items.Add("SERVICIO");
                cmbModulo.Items.Add("USUARIO");
                cmbModulo.Items.Add("VENTAS");
                cmbModulo.SelectedIndex = 0;

                dataGridView2.DataSource = objCPerfil.Listar_Perfil(ref auditoria);
                dataGridView2.Columns["ID_CONFIG"].Visible = false;
                dataGridView2.Columns["ID_PERFIL"].Visible = false;
                dataGridView2.Columns["FLG_ESTADO"].Visible = false;
                dataGridView2.Columns["DESCRIPCION"].HeaderText = "MÓDULO";
                dataGridView2.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
                dataGridView2.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
                dataGridView2.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
                dataGridView2.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
                if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.SelectedRows[0].Selected = false;
                }
                BotonTab_Enabled(false);
            }
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                lblIdPerfil.Text = dataGridView2.CurrentRow.Cells["ID_PERFIL"].Value.ToString();
                lblIdConfig.Text = dataGridView2.CurrentRow.Cells["ID_CONFIG"].Value.ToString();
                lblUser.Text = dataGridView2.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFecha.Text = dataGridView2.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                cmbPerfil.Text = dataGridView2.CurrentRow.Cells["PERFIL"].Value.ToString();
                cmbModulo.Text = dataGridView2.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                lblFlagSeccion.Text = dataGridView2.CurrentRow.Cells["FLG_ESTADO"].Value.ToString();
                btnGuardarSeccion.Enabled = false;
                BotonTab_Enabled(true);
            }
            
        }

        private void btnGuardarSeccion_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if ((cmbPerfil.SelectedIndex > 0) && (cmbModulo.SelectedIndex > 0))
            {
                T_C_PERFIL entidadCPerfil = new T_C_PERFIL();
                bool exito = false;
                entidadCPerfil.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
                entidadCPerfil.DESCRIPCION = cmbModulo.SelectedItem.ToString();
                entidadCPerfil.USU_CREACION = user;
                entidadCPerfil.FEC_CREACION = DateTime.Now;
                entidadCPerfil.FLG_ESTADO = "1";

                exito = objCPerfil.Insertar_Perfil(entidadCPerfil, ref auditoria);
                if (exito)
                {
                    dataGridView2.DataSource = objCPerfil.Listar_Perfil(ref auditoria);
                    btnLimpiarSeccion_Click(sender, e);
                    MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El módulo ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione Perfil y Módulo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarSeccion_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            int idCfgPerfil;
            bool exito;
            if (lblIdPerfil.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((cmbPerfil.SelectedIndex > 0) && (cmbModulo.SelectedIndex > 0))
                {
                    T_C_PERFIL entidadCPerfil = new T_C_PERFIL();
                    idCfgPerfil = int.Parse(lblIdConfig.Text);
                    entidadCPerfil.ID_CONFIG = idCfgPerfil;
                    entidadCPerfil.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
                    entidadCPerfil.DESCRIPCION = cmbModulo.SelectedItem.ToString();
                    entidadCPerfil.USU_CREACION = lblUser.Text;
                    entidadCPerfil.FEC_CREACION = DateTime.Parse(lblFecha.Text);
                    entidadCPerfil.USU_MODIFICA = user;
                    entidadCPerfil.FEC_MODIFICA = DateTime.Now;
                    entidadCPerfil.FLG_ESTADO = lblFlagSeccion.Text;
                    exito = objCPerfil.Actualizar_Perfil(entidadCPerfil, ref auditoria);
                    if (exito)
                    {
                        LimpiarTab();
                        MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Módulo ya se encuentra asignado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Perfil y Módulo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminarSeccion_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (lblIdConfig.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                T_C_PERFIL entidadCPerfil = new T_C_PERFIL();
                entidadCPerfil.ID_CONFIG = int.Parse(lblIdConfig.Text);
                entidadCPerfil.FLG_ESTADO = "0";
                entidadCPerfil.USU_MODIFICA = user;
                entidadCPerfil.FEC_MODIFICA = DateTime.Now;
                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = objCPerfil.Eliminar_Perfil(entidadCPerfil, ref auditoria);
                    if (exito)
                    {
                        LimpiarTab();
                        MessageBox.Show("El registro ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void btnLimpiarSeccion_Click(object sender, EventArgs e)
        {
            LimpiarTab();
        }

        private void btnBuscarSeccion_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            T_C_PERFIL entidadCPerfil = new T_C_PERFIL();
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
                entidadCPerfil.ID_PERFIL = int.Parse(cmbPerfil.SelectedValue.ToString());
                entidadCPerfil.DESCRIPCION = cmbModulo.SelectedItem.ToString() == "-- SELECCIONE --" ? "" : cmbModulo.SelectedItem.ToString();
                lista = objCPerfil.Buscar_Perfil(entidadCPerfil, ref auditoria);
                dataGridView2.DataSource = lista;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void tpCPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
