using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Personal
{
    public partial class Frm_Personales : Form
    {
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Cargo ObjCargo = new Cls_Rule_Cargo();
        private Cls_Rule_V_Personal VistaPersonal = new Cls_Rule_V_Personal();
        private Cls_Rule_Departamento ObjDepartamento = new Cls_Rule_Departamento();
        private Cls_Rule_Provincia ObjProvincia = new Cls_Rule_Provincia();
        private Cls_Rule_Distrito ObjDistrito = new Cls_Rule_Distrito();
        private Cls_Rule_Tipo_Doc ObjTipoDoc = new Cls_Rule_Tipo_Doc();
        string user; //usuario logeado

        public Frm_Personales(string usuario)
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
            foreach (Control item in panel3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            cmbCargo.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            cmbDeparta.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            cmbDistrito.SelectedIndex = 0;
            Boton_Enabled(false);
            btnGuardar.Enabled = true;
            dataGridView1.DataSource = VistaPersonal.Listar_Personal(1, ref auditoria);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        private void Frm_Personal_Load(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<T_M_CARGO> lista = new List<T_M_CARGO>();
            List<T_TIPO_DOCUMENTO> lisTipoDoc = new List<T_TIPO_DOCUMENTO>();
            List<T_M_DEPARTAMENTO> departamento = new List<T_M_DEPARTAMENTO>();

            lista = ObjCargo.Listar_Cargo(1, ref auditoria).OrderBy(x => x.DESC_CARGO).ToList();
            
            lista.Insert(0, new T_M_CARGO()
            {
                ID_CARGO = 0,
                DESC_CARGO = "-- SELECCIONE --"
            });
            cmbCargo.DataSource = lista;
            cmbCargo.DisplayMember = "DESC_CARGO";
            cmbCargo.ValueMember = "ID_CARGO";
            
            dataGridView1.DataSource = VistaPersonal.Listar_Personal(1, ref auditoria);
            dataGridView1.Columns["ID_PERSONAL"].Visible = false;
            dataGridView1.Columns["APELLIDO_PAT"].Visible = false;
            dataGridView1.Columns["APELLIDO_MAT"].Visible = false;
            dataGridView1.Columns["NOMBRES"].Visible = false;
            //dataGridView1.Columns["FLG_ESTADO"].Visible = false;
            dataGridView1.Columns["DOCUMENTO"].HeaderText = "DOCUMENTO";
            dataGridView1.Columns["NUM_DOC"].HeaderText = "NÚMERO DOC.";
            dataGridView1.Columns["DESC_CARGO"].HeaderText = "CARGO";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            if (dataGridView1.Rows.Count > 0)
            {
                   dataGridView1.ClearSelection();

            }

            lisTipoDoc = ObjTipoDoc.Listar_Tipo_Doc(ref auditoria);
            lisTipoDoc.Insert(0, new T_TIPO_DOCUMENTO
            {
                COD_DOCUMENTO = "0",
                DOCUMENTO = "-- SELECCIONE --"
            });
            cmbTipoDoc.DataSource = lisTipoDoc;
            cmbTipoDoc.ValueMember = "COD_DOCUMENTO";
            cmbTipoDoc.DisplayMember = "DOCUMENTO";

            departamento = ObjDepartamento.Listar_Departamento(ref auditoria);
            departamento.Insert(0, new T_M_DEPARTAMENTO
            {
                COD_DEPARTAMENTO = "00",
                DEPARTAMENTO = "-- SELECCIONE --"
            });
            cmbDeparta.DataSource = departamento;
            cmbDeparta.ValueMember = "COD_DEPARTAMENTO";
            cmbDeparta.DisplayMember = "DEPARTAMENTO";
            cmbProvincia.SelectedIndex = 0;
            cmbDistrito.SelectedIndex = 0;

            Boton_Enabled(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellidoP.Text) && !string.IsNullOrEmpty(txtApellidoM.Text) && !string.IsNullOrEmpty(txtNumDoc.Text) && cmbCargo.SelectedIndex > 0 && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0 && cmbTipoDoc.SelectedIndex > 0)
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                T_M_PERSONAL entidad = new T_M_PERSONAL();
                    entidad.NOMBRES = txtNombre.Text.Trim().ToUpper();
                    entidad.APELLIDO_PAT = txtApellidoP.Text.Trim().ToUpper();
                    entidad.APELLIDO_MAT = txtApellidoM.Text.Trim().ToUpper();
                    entidad.TIPO_DOC = cmbTipoDoc.SelectedValue.ToString();
                    entidad.NUM_DOC = txtNumDoc.Text.Trim().ToUpper();
                    entidad.COD_DEPARTAMENTO = cmbDeparta.SelectedValue.ToString();
                    entidad.COD_PROVINCIA = cmbProvincia.SelectedValue.ToString();
                    entidad.COD_DISTRITO = cmbDistrito.SelectedValue.ToString();
                    entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
                    entidad.CORREO = txtCorreo.Text == "" ? "-" : txtCorreo.Text.Trim().ToUpper();
                    entidad.TELEFONO = txtTelefono.Text == "" ? "-" : txtTelefono.Text.Trim().ToUpper();
                    entidad.ID_CARGO = int.Parse(cmbCargo.SelectedValue.ToString());
                    entidad.FLG_ESTADO = "1";
                    entidad.USU_CREACION = user;
                    entidad.FEC_CREACION = DateTime.Now;
                    exito = ObjPersonal.Insertar_Personal(entidad, ref auditoria);
                    if (exito)
                    {
                        Limpiar();
                        MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El tipo y número de documento ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

            }
            else
            {
                MessageBox.Show("Rellene los campos restantes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                lblIdPersonal.Text = dataGridView1.CurrentRow.Cells["ID_PERSONAL"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRES"].Value.ToString();
                txtApellidoP.Text = dataGridView1.CurrentRow.Cells["APELLIDO_PAT"].Value.ToString();
                txtApellidoM.Text = dataGridView1.CurrentRow.Cells["APELLIDO_MAT"].Value.ToString();
                cmbTipoDoc.Text = dataGridView1.CurrentRow.Cells["DOCUMENTO"].Value.ToString();
                txtNumDoc.Text = dataGridView1.CurrentRow.Cells["NUM_DOC"].Value.ToString();
                cmbDeparta.Text = dataGridView1.CurrentRow.Cells["DEPARTAMENTO"].Value.ToString();
                cmbProvincia.Text = dataGridView1.CurrentRow.Cells["PROVINCIA"].Value.ToString();
                cmbDistrito.Text = dataGridView1.CurrentRow.Cells["DISTRITO"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["CORREO"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
                cmbCargo.Text = dataGridView1.CurrentRow.Cells["DESC_CARGO"].Value.ToString();
                //lblUserCreacion.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                //lblFecCreacion.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                //lblFlag.Text = dataGridView1.CurrentRow.Cells["FLG_ESTADO"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (lblIdPersonal.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellidoP.Text) && !string.IsNullOrEmpty(txtApellidoM.Text) && !string.IsNullOrEmpty(txtNumDoc.Text) && cmbCargo.SelectedIndex > 0 && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0 && cmbTipoDoc.SelectedIndex > 0)
                {
                    if (validar_DNI())
                    {
                        T_M_PERSONAL entidad = new T_M_PERSONAL();
                        entidad.ID_PERSONAL = int.Parse(lblIdPersonal.Text);
                        entidad.NOMBRES = txtNombre.Text.Trim().ToUpper();
                        entidad.APELLIDO_PAT = txtApellidoP.Text.Trim().ToUpper();
                        entidad.APELLIDO_MAT = txtApellidoM.Text.Trim().ToUpper();
                        entidad.TIPO_DOC = cmbTipoDoc.SelectedValue.ToString();
                        entidad.NUM_DOC = txtNumDoc.Text.Trim().ToUpper();
                        entidad.COD_DEPARTAMENTO = cmbDeparta.SelectedValue.ToString();
                        entidad.COD_PROVINCIA = cmbProvincia.SelectedValue.ToString();
                        entidad.COD_DISTRITO = cmbDistrito.SelectedValue.ToString();
                        entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
                        entidad.CORREO = txtCorreo.Text == "" ? "-" : txtCorreo.Text.Trim().ToUpper();
                        entidad.TELEFONO = txtTelefono.Text == "" ? "-" : txtTelefono.Text.Trim().ToUpper();
                        entidad.ID_CARGO = int.Parse(cmbCargo.SelectedValue.ToString());
                        //entidad.USU_CREACION = lblUserCreacion.Text;
                        //entidad.FEC_CREACION = DateTime.Parse(lblFecCreacion.Text);
                        entidad.USU_MODIFICA = user;
                        entidad.FEC_MODIFICA = DateTime.Now;
                        //entidad.FLG_ESTADO = "1";
                        exito = ObjPersonal.Actualizar_Personal(entidad, ref auditoria);
                        if (exito)
                        {
                            MessageBox.Show("El registro ha sido actualizado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = ObjPersonal.Listar_Personal(1, ref auditoria);
                        }
                        else
                        {
                            MessageBox.Show("El tipo y número de documento ya se encuentra registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El DNI debe tener 8 digitos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Los campos Nombres, Apellidos, Tipo doc., Num. doc. y Cargo es obligatorio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lblIdPersonal.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                T_M_PERSONAL entidad = new T_M_PERSONAL();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.ID_PERSONAL = int.Parse(lblIdPersonal.Text);
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                entidad.FLG_ESTADO = "0";
                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = ObjPersonal.Eliminar_Personal(entidad, ref auditoria);
                    if (exito)
                    {
                        Limpiar();
                        MessageBox.Show("El registro ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema al eliminar el registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            V_PERSONAL entidad = new V_PERSONAL();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entidad.NOMBRES = txtNombre.Text.Trim().ToUpper();
            entidad.APELLIDO_PAT = txtApellidoP.Text.Trim().ToUpper();
            entidad.APELLIDO_MAT = txtApellidoM.Text.Trim().ToUpper();
            entidad.DOCUMENTO = cmbTipoDoc.Text == "-- SELECCIONE --" ? "" : cmbTipoDoc.Text; 
            entidad.NUM_DOC = txtNumDoc.Text.Trim().ToUpper();
            entidad.DEPARTAMENTO = cmbDeparta.SelectedIndex == 0 ? "" : cmbDeparta.Text;
            entidad.PROVINCIA = cmbProvincia.SelectedIndex == 0 ? "" : cmbProvincia.Text;
            entidad.DISTRITO = cmbDistrito.SelectedIndex == 0 ? "" : cmbDistrito.Text;
            entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
            entidad.CORREO = txtCorreo.Text.Trim().ToUpper();
            entidad.TELEFONO = txtTelefono.Text.Trim().ToUpper();
            entidad.DESC_CARGO = cmbCargo.Text == "-- SELECCIONE --" ? "" : cmbCargo.Text;
            dataGridView1.DataSource = VistaPersonal.Buscar_Personal(entidad, ref auditoria);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void keyPres(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtNumDoc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbTipoDoc.SelectedValue.ToString() == "1")
            {
                if (validar_DNI())
                    errIconoError.Clear();
                else
                    errIconoError.SetError(txtNumDoc, "Ingresar 8 dígitos");
            }
            else if (cmbTipoDoc.SelectedValue.ToString() == "6")
            {
                if (validar_RUC())
                    errIconoError.Clear();
                else
                    errIconoError.SetError(txtNumDoc, "Ingresar 11 dígitos");
            }
        }

        private bool validar_DNI()
        {
            bool exito = true;
            if (cmbTipoDoc.Text == "DNI")
            {
                if (txtNumDoc.Text.Length != 8)
                {
                    exito = false;
                }
            }
            return exito;
        }

        private bool validar_RUC()
        {
            bool exito = true;

            if (txtNumDoc.Text.Length != 11)
                exito = false;

            return exito;
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbTipoDoc.SelectedValue.ToString() == "1")
                keyPres(e);
            else if (cmbTipoDoc.SelectedValue.ToString() == "6")
                keyPres(e);
        }

        private void cmbDeparta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeparta.SelectedIndex > 0)
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                List<T_M_PROVINCIA> lista = new List<T_M_PROVINCIA>();
                lista = ObjProvincia.Buscar_Provincia(cmbDeparta.SelectedValue.ToString(), ref auditoria);
                lista.Insert(0, new T_M_PROVINCIA
                {
                    COD_DEPARTAMENTO = "00",
                    PROVINCIA = "-- SELECCIONE --"
                });
                cmbProvincia.DataSource = lista;
                cmbProvincia.ValueMember = "COD_PROVINCIA";
                cmbProvincia.DisplayMember = "PROVINCIA";
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex > 0)
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                List<T_M_DISTRITO> lista = new List<T_M_DISTRITO>();
                lista = ObjDistrito.Buscar_Distrito(cmbDeparta.SelectedValue.ToString(), cmbProvincia.SelectedValue.ToString(), ref auditoria);
                lista.Insert(0, new T_M_DISTRITO
                {
                    COD_DISTRITO = "00",
                    DISTRITO = "-- SELECCIONE --"
                });
                cmbDistrito.DataSource = lista;
                cmbDistrito.ValueMember = "COD_DISTRITO";
                cmbDistrito.DisplayMember = "DISTRITO";
            }
        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errIconoError.Clear();
            txtNumDoc.Text = "";
            switch (cmbTipoDoc.SelectedValue.ToString())
            {
                case "1":
                    txtNumDoc.MaxLength = 8;
                    break;
                case "4":
                    txtNumDoc.MaxLength = 12;
                    break;
                case "6":
                    txtNumDoc.MaxLength = 11;
                    break;
                case "7":
                    txtNumDoc.MaxLength = 12;
                    break;
                default:
                    break;
            }
        }
    }
}
