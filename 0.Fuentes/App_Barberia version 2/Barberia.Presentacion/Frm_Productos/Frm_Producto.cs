using Barberia.Entidad;
using Barberia.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Productos
{
    public partial class Frm_Producto : Form
    {
        Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
        Cls_Rule_Marca objMarca = new Cls_Rule_Marca();
        Cls_Rule_Modelo objModelo = new Cls_Rule_Modelo();
        Cls_Rule_UndMedida objUndMedida = new Cls_Rule_UndMedida();

        string nombre_file = "";
        string user; //usuario logeado
        string _perfil;
        private void Boton_Enabled(bool estado)
        {
            if (estado)
            {
                btnActualizar.Enabled = true;
                btnActualizar.BackColor = Color.SeaGreen;
                btnActualizaDatos.Enabled = true;
                btnActualizaDatos.BackColor = Color.SeaGreen;
                btnEliminar.Enabled = true;
                btnEliminar.BackColor = Color.SeaGreen;
            }
            else
            {
                btnActualizar.Enabled = false;
                btnActualizar.BackColor = Color.Gray;
                btnActualizaDatos.Enabled = false;
                btnActualizaDatos.BackColor = Color.Gray;
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
            dtpFecha.Value = DateTime.Now;
            cmbMarca.SelectedIndex = 0;
            cmbModelo.SelectedIndex = 0;
            cmbUndMedida.SelectedIndex = 0;
            dataGridView1.DataSource = objProducto.Listar_Producto(1,ref auditoria);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            picImagen.Image = null;
            btnGuardar.Enabled = true;
            txtStock.BackColor = Color.White;
            txtStock.ReadOnly = false;
            nombre_file = "";
        }

        public byte[] ImageToByteArray(System.Drawing.Image images)
        {
            using (var _memorystream = new MemoryStream())
            {
                images.Save(_memorystream, images.RawFormat);
                return _memorystream.ToArray();
            }
        }

        public Frm_Producto(string usuario, string perfil)
        {
            InitializeComponent();
            user = usuario;
            _perfil = perfil;
        }

        private void Frm_Producto_Load(object sender, EventArgs e)
        {
            List<T_M_MARCA> lisMarca = new List<T_M_MARCA>();
            List<T_M_MODELO> lisModelo = new List<T_M_MODELO>();
            List<T_M_UNIDAD_MEDIDA> lisUndMedida = new List<T_M_UNIDAD_MEDIDA>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lisMarca = objMarca.Listar_Marca(1,ref auditoria).OrderBy(x => x.DES_MARCA).Select(x => new T_M_MARCA
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

            lisModelo = objModelo.Listar_Modelo(1,ref auditoria).OrderBy(x => x.DES_MODELO).Select(x => new T_M_MODELO
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

            lisUndMedida = objUndMedida.Listar_UndMedida(1,ref auditoria).OrderBy(x => x.DES_UNIDAD_MEDIDA).Select(x => new T_M_UNIDAD_MEDIDA
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
            cmbUndMedida.SelectedIndex = 0;

            dataGridView1.DataSource = objProducto.Listar_Producto(1,ref auditoria);
            dataGridView1.Columns["ID_PRODUCTO"].Visible = false;
            dataGridView1.Columns["FLG_ESTADO"].Visible = false;
            dataGridView1.Columns["ID_UNIDAD_MEDIDA"].Visible = false;
            dataGridView1.Columns["ID_MODELO"].Visible = false;
            dataGridView1.Columns["ID_MARCA"].Visible = false;
            dataGridView1.Columns["RUTA"].Visible = false;
            dataGridView1.Columns["COD_PRODUCTO"].HeaderText = "CÓDIGO";
            dataGridView1.Columns["PRECIO_COMPRA"].HeaderText = "PRECIO COMPRA";
            dataGridView1.Columns["PRECIO_VENTA"].HeaderText = "PRECIO VENTA";
            dataGridView1.Columns["FEC_COMPRA"].HeaderText = "FECHA COMPRA";
            dataGridView1.Columns["NOM_FILE"].HeaderText = "NOMBRE ARCHIVO";
            dataGridView1.Columns["USU_CREACION"].HeaderText = "USUARIO CREACIÓN";
            dataGridView1.Columns["FEC_CREACION"].HeaderText = "FECHA CREACIÓN";
            dataGridView1.Columns["USU_MODIFICA"].HeaderText = "USUARIO MODIFICA";
            dataGridView1.Columns["FEC_MODIFICA"].HeaderText = "FECHA MODIFICA";
            Boton_Enabled(false);
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd-MM-yyyy hh:mm:ss";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            byte[] arrayByte;
            bool exito;
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            ImageConverter convert = new ImageConverter();
            if (txtCodigo.Text == "" || txtDescripcion.Text == "" || cmbMarca.SelectedIndex == 0 || cmbModelo.SelectedIndex == 0 || cmbUndMedida.SelectedIndex == 0 || txtStock.Text == "" || txtPrecCompra.Text == "" || txtPrecVenta.Text == "")
            {
                MessageBox.Show("Rellene todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entProducto.COD_PRODUCTO = txtCodigo.Text.Trim().ToUpper();
                entProducto.PRODUCTO = txtDescripcion.Text.Trim().ToUpper();
                entProducto.ID_MARCA = int.Parse(cmbMarca.SelectedValue.ToString());
                entProducto.ID_MODELO = int.Parse(cmbModelo.SelectedValue.ToString());
                entProducto.ID_UNIDAD_MEDIDA = int.Parse(cmbUndMedida.SelectedValue.ToString());
                entProducto.STOCK = int.Parse(txtStock.Text);
                entProducto.PRECIO_COMPRA = decimal.Parse(txtPrecCompra.Text);
                entProducto.PRECIO_VENTA = decimal.Parse(txtPrecVenta.Text);
                entProducto.FEC_COMPRA = dtpFecha.Value;
                entProducto.USU_CREACION = user;
                entProducto.FEC_CREACION = DateTime.Now;
                entProducto.FLG_ESTADO = "1";
                if (picImagen.Image != null)
                {
                    //string nombre_file = ofdImagen.SafeFileName;
                    arrayByte = (byte[])convert.ConvertTo(picImagen.Image, typeof(byte[]));

                    //string ruta = ConfigurationManager.AppSettings["Carpeta_Imagen"].ToString();
                    //if (ruta == "")
                    //{
                    //    ruta = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\Imagenes\\");
                    //}
                    string ruta = ConfigurationManager.AppSettings["Carpeta_Imagen"].ToString();
                    ruta += nombre_file;
                    File.WriteAllBytes(ruta, arrayByte);
                    entProducto.NOM_FILE = nombre_file;
                    entProducto.RUTA = ruta;
                    
                }
                exito = objProducto.Insertar_Producto(entProducto, ref auditoria);
                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El producto ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            //DialogResult resp;
            //resp = ofdImagen.ShowDialog();
            //if (resp == DialogResult.OK)
            //{
            //    picImagen.Image = Image.FromStream(ofdImagen.OpenFile());
            //}
            //ofdImagen.Dispose();
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {

                openFileDialog1.Title = "SUBIR IMAGEN";
                openFileDialog1.Filter = "Imagen  (*.jpg; *.png)| *.jpg; *.png";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    picImagen.Image = Image.FromStream(openFileDialog1.OpenFile());
                    nombre_file = openFileDialog1.SafeFileName;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string rutaImagen = "";
                if (_perfil != "ADMINISTRADOR")
                {
                    txtStock.BackColor = Color.Silver;
                    txtStock.ReadOnly = true;
                    Boton_Enabled(true);
                    btnActualizar.Enabled = false;
                    btnActualizar.BackColor = Color.Gray;
                }
                else
                {
                    Boton_Enabled(true);
                }
                
                lblIdProducto.Text = dataGridView1.CurrentRow.Cells["ID_PRODUCTO"].Value.ToString();
                txtCodigo.Text = dataGridView1.CurrentRow.Cells["COD_PRODUCTO"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                cmbMarca.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells["ID_MARCA"].Value.ToString());
                cmbModelo.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells["ID_MODELO"].Value.ToString());
                cmbUndMedida.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells["ID_UNIDAD_MEDIDA"].Value.ToString());
                txtStock.Text = dataGridView1.CurrentRow.Cells["STOCK"].Value.ToString();
                txtPrecCompra.Text = dataGridView1.CurrentRow.Cells["PRECIO_COMPRA"].Value.ToString();
                txtPrecVenta.Text = dataGridView1.CurrentRow.Cells["PRECIO_VENTA"].Value.ToString();
                dtpFecha.Value = (DateTime)dataGridView1.CurrentRow.Cells["FEC_COMPRA"].Value;
                if (dataGridView1.CurrentRow.Cells["RUTA"].Value != null)
                {
                    rutaImagen = dataGridView1.CurrentRow.Cells["RUTA"].Value.ToString();
                    //picImagen.Image = Image.FromFile(dataGridView1.CurrentRow.Cells["RUTA"].Value.ToString());
                    //picImagen.Image = new Bitmap(Image.FromFile(dataGridView1.CurrentRow.Cells["RUTA"].Value.ToString())); // solucion al error de el proceso no puede tener acceso
                    if (File.Exists(rutaImagen))
                    {
                        FileStream fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                        picImagen.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }
                    else
                    {
                        MessageBox.Show("La imagen no existe de la ruta : " + rutaImagen, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    picImagen.Image = null;
                }
                
                btnGuardar.Enabled = false;
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
            ArrayList lista = new ArrayList();
            lista.Add(int.Parse(lblIdProducto.Text));
            lista.Add(txtDescripcion.Text);
            lista.Add(int.Parse(dataGridView1.CurrentRow.Cells["ID_MARCA"].Value.ToString()));
            lista.Add(int.Parse(dataGridView1.CurrentRow.Cells["ID_MODELO"].Value.ToString()));
            lista.Add(int.Parse(dataGridView1.CurrentRow.Cells["ID_UNIDAD_MEDIDA"].Value.ToString()));
            lista.Add(int.Parse(dataGridView1.CurrentRow.Cells["STOCK"].Value.ToString()));
            lista.Add(user);
            
            Frm_ActualizarStock frm_stock = new Frm_ActualizarStock(lista);
            frm_stock.ShowDialog();
            Limpiar();

            //try
            //{
            //    byte[] arrayByte;
            //    bool exito;
            //    T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            //    ImageConverter convert = new ImageConverter();
            //    entProducto.ID_PRODUCTO = int.Parse(lblIdProducto.Text);
            //    entProducto.COD_PRODUCTO = txtCodigo.Text.Trim().ToUpper();
            //    entProducto.PRODUCTO = txtDescripcion.Text.Trim().ToUpper();
            //    entProducto.ID_MARCA = cmbMarca.SelectedIndex;
            //    entProducto.ID_MODELO = cmbModelo.SelectedIndex;
            //    entProducto.ID_UNIDAD_MEDIDA = cmbUndMedida.SelectedIndex;
            //    entProducto.STOCK = int.Parse(txtStock.Text);
            //    entProducto.PRECIO_COMPRA = decimal.Parse(txtPrecCompra.Text);
            //    entProducto.PRECIO_VENTA = decimal.Parse(txtPrecVenta.Text);
            //    entProducto.FEC_COMPRA = dtpFecha.Value;
            //    entProducto.USU_MODIFICA = user;
            //    entProducto.FEC_MODIFICA = DateTime.Now;
            //    entProducto.FLG_ESTADO = "1";
            //    if (picImagen.Image != null)
            //    {
                    
            //        string nombre_file = ofdImagen.SafeFileName;
            //        if (nombre_file == "")
            //        {
            //            entProducto.NOM_FILE = dataGridView1.CurrentRow.Cells["NOM_FILE"].Value.ToString();
            //            entProducto.RUTA = dataGridView1.CurrentRow.Cells["RUTA"].Value.ToString();
            //        }
            //        else
            //        {
            //            arrayByte = (byte[])convert.ConvertTo(picImagen.Image, typeof(byte[]));
            //            string ruta = ConfigurationManager.AppSettings["Carpeta_Imagen"].ToString();
            //            if (ruta == "")
            //            {
            //                ruta = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\Imagenes\\");
            //            }
            //            ruta += nombre_file;
            //            File.WriteAllBytes(ruta, arrayByte);

            //            entProducto.NOM_FILE = nombre_file;
            //            entProducto.RUTA = ruta;
            //        }
                    
            //    }
            //    exito = objProducto.Actualizar_Producto(entProducto);
            //    if (exito)
            //    {
            //        Limpiar();
            //        MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    ofdImagen.FileName = "";
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (lblIdProducto.Text != "")
            {
                entProducto.ID_PRODUCTO = int.Parse(lblIdProducto.Text);
                entProducto.FLG_ESTADO = "0";
                entProducto.USU_MODIFICA = user;
                entProducto.FEC_MODIFICA = DateTime.Now;
                bool exito = objProducto.Eliminar_Producto(entProducto, ref auditoria);
                if (exito)
                {
                    Limpiar();
                }
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            entProducto.COD_PRODUCTO = txtCodigo.Text.Trim().ToUpper();
            entProducto.PRODUCTO = txtDescripcion.Text.Trim().ToUpper();
            entProducto.ID_MARCA = int.Parse(cmbMarca.SelectedValue.ToString());
            entProducto.ID_MODELO = int.Parse(cmbModelo.SelectedValue.ToString());
            entProducto.ID_UNIDAD_MEDIDA = int.Parse(cmbUndMedida.SelectedValue.ToString());
            entProducto.STOCK = txtStock.Text == "" ? 0 : int.Parse(txtStock.Text);
            entProducto.PRECIO_COMPRA = txtPrecCompra.Text == "" ? 0 : decimal.Parse(txtPrecCompra.Text);
            entProducto.PRECIO_VENTA = txtPrecVenta.Text == "" ? 0 : decimal.Parse(txtPrecVenta.Text);
            entProducto.FEC_COMPRA = dtpFecha.Value;
            dataGridView1.DataSource = objProducto.Buscar_Producto(entProducto, ref auditoria);
        }


        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) ||  e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtPrecCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void txtPrecVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }
        private void keyPres(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void btnActualizaImg_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] arrayByte;
                bool exito;
                T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
                ImageConverter convert = new ImageConverter();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                entProducto.ID_PRODUCTO = int.Parse(lblIdProducto.Text);
                entProducto.COD_PRODUCTO = txtCodigo.Text.Trim().ToUpper();
                entProducto.PRODUCTO = txtDescripcion.Text.Trim().ToUpper();
                entProducto.ID_MARCA = int.Parse(cmbMarca.SelectedValue.ToString());
                entProducto.ID_MODELO = int.Parse(cmbModelo.SelectedValue.ToString());
                entProducto.ID_UNIDAD_MEDIDA = int.Parse(cmbUndMedida.SelectedValue.ToString());
                entProducto.PRECIO_COMPRA = decimal.Parse(txtPrecCompra.Text);
                entProducto.PRECIO_VENTA = decimal.Parse(txtPrecVenta.Text);
                entProducto.FEC_COMPRA = dtpFecha.Value;
                entProducto.USU_MODIFICA = user;
                entProducto.FEC_MODIFICA = DateTime.Now;
                entProducto.STOCK = int.Parse(txtStock.Text);
                
                if (picImagen.Image != null)
                {
                    //string nombre_file = ofdImagen.SafeFileName;
                    if (nombre_file == "")
                    {
                        entProducto.NOM_FILE = dataGridView1.CurrentRow.Cells["NOM_FILE"].Value.ToString();
                        entProducto.RUTA = dataGridView1.CurrentRow.Cells["RUTA"].Value.ToString();
                    }
                    else
                    {
                        arrayByte = (byte[])convert.ConvertTo(picImagen.Image, typeof(byte[]));
                        //string ruta = ConfigurationManager.AppSettings["Carpeta_Imagen"].ToString();
                        //if (ruta == "")
                        //{
                        //    ruta = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\Imagenes\\");
                        //}
                        string ruta = ConfigurationManager.AppSettings["Carpeta_Imagen"].ToString();
                        ruta += nombre_file;
                        File.WriteAllBytes(ruta, arrayByte);
                        
                        entProducto.NOM_FILE = nombre_file;
                        entProducto.RUTA = ruta;
                    }

                }
                exito = objProducto.ActualizarIMG_Producto(entProducto, ref auditoria);
                if (exito)
                {
                    Limpiar();
                    MessageBox.Show("El registro ha sido actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //ofdImagen.FileName = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
