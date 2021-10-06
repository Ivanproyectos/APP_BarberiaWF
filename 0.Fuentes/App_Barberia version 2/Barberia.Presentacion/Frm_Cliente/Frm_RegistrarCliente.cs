using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Cliente
{
    public partial class Frm_RegistrarCliente : Form
    {
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_Departamento ObjDepartamento = new Cls_Rule_Departamento();
        private Cls_Rule_Provincia ObjProvincia = new Cls_Rule_Provincia();
        private Cls_Rule_Distrito ObjDistrito = new Cls_Rule_Distrito(); 
        private Cls_Rule_Tipo_Per ObjTipoPer = new Cls_Rule_Tipo_Per();
        private Cls_Rule_Tipo_Doc ObjTipoDoc = new Cls_Rule_Tipo_Doc();
        string user; //usuario logeado
        public string retornoNombre;
        int[] posicion = new int[4];
        public Frm_RegistrarCliente(string usuario)
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
            foreach (Control item in pnlContenedor.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            Boton_Enabled(false);
            btnGuardar.Enabled = true;
            lblIdCliente.Text = "";
            cmbTipoPersona.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            cmbDeparta.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            cmbDistrito.SelectedIndex = 0;
            errIconoError.Clear();
            dataGridView1.DataSource = ObjVCliente.Listar_V_Cliente(1,ref auditoria);
            dataGridView1.ClearSelection();
        }

        private void Frm_RegistrarCliente_Load(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            //List<V_CLIENTE> lisCliente = new List<V_CLIENTE>();
            List<T_M_DEPARTAMENTO> departamento = new List<T_M_DEPARTAMENTO>();
            List<T_TIPO_PERSONA> lisTipoPer = new List<T_TIPO_PERSONA>();
            List<T_TIPO_DOCUMENTO> lisTipoDoc = new List<T_TIPO_DOCUMENTO>();

            lisTipoPer = ObjTipoPer.Listar_Tipo_Per(ref auditoria);
            lisTipoPer.Insert(0, new T_TIPO_PERSONA
            {
                COD_TIPO_PERSONA = "0",
                PERSONA = "-- SELECCIONE --"
            });
            cmbTipoPersona.DataSource = lisTipoPer;
            cmbTipoPersona.ValueMember = "COD_TIPO_PERSONA";
            cmbTipoPersona.DisplayMember = "PERSONA";

            lisTipoDoc = ObjTipoDoc.Listar_Tipo_Doc(ref auditoria);
            lisTipoDoc.Insert(0, new T_TIPO_DOCUMENTO
            {
                COD_DOCUMENTO = "0",
                DOCUMENTO = "-- SELECCIONE --"
            });
            cmbTipoDoc.DataSource = lisTipoDoc;
            cmbTipoDoc.ValueMember = "COD_DOCUMENTO";
            cmbTipoDoc.DisplayMember = "DOCUMENTO";

            dataGridView1.DataSource = ObjVCliente.Listar_V_Cliente(1,ref auditoria);
            dataGridView1.Columns["ID_CLIENTE"].Visible = false;
            dataGridView1.Columns["APELLIDO_PAT"].Visible = false;
            dataGridView1.Columns["APELLIDO_MAT"].Visible = false;
            dataGridView1.Columns["R_SOCIAL"].Visible = false;
            dataGridView1.Columns["NOMBRES"].Visible = false;
            dataGridView1.Columns["PERSONA"].HeaderText = "TIPO PERSONA";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["NUM_DOC"].HeaderText = "NÚMERO DOCUMENTO";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            dataGridView1.ClearSelection();
            Boton_Enabled(false);

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
            //posicion cuando se ocultan los input
            posicion[0] = lblTipoDoc.Top;
            posicion[1] = cmbTipoDoc.Top;
            posicion[2] = lblNumDoc.Top;
            posicion[3] = txtNumDoc.Top;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtNumDoc.Text) && cmbTipoDoc.SelectedIndex > 0 && cmbTipoPersona.SelectedIndex > 0 && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0)
            {

                    bool exito = false;
                    T_M_CLIENTES entidad = new T_M_CLIENTES();
                    Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                    entidad.TIPO_PERSONA = cmbTipoPersona.SelectedValue.ToString();
                    entidad.R_SOCIAL = txtRazonSocial.Text.Trim().ToUpper();
                    entidad.NOMBRES = txtNombre.Text.Trim().ToUpper();
                    retornoNombre = entidad.NOMBRES; //retorna el nombra para el form buscar
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
                    entidad.USU_CREACION = user;
                    entidad.FEC_CREACION = DateTime.Now;
                    entidad.FLG_ESTADO = "1";

                    exito = ObjCliente.Insertar_Clientes(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        if (auditoria.RECHAZAR)
                        {
                            Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                            MessageBox.Show("Ocurrió un problema al guardar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    
                    }
                    else
                    {
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

            }
            else
            {
                MessageBox.Show("Los campos Nombres, Apellidos, Tipo doc. y Num. doc. son obligatorio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                errIconoError.Clear();
                lblIdCliente.Text = dataGridView1.CurrentRow.Cells["ID_CLIENTE"].Value.ToString();
                cmbTipoPersona.Text = dataGridView1.CurrentRow.Cells["PERSONA"].Value.ToString();
                txtRazonSocial.Text = dataGridView1.CurrentRow.Cells["R_SOCIAL"].Value.ToString();
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
                lblUserCreacion.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFecCreacion.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            if (lblIdCliente.Text == "")
            {
                MessageBox.Show("Seleccione un registro.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                if (cmbTipoDoc.SelectedIndex > 0 && txtNumDoc.Text != "" && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0)
                {

                        Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                        T_M_CLIENTES entidad = new T_M_CLIENTES();
                        entidad.TIPO_PERSONA = cmbTipoPersona.SelectedValue.ToString();
                        entidad.R_SOCIAL = txtRazonSocial.Text.Trim().ToUpper();
                        entidad.ID_CLIENTE = int.Parse(lblIdCliente.Text);
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
                        entidad.USU_MODIFICA = user;
                        entidad.FEC_MODIFICA = DateTime.Now;
                        exito = ObjCliente.Actualizar_Clientes(entidad, ref auditoria);
                        if (!auditoria.EJECUCION_PROCEDIMIENTO)
                        {
                            if (auditoria.RECHAZAR)
                            {
                                Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                                MessageBox.Show("Ocurrió un problema al actualizar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }   
                        }
                        else
                        {
                            if (exito)
                            {
                                Limpiar();
                                MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El tipo y número de documento ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        

                }
                else
                {
                    MessageBox.Show("Ingrese número y tipo de documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lblIdCliente.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                T_M_CLIENTES entidad = new T_M_CLIENTES();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.ID_CLIENTE = int.Parse(lblIdCliente.Text);
                entidad.FLG_ESTADO = "0";
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = ObjCliente.Eliminar_Clientes(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        if (auditoria.RECHAZAR)
                        {
                            Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                            MessageBox.Show("Ocurrió un problema al eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }  
                    }
                    else
                    {
                        if (exito)
                        {
                            Limpiar();
                            MessageBox.Show("El registro ha sido eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
            V_CLIENTE entidad = new V_CLIENTE();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entidad.PERSONA = cmbTipoPersona.SelectedIndex == 0 ? "" : cmbTipoPersona.Text;
            entidad.R_SOCIAL = txtRazonSocial.Text == "-" ? "" : txtRazonSocial.Text.Trim().ToUpper();
            entidad.NOMBRES = txtNombre.Text.Trim().ToUpper();
            entidad.APELLIDO_PAT = txtApellidoP.Text.Trim().ToUpper();
            entidad.APELLIDO_MAT = txtApellidoM.Text.Trim().ToUpper();
            entidad.DOCUMENTO = cmbTipoDoc.Text == "-- SELECCIONE --" ? "" : cmbTipoDoc.Text;
            entidad.NUM_DOC = txtNumDoc.Text.Trim().ToUpper();
            entidad.DEPARTAMENTO = cmbDeparta.SelectedIndex == 0 ? "" : cmbDeparta.Text;
            entidad.PROVINCIA = cmbProvincia.SelectedIndex == 0 ? "" : cmbProvincia.Text;
            entidad.DISTRITO = cmbDistrito.SelectedIndex == 0 ? "" : cmbDistrito.Text;
            entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
            entidad.CORREO = txtCorreo.Text == "-" ? "" : txtCorreo.Text.Trim().ToUpper();
            entidad.TELEFONO = txtTelefono.Text == "-" ? "" : txtTelefono.Text.Trim().ToUpper();
            dataGridView1.DataSource = ObjVCliente.Buscar_V_Cliente(entidad, ref auditoria);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }


        private void keyPres(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void txtNumDoc_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoDoc.SelectedValue.ToString() == "1")
            {
                if (validar_DNI())
                    errIconoError.Clear();
                else
                    errIconoError.SetError(txtNumDoc, "Ingresar 8 dígitos");
            }
            else if(cmbTipoDoc.SelectedValue.ToString() == "6")
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

            if (txtNumDoc.Text.Length != 8)
                exito = false;

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

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

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

        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTipoPersona.Text == "JURIDICA")
            {
                OcultarNatural();
            }
            else if (cmbTipoPersona.Text == "NATURAL")
            {

                OcultarJuridica();
            }
        }

        void OcultarNatural()
        {
            lblRazonS.Visible = true;
            txtRazonSocial.Visible = true;
            lblNombres.Visible = false;
            lblApellidoP.Visible = false;
            lblApellidoM.Visible = false;
            txtNombre.Visible = false;
            txtApellidoP.Visible = false;
            txtApellidoM.Visible = false;
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            cmbTipoDoc.Text = "RUC";
            //posicion[0] = lblTipoDoc.Top;
            //posicion[1] = cmbTipoDoc.Top;
            //posicion[2] = lblNumDoc.Top;
            //posicion[3] = txtNumDoc.Top;
            lblTipoDoc.Top = lblNombres.Top;
            lblNumDoc.Top = lblApellidoP.Top;
            cmbTipoDoc.Top = txtNombre.Top;
            txtNumDoc.Top = txtApellidoP.Top;
        }

        void OcultarJuridica()
        {
            pnlInput.Top = txtRazonSocial.Top;
            lblNombres.Visible = true;
            lblApellidoP.Visible = true;
            lblApellidoM.Visible = true;
            lblRazonS.Visible = false;
            txtRazonSocial.Visible = false;
            txtRazonSocial.Text = "";
            txtNombre.Visible = true;
            txtApellidoP.Visible = true;
            txtApellidoM.Visible = true;
            lblTipoDoc.Top = posicion[0];
            cmbTipoDoc.Top = posicion[1];
            lblNumDoc.Top = posicion[2];
            txtNumDoc.Top = posicion[3];
            cmbTipoDoc.Text = "DNI";
        }

    }
}
