using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Ventas
{
    public partial class Frm_Comprobantes : Form
    {

        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_V_M_Venta ObjVMVenta = new Cls_Rule_V_M_Venta();


        //string user; //usuario logeado
        public string retornoNombre;
        public Frm_Comprobantes()
        {
            InitializeComponent();
            //user = usuario;
        }


        private void Limpiar()
        {

            lblIdEmpresa.Text = "";
            cmbTipoDoc.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            txtCorrelativo.Text = "";
            errIconoError.Clear();
            dataGridView1.DataSource = null;
            //dataGridView1.ClearSelection();
        }

        private void Frm_Comprobantes_Load(object sender, EventArgs e)
        {
            //List<V_CLIENTE> lisCliente = new List<V_CLIENTE>();
            cmbTipoDoc.Items.Add("-- SELECCIONE --");
            cmbTipoDoc.Items.Add("FACTURA");
            cmbTipoDoc.Items.Add("BOLETA");
            cmbTipoDoc.SelectedIndex = 0;

            List<V_CLIENTE> lisVCliente = new List<V_CLIENTE>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lisVCliente = ObjVCliente.Listar_V_Cliente(1,ref auditoria);
            lisVCliente.Insert(0, new V_CLIENTE
            {
                ID_CLIENTE = 0,
                NOMBRE = "-- SELECCIONE --"
            });
            cmbCliente.DataSource = lisVCliente;
            cmbCliente.DisplayMember = "NOMBRE";
            cmbCliente.ValueMember = "ID_CLIENTE";
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //errIconoError.Clear();
                //lblIdEmpresa.Text = dataGridView1.CurrentRow.Cells["ID_EMPRESA"].Value.ToString();
                
                //txtCorrelativo.Text = dataGridView1.CurrentRow.Cells["R_SOCIAL"].Value.ToString();
                //txtNomComercial.Text = dataGridView1.CurrentRow.Cells["NOM_COMERCIAL"].Value.ToString();
                //txtRuc.Text = dataGridView1.CurrentRow.Cells["RUC"].Value.ToString();
                //txtUbigeo.Text = dataGridView1.CurrentRow.Cells["UBIGEO"].Value.ToString();
                //cmbDeparta.Text = dataGridView1.CurrentRow.Cells["DEPARTAMENTO"].Value.ToString();
                //cmbProvincia.Text = dataGridView1.CurrentRow.Cells["PROVINCIA"].Value.ToString();
                //cmbDistrito.Text = dataGridView1.CurrentRow.Cells["DISTRITO"].Value.ToString();
                //txtDireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                //lblUserCreacion.Text = dataGridView1.CurrentRow.Cells["USU_CREACION"].Value.ToString();
                //lblFecCreacion.Text = dataGridView1.CurrentRow.Cells["FEC_CREACION"].Value.ToString();
                //btnGuardar.Enabled = false;
                //Boton_Enabled(true);
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

        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<V_M_VENTA> listVVenta = new List<V_M_VENTA>();
            V_M_VENTA entVMVenta = new V_M_VENTA();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            string fechaInicio, fechaFin;
            string serie = "";

            fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");
            if (cmbTipoDoc.Text == "FACTURA")
                serie = "F001-";
            else if (cmbTipoDoc.Text == "BOLETA")
                serie = "BE01-";
            entVMVenta.CLIENTE = cmbCliente.SelectedIndex == 0 ? "" : cmbCliente.Text;
            entVMVenta.VOUCHER = serie + txtCorrelativo.Text;
            listVVenta = ObjVMVenta.Buscar_Venta(entVMVenta, fechaInicio, fechaFin, ref auditoria);
            DataGridViewImageColumn colunm_img;
            colunm_img = new DataGridViewImageColumn();
            colunm_img.Name = "pdf";
            colunm_img.HeaderText = "PDF";
            //colunm_img.Image = Image.FromFile(@"C:\Users\yordan\Desktop\App_Barberia version 2\Barberia.Presentacion\icono\boton\pdf4.png");
            colunm_img.Image = Properties.Resources.pdf4;
            dataGridView1.Columns.Add(colunm_img);

            colunm_img = new DataGridViewImageColumn();
            colunm_img.Name = "xml";
            colunm_img.HeaderText = "XML";
            //colunm_img.Image = Image.FromFile(@"C:\Users\yordan\Desktop\App_Barberia version 2\Barberia.Presentacion\icono\boton\xml.png");
            colunm_img.Image = Properties.Resources.xml;
            dataGridView1.Columns.Add(colunm_img);
            dataGridView1.DataSource = listVVenta;
            dataGridView1.Columns["ID_VENTA"].Visible = false;
            dataGridView1.Columns["PERSONAL"].Visible = false;
            dataGridView1.Columns["CODIGO_FILE"].Visible = false;
            dataGridView1.Columns["EXTENSION_FILE"].Visible = false;
            dataGridView1.Columns["VOUCHER"].HeaderText = "COMPROBANTE";
            dataGridView1.Columns["TOTAL_IMPORTE"].HeaderText = "IMPORTE";
            dataGridView1.Columns["DESCT_TOTAL"].HeaderText = "DESCUENTO";
            dataGridView1.Columns["NOMBRE_FILE"].HeaderText = "NOMBRE ARCHIVO";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string file;
                if (e.ColumnIndex == 0)
                {
                    file = dataGridView1.CurrentRow.Cells["NOMBRE_FILE"].Value.ToString() + "." +dataGridView1.CurrentRow.Cells["EXTENSION_FILE"].Value.ToString().Substring(0,3);
                }
                else if (e.ColumnIndex == 1)
                {

                }
            }
            
        }
    }
}
