using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Productos
{
    public partial class Frm_ActualizarStock : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        ArrayList _parametro;
        Cls_Rule_Marca objMarca = new Cls_Rule_Marca();
        Cls_Rule_Modelo objModelo = new Cls_Rule_Modelo();
        Cls_Rule_UndMedida objUndMedida = new Cls_Rule_UndMedida();
        Cls_Rule_Act_Stock objActStock = new Cls_Rule_Act_Stock();

        public ArrayList datosForm = new ArrayList();
        Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
        public Frm_ActualizarStock(ArrayList parametro)
        {
            InitializeComponent();
            _parametro = parametro;
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
            //errIconoError.Clear();

            txtProducto.Text = _parametro[1].ToString();
            cmbMarca.SelectedValue = int.Parse(_parametro[2].ToString());
            cmbModelo.SelectedValue = int.Parse(_parametro[3].ToString());
            cmbUndMedida.SelectedValue = int.Parse(_parametro[4].ToString());


        }

        private void Frm_ActualizarStock_Load(object sender, EventArgs e)
        {
            List<T_M_MARCA> lisMarca = new List<T_M_MARCA>();
            List<T_M_MODELO> lisModelo = new List<T_M_MODELO>();
            List<T_M_UNIDAD_MEDIDA> lisUndMedida = new List<T_M_UNIDAD_MEDIDA>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lisMarca = objMarca.Listar_Marca(1,ref auditoria).Select(x => new T_M_MARCA
            {
                DES_MARCA = x.DES_MARCA,
                ID_MARCA = x.ID_MARCA
            }).ToList();
            cmbMarca.DataSource = lisMarca;
            lisMarca.Insert(0, new T_M_MARCA
            {
                ID_MARCA = 0,
                DES_MARCA = "-- SELECCIONE --"
            });
            cmbMarca.DisplayMember = "DES_MARCA";
            cmbMarca.ValueMember = "ID_MARCA";
            cmbMarca.SelectedIndex = 0;

            lisModelo = objModelo.Listar_Modelo(1,ref auditoria).Select(x => new T_M_MODELO
            {
                DES_MODELO = x.DES_MODELO,
                ID_MODELO = x.ID_MODELO
            }).ToList();
            cmbModelo.DataSource = lisModelo;
            lisModelo.Insert(0, new T_M_MODELO
            {
                ID_MODELO = 0,
                DES_MODELO = "-- SELECCIONE --"
            });
            cmbModelo.DisplayMember = "DES_MODELO";
            cmbModelo.ValueMember = "ID_MODELO";
            cmbModelo.SelectedIndex = 0;

            lisUndMedida = objUndMedida.Listar_UndMedida(1,ref auditoria).Select(x => new T_M_UNIDAD_MEDIDA
            {
                DES_UNIDAD_MEDIDA = x.DES_UNIDAD_MEDIDA,
                ID_UNIDAD_MEDIDA = x.ID_UNIDAD_MEDIDA
            }).ToList();
            cmbUndMedida.DataSource = lisUndMedida;
            lisUndMedida.Insert(0, new T_M_UNIDAD_MEDIDA
            {
                ID_UNIDAD_MEDIDA = 0,
                DES_UNIDAD_MEDIDA = "-- SELECCIONE --"
            });
            cmbUndMedida.DisplayMember = "DES_UNIDAD_MEDIDA";
            cmbUndMedida.ValueMember = "ID_UNIDAD_MEDIDA";


            txtProducto.Text = _parametro[1].ToString();
            cmbMarca.SelectedValue = int.Parse(_parametro[2].ToString());
            cmbModelo.SelectedValue = int.Parse(_parametro[3].ToString());
            cmbUndMedida.SelectedValue = int.Parse(_parametro[4].ToString());
        }


        private void picCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                bool exito;
                if (txtFactura.Text == "" && txtGuia.Text == "" && txtNroBoleta.Text == "")
                {
                    MessageBox.Show("Rellene uno de los campos : factura, guía, boleta ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtCantidad.Text == "" || txtPrecCompra.Text == ""
                    || txtPrecVenta.Text == "" || (cmbMarca.SelectedIndex == 0 || cmbModelo.SelectedIndex == 0 || cmbUndMedida.SelectedIndex == 0))
                    {
                        MessageBox.Show("Rellene los campos faltantes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        bool parse = decimal.TryParse(txtPrecCompra.Text, out decimal lol);
                        bool parse2 = decimal.TryParse(txtPrecVenta.Text, out decimal lol2);
                        if (!parse || !parse2)
                        {
                            MessageBox.Show("Ingrese un valor valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            
                            T_ACTUALIZAR_STOCK entActStock = new T_ACTUALIZAR_STOCK();
                            int nuevoStock = int.Parse(txtCantidad.Text) + (int)_parametro[5];
                            entActStock.PRODUCTO = _parametro[1].ToString();
                            entActStock.FACTURA = txtFactura.Text;
                            entActStock.GUIA = txtGuia.Text;
                            entActStock.NRO_BOLETA = txtNroBoleta.Text;
                            entActStock.MARCA = cmbMarca.Text;
                            entActStock.MODELO = cmbModelo.Text;
                            entActStock.UND_MEDIDA = cmbUndMedida.Text;
                            entActStock.CANTIDAD = int.Parse(txtCantidad.Text);
                            entActStock.PRE_COMPRA = decimal.Parse(txtPrecCompra.Text);
                            entActStock.PRE_VENTA_UND = decimal.Parse(txtPrecVenta.Text);
                            entActStock.FEC_OPERACION = dtpFecha.Value;
                            entActStock.USER_OPERACION = _parametro[6].ToString();
                            entActStock.FLG_ESTADO = "1";

                            exito = objActStock.Insertar_Act_Stock(entActStock, ref auditoria);
                            if (exito)
                            {
                                T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
                                //objProducto.NuevoStock_Producto((int)_parametro[0], nuevoStock);
                                entProducto.ID_PRODUCTO = (int)_parametro[0];
                                entProducto.PRODUCTO = txtProducto.Text;
                                entProducto.ID_MARCA = int.Parse(cmbMarca.SelectedValue.ToString());
                                entProducto.ID_MODELO = int.Parse(cmbModelo.SelectedValue.ToString());
                                entProducto.ID_UNIDAD_MEDIDA = int.Parse(cmbUndMedida.SelectedValue.ToString());
                                entProducto.STOCK = nuevoStock;
                                entProducto.PRECIO_COMPRA = decimal.Parse(txtPrecCompra.Text);
                                entProducto.PRECIO_VENTA = decimal.Parse(txtPrecVenta.Text);
                                entProducto.FEC_COMPRA = dtpFecha.Value;
                                entProducto.USU_MODIFICA = _parametro[6].ToString();
                                entProducto.FEC_MODIFICA = DateTime.Now;
                                objProducto.Actualizar_Producto(entProducto, ref auditoria);
                                Limpiar();
                                MessageBox.Show("El stock ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) ||  e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtPrecCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtPrecVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
