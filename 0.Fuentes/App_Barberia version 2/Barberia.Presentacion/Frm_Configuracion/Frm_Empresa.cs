using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Cliente
{
    public partial class Frm_Empresa : Form
    {
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_Departamento ObjDepartamento = new Cls_Rule_Departamento();
        private Cls_Rule_Provincia ObjProvincia = new Cls_Rule_Provincia();
        private Cls_Rule_Distrito ObjDistrito = new Cls_Rule_Distrito();
        private Cls_Rule_Empresa ObjEmpresa = new Cls_Rule_Empresa();
        List<T_M_DISTRITO> lista = new List<T_M_DISTRITO>();
        Cls_Rule_V_Empresa objVEmpresa = new Cls_Rule_V_Empresa();

        string user; //usuario logeado
        public string retornoNombre;
        public Frm_Empresa(string usuario)
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
            lblIdEmpresa.Text = "";
            cmbDeparta.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            cmbDistrito.SelectedIndex = 0;
            errIconoError.Clear();
            dataGridView1.DataSource = objVEmpresa.Listar_Empresa(ref auditoria);
            dataGridView1.ClearSelection();
        }

        private void Frm_RegistrarCliente_Load(object sender, EventArgs e)
        {
            //List<V_CLIENTE> lisCliente = new List<V_CLIENTE>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<T_M_DEPARTAMENTO> departamento = new List<T_M_DEPARTAMENTO>();

            dataGridView1.DataSource = objVEmpresa.Listar_Empresa(ref auditoria);
            dataGridView1.Columns["ID_EMPRESA"].Visible = false;
            //dataGridView1.Columns["APELLIDO_PAT"].Visible = false;
            dataGridView1.Columns["NOM_COMERCIAL"].HeaderText = "NOMBRE COMERCIAL";
            dataGridView1.Columns["R_SOCIAL"].HeaderText = "RAZÓN SOCIAL";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            //.Columns["NUM_DOC"].HeaderText = "NÚMERO DOCUMENTO";
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRazonSocial.Text) && !string.IsNullOrEmpty(txtUbigeo.Text) && !string.IsNullOrEmpty(txtRuc.Text) && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0)
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                bool exito = false;
                T_M_EMPRESA entidad = new T_M_EMPRESA();
                    
                entidad.R_SOCIAL = txtRazonSocial.Text.Trim().ToUpper();
                entidad.RUC = txtRuc.Text.Trim().ToUpper();
                //retornoNombre = entidad.NOMBRES; //retorna el nombra para el form buscar
                entidad.NOM_COMERCIAL = txtNomComercial.Text.Trim().ToUpper();
                entidad.COD_DEPARTAMENTO = cmbDeparta.SelectedValue.ToString();
                entidad.COD_PROVINCIA = cmbProvincia.SelectedValue.ToString();
                entidad.COD_DISTRITO = cmbDistrito.SelectedValue.ToString();
                entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
                entidad.UBIGEO = txtUbigeo.Text;
                entidad.USU_CREACION = user;
                entidad.FEC_CREACION = DateTime.Now;
                entidad.FLG_ESTADO = "1";

                exito = ObjEmpresa.Insertar_Empresa(entidad, ref auditoria);

                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El ruc ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Rellene los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                errIconoError.Clear();
                lblIdEmpresa.Text = dataGridView1.CurrentRow.Cells["ID_EMPRESA"].Value.ToString();
                
                txtRazonSocial.Text = dataGridView1.CurrentRow.Cells["R_SOCIAL"].Value.ToString();
                txtNomComercial.Text = dataGridView1.CurrentRow.Cells["NOM_COMERCIAL"].Value.ToString();
                txtRuc.Text = dataGridView1.CurrentRow.Cells["RUC"].Value.ToString();
                txtUbigeo.Text = dataGridView1.CurrentRow.Cells["UBIGEO"].Value.ToString();
                cmbDeparta.Text = dataGridView1.CurrentRow.Cells["DEPARTAMENTO"].Value.ToString();
                cmbProvincia.Text = dataGridView1.CurrentRow.Cells["PROVINCIA"].Value.ToString();
                cmbDistrito.Text = dataGridView1.CurrentRow.Cells["DISTRITO"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                lblUserCreacion.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                lblFecCreacion.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                btnGuardar.Enabled = false;
                Boton_Enabled(true);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool exito = false;
            if (lblIdEmpresa.Text == "")
            {
                MessageBox.Show("Seleccione un registro.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                if (txtRuc.Text != "" && cmbDeparta.SelectedIndex > 0 && cmbProvincia.SelectedIndex > 0 && cmbDistrito.SelectedIndex > 0 && txtRazonSocial.Text != "")
                {
                    Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                    T_M_EMPRESA entidad = new T_M_EMPRESA();
                        entidad.ID_EMPRESA = int.Parse(lblIdEmpresa.Text);
                        entidad.R_SOCIAL = txtRazonSocial.Text.Trim().ToUpper();
                        entidad.RUC = txtRuc.Text.Trim().ToUpper();
                        entidad.NOM_COMERCIAL = txtNomComercial.Text.Trim().ToUpper();
                        entidad.COD_DEPARTAMENTO = cmbDeparta.SelectedValue.ToString();
                        entidad.COD_PROVINCIA = cmbProvincia.SelectedValue.ToString();
                        entidad.COD_DISTRITO = cmbDistrito.SelectedValue.ToString();
                        entidad.DIRECCION = txtDireccion.Text.Trim().ToUpper();
                        entidad.UBIGEO = txtUbigeo.Text;
                        entidad.USU_MODIFICA = user;
                        entidad.FEC_MODIFICA = DateTime.Now;
                        exito = ObjEmpresa.Actualizar_Empresa(entidad, ref auditoria);

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
                else
                {
                    MessageBox.Show("Rellene los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lblIdEmpresa.Text == "")
            {
                MessageBox.Show("Seleccione un registro", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                T_M_EMPRESA entidad = new T_M_EMPRESA();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entidad.ID_EMPRESA = int.Parse(lblIdEmpresa.Text);
                entidad.FLG_ESTADO = "0";
                entidad.USU_MODIFICA = user;
                entidad.FEC_MODIFICA = DateTime.Now;
                DialogResult res = MessageBox.Show("Desea eliminar este registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    bool exito = ObjEmpresa.Eliminar_Empresa(entidad, ref auditoria);

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

        private void keyPres(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private bool validar_DNI()
        {
            bool exito = true;

            if (txtRuc.Text.Length != 8)
                exito = false;

            return exito;
        }

        private bool validar_RUC()
        {
            bool exito = true;

            if (txtRuc.Text.Length != 11)
                exito = false;

            return exito;
        }

        private bool validar_UBIGEO()
        {
            bool exito = true;

            if (txtUbigeo.Text.Length < 5)
                exito = false;

            return exito;
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbDeparta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeparta.SelectedIndex > 0)
            {
                List<T_M_PROVINCIA> lista = new List<T_M_PROVINCIA>();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
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
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (cmbProvincia.SelectedIndex > 0)
            {
                
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

        
        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            if (validar_RUC())
                errIconoError.Clear();
            else
                errIconoError.SetError(txtRuc, "Ingresar 11 dígitos");
        }


        private void txtUbigeo_Validating(object sender, CancelEventArgs e)
        {
            if (validar_UBIGEO())
                errIconoError.Clear();
            else
                errIconoError.SetError(txtUbigeo, "Ingresar correctamente los dígitos");
        }

        private void txtUbigeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrito.SelectedIndex > 0)
            {
                foreach (var item in lista)
                {
                    if (item.DISTRITO == cmbDistrito.Text)
                    {
                        txtUbigeo.Text = item.UBIGEO;
                        break;
                    }
                    
                }
            }
            
            
        }

        private void txtUbigeo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
