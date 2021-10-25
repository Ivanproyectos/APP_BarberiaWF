using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Recursos;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Ventas
{
    public partial class Frm_Venta : Form
    {
        private Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
        //private Cls_Rule_Personal objPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_V_Empresa ObjVEmpresa = new Cls_Rule_V_Empresa();
        private Cls_Rule_Venta objVenta = new Cls_Rule_Venta();
        private Cls_Rule_D_Venta objDVenta = new Cls_Rule_D_Venta();
        private List<Cls_Ent_Producto> listProducto = new List<Cls_Ent_Producto>();
        Cls_Rule_DocumentoVenta objDocumentoVenta = new Cls_Rule_DocumentoVenta();

        Cls_Rule_Boleta objBoleta = new Cls_Rule_Boleta();
        Cls_Rule_Factura objFactura = new Cls_Rule_Factura();
        Frm_Visor_PDF frmVisor;

        private decimal valorTemp, valorTemp2;
        private int nStock, _idPersonal;
        private bool limpiar = false;
        string user; //usuario logeado
        //decimal montoBase;

        public Frm_Venta(int idPersonal, string usuario)
        {
            InitializeComponent();
            _idPersonal = idPersonal;
            user = usuario;
        }

        private void Boton_Enabled(bool estado)
        {
            if (estado)
            {
                btnEliminar.Enabled = true;
                btnEliminar.BackColor = Color.SeaGreen;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Gray;
            }
        }

        private void Limpiar()
        {
            nudCantidad.Value = 1;
            cmbPersonal.SelectedIndex = _idPersonal;
            cmbProducto.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            txtStock.Text = string.Empty;
            txtPrecVenta.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            
            txtEfectivo.Text = string.Empty;
            txtVuelto.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtIGV.Text = string.Empty;
            picImagen.Image = null;
            dataGridView1.Rows.Clear();
            nudCantidad.Value = 0;
            txtDescuento.Text = "0";
            rdoTicket.Checked = true;
            errIconoError.Clear();
            limpiar = false;
            Boton_Enabled(false);
        }

        private void Cargar_Producto()
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            listProducto = objProducto.Listar_Producto(1,ref auditoria).OrderBy(x => x.PRODUCTO).ToList();
            listProducto.Insert(0, new Cls_Ent_Producto
            {
                PRODUCTO = "-- SELECCIONE --",
                ID_PRODUCTO = 0
            });
            cmbProducto.DataSource = listProducto;
            cmbProducto.DisplayMember = "PRODUCTO";
            cmbProducto.ValueMember = "ID_PRODUCTO";
        }

        private void Cargar_Cliente()
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            List<V_CLIENTE> lisVCliente = new List<V_CLIENTE>();
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


        private void Frm_Venta_Load(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            //List<T_M_PERSONAL> listPersonal = new List<T_M_PERSONAL>();

            cmbTipoDoc.Items.Add("FACTURA");
            cmbTipoDoc.Items.Add("BOLETA");
            cmbTipoDoc.SelectedIndex = 0;
            Cargar_Cliente();

            //listPersonal = objPersonal.Listar_Personal(1, ref auditoria).OrderBy(x => x.NOMBRES).Select(x => new T_M_PERSONAL
            //{
            //    NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
            //    ID_PERSONAL = x.ID_PERSONAL
            //}).ToList();
            //cmbPersonal.DataSource = listPersonal;
            //listPersonal.Insert(0, new T_M_PERSONAL
            //{
            //    ID_PERSONAL = 0,
            //    NOMBRES = "-- SELECCIONE --"
            //});
            cmbPersonal.DisplayMember = "NOMBRES";
            cmbPersonal.ValueMember = "ID_PERSONAL";
            cmbPersonal.SelectedValue = _idPersonal;

            Cargar_Producto();
            Boton_Enabled(false);
            picImagen.Image = null;

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ruta = listProducto[cmbProducto.SelectedIndex].RUTA;
            txtStock.Text = listProducto[cmbProducto.SelectedIndex].STOCK.ToString();
            nStock = int.Parse(txtStock.Text);
            txtPrecVenta.Text = listProducto[cmbProducto.SelectedIndex].PRECIO_VENTA.ToString();
            if (ruta == null)
            {
                picImagen.Image = null;
            }
            else
            {
                picImagen.Load(ruta);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            List<T_M_PRODUCTO> listaProducto = new List<T_M_PRODUCTO>();
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            T_M_VENTA entMVenta = new T_M_VENTA();
            T_D_VENTA entDVenta = new T_D_VENTA();

            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            int idVenta; // ALMACENA EL ID DESPUES DE INSERTAR EN LA TABLA M_CORTE 
            int nuevoStock = 0;
            bool exito = false;
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Ingrese producto producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtEfectivo.Text == "")
                {
                    MessageBox.Show("Ingrese efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string numero = "";
                    string serie = "";
                    string anio = "";
                    int conteoDoc = 0;
                    if (cmbTipoDoc.Text == "BOLETA")
                    {
                        T_BOLETA entBoleta = objBoleta.Listar_Boleta(ref auditoria);
                        serie = entBoleta.SERIE;
                        conteoDoc = (int)entBoleta.NUMERO;
                        anio = entBoleta.ANIO;
                    }
                    else if (cmbTipoDoc.Text == "FACTURA")
                    {
                        T_FACTURA entFactura = objFactura.Listar_Factura(ref auditoria);
                        serie = entFactura.SERIE;
                        conteoDoc = (int)entFactura.NUMERO;
                        anio = entFactura.ANIO;
                    }
                    
                    if (conteoDoc == 0)
                    {
                        numero = serie + "-00000001";
                        conteoDoc = 1;
                    }
                    else
                    {
                        if (anio == DateTime.Now.Year.ToString())
                        {
                            conteoDoc += 1;
                            numero = serie + "-" + ("00000000" + conteoDoc).Substring(conteoDoc.ToString().Length, 8);
                        }
                        else
                        {
                            numero = serie + "-00000001";
                            conteoDoc = 1;
                        }
                    }
                    if (cmbTipoDoc.Text == "BOLETA")
                        objBoleta.Actualizar_Boleta(conteoDoc, DateTime.Now.Year.ToString(), ref auditoria);
                    else if (cmbTipoDoc.Text == "FACTURA")
                        objFactura.Actualizar_Factura(conteoDoc, DateTime.Now.Year.ToString(), ref auditoria);

                    entMVenta.ID_CLIENTE = int.Parse(dataGridView1.Rows[0].Cells["IDCLIENTE"].Value.ToString());
                    //entMVenta.ID_PERSONAL = int.Parse(dataGridView1.Rows[0].Cells["IDPERSONAL"].Value.ToString());
                    
                    entMVenta.VOUCHER = numero;
                    entMVenta.FLG_ESTADO = "1";
                    entMVenta.USUARIO = user;
                    entMVenta.FEC_VENTA = DateTime.Now;
                    entMVenta.FEC_ENVIO = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK");
                    entMVenta.EFECTIVO = double.Parse(txtEfectivo.Text).ToString("00.00");
                    entMVenta.VUELTO = txtVuelto.Text;
                    idVenta = objVenta.Insertar_M_Venta(entMVenta, ref auditoria);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (idVenta > 0)
                        {
                            entDVenta.ID_VENTA = idVenta;
                            entDVenta.CANTIDAD = Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString());
                            entDVenta.PRECIO = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString());
                            entDVenta.IMPORTE = decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                            entDVenta.ID_PRODUCTO = int.Parse(dataGridView1.Rows[i].Cells["IDPRODUCTO"].Value.ToString());
                        }

                        Cls_Ent_Producto clsProducto = new Cls_Ent_Producto();
                        clsProducto = listProducto.Find(x => x.PRODUCTO == dataGridView1.Rows[i].Cells["PRODUCTO"].Value.ToString());
                        nuevoStock = (int)(clsProducto.STOCK - entDVenta.CANTIDAD);
                        objProducto.NuevoStock_Producto(clsProducto.ID_PRODUCTO, nuevoStock, ref auditoria);
                        exito = objDVenta.Insertar_D_Venta(entDVenta, ref auditoria);

                    }

                    if (exito)
                    {
                        DBApi apisPeru = new DBApi();
                        string url = "";
                        T_M_CLIENTES entCliente = new T_M_CLIENTES();

                        string autorizacion = "bearer " + ConfigurationManager.AppSettings["token"].ToString();
                        entCliente = ObjCliente.Buscar_Clientes(int.Parse(cmbCliente.SelectedValue.ToString()), ref auditoria);
                        Cls_Ent_Boleta boleta = new Cls_Ent_Boleta();
                        if (cmbTipoDoc.Text == "FACTURA")
                        {
                            //Cls_Ent_Factura factura = new Cls_Ent_Factura();
                            boleta.tipoDoc = "01";
                            boleta.client = new Cliente
                            {
                                tipoDoc = entCliente.TIPO_DOC,
                                numDoc = entCliente.NUM_DOC,
                                rznSocial = entCliente.R_SOCIAL,
                                address = new Address{
                                    direccion = entCliente.DIRECCION
                                }
                            };
                        }
                        else if (cmbTipoDoc.Text == "BOLETA")
                        {
                            boleta.tipoDoc = "03";
                            boleta.client = new Cliente
                            {
                                tipoDoc = entCliente.TIPO_DOC,
                                numDoc = entCliente.NUM_DOC,
                                rznSocial = cmbCliente.Text,
                                address = new Address
                                {
                                    direccion = entCliente.DIRECCION
                                }
                            };

                        }
                        boleta.serie = serie;
                        boleta.correlativo = numero.Substring(5);
                        boleta.fechaEmision = entMVenta.FEC_ENVIO;
                        List<V_EMPRESA> entEmpresa = new List<V_EMPRESA>();
                        entEmpresa = ObjVEmpresa.Listar_Empresa(ref auditoria);
                        boleta.company = new Empresa() { 
                            ruc = entEmpresa[0].RUC,
                            razonSocial = entEmpresa[0].R_SOCIAL,
                            nombreComercial = entEmpresa[0].NOM_COMERCIAL
                        };
                        boleta.company.address = new Address()
                        {
                            direccion = entEmpresa[0].DIRECCION,
                            provincia = entEmpresa[0].PROVINCIA,
                            departamento = entEmpresa[0].DEPARTAMENTO,
                            distrito = entEmpresa[0].DISTRITO,
                            ubigueo = entEmpresa[0].UBIGEO
                        };
                        boleta.formaPago = new FormaPago();
                        byte i = 0;
                        //decimal mtoIGV = 0;
                        List<DetalleProducto> listDetalleProducto = new List<DetalleProducto>();
                        Cls_Ent_Producto clsProducto = new Cls_Ent_Producto();
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            clsProducto = listProducto.Find(x => x.PRODUCTO == item.Cells["PRODUCTO"].Value.ToString());
                            decimal importe = decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                            decimal igv = importe * 18 / 100;
                            listDetalleProducto.Add(new DetalleProducto()
                            {
                                codProducto = clsProducto.COD_PRODUCTO,
                                unidad = "NIU",
                                descripcion = clsProducto.PRODUCTO,
                                cantidad = Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString()),
                                mtoValorUnitario = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString()),
                                mtoValorVenta = importe,
                                mtoBaseIgv = importe,
                                porcentajeIgv = 18,
                                igv = igv,
                                tipAfeIgv = "10",
                                totalImpuestos = igv,
                                mtoPrecioUnitario = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString()) + (igv / Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString()))
                            });
                            i += 1;
                        }

                        List<Descuento> listDescuento = new List<Descuento>();
                        listDescuento.Add(new Descuento
                        {
                            montoBase = valorTemp,
                            monto = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text)
                        });
                        boleta.descuentos = listDescuento;
                        boleta.sumOtrosDescuentos = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text);

                        boleta.mtoOperGravadas = valorTemp;
                        boleta.mtoIGV = decimal.Parse(txtIGV.Text);
                        boleta.valorVenta = valorTemp;
                        boleta.totalImpuestos = decimal.Parse(txtIGV.Text);
                        boleta.subTotal = valorTemp + decimal.Parse(txtIGV.Text);
                        boleta.mtoImpVenta = decimal.Parse(txtTotal.Text);
                        boleta.details = listDetalleProducto;
                        Moneda claseMoneda = new Moneda();
                        List<Leyenda> listLeyenda = new List<Leyenda>();
                        listLeyenda.Add(new Leyenda
                        {
                            value = claseMoneda.Convertir(txtTotal.Text, true, "SOLES")
                        });
                        boleta.legends = listLeyenda;                        

                        string json = JsonConvert.SerializeObject(boleta);

                        url = "https://facturacion.apisperu.com/api/v1/invoice/send";
                        var respuesta = apisPeru.Post(url, json, autorizacion);
                        
                        
                        dynamic objDeserialisacion = JsonConvert.DeserializeObject(respuesta.Content);
                        if (objDeserialisacion.error != "" && objDeserialisacion.error != null)
                        {
                            MessageBox.Show(objDeserialisacion.error.ToString());
                        }
                        else
                        {

                            //MessageBox.Show(respuesta.Content.Substring(respuesta.Content.IndexOf("description")));
                            if ((bool)objDeserialisacion.sunatResponse.success)
                            {
                            
                                string nameFile = entEmpresa[0].RUC + "-"+ DateTime.Now.Year + "-" + boleta.tipoDoc + "-"+ serie + "-" + conteoDoc;

                                string ruta = "./Recursos/Voucher/" + nameFile + ".xml";
                                if (!Directory.Exists("./Recursos"))
                                {
                                    Directory.CreateDirectory("./Recursos/Voucher");
                                }
                                using (Stream str = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write))
                                {
                                    using (StreamWriter stw = new StreamWriter(str))
                                    {
                                        stw.WriteLine(objDeserialisacion.xml);
                                    }
                                }

                                T_D_DOCUMENTOS_VENTAS entDocumento = new T_D_DOCUMENTOS_VENTAS();
                                entDocumento.ID_VENTA = idVenta;
                                entDocumento.CODIGO_ARCHIVO = Css_Codigo.Generar_Codigo_Temporal();
                                entDocumento.NOMBRE_ARCHIVO = nameFile;
                                entDocumento.EXTENSION_ARCHIVO = "xml";
                                entDocumento.FEC_CREARION = DateTime.Now;
                                entDocumento.USU_CREACCION = user;
                                if (!objDocumentoVenta.Insertar_DocumentoVenta(entDocumento, ref auditoria))
                                {
                                    MessageBox.Show("Ocurrio un problema al guardar los registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    url = "https://facturacion.apisperu.com/api/v1/invoice/pdf";
                                    var respuesta2 = apisPeru.Post(url, json, autorizacion);
                                    byte[] bytes = respuesta2.RawBytes;
                                    //string path = Environment.CurrentDirectory + "\\prueba.pdf";
                                    ruta = "./Recursos/Voucher/" + nameFile + ".pdf";
                                    BinaryWriter writer = new BinaryWriter(File.Open(ruta, FileMode.OpenOrCreate));
                                    writer.Write(bytes, 0, bytes.Length);
                                    writer.Close();
                                    writer.Dispose();

                                    entDocumento.ID_VENTA = idVenta;
                                    entDocumento.CODIGO_ARCHIVO = Css_Codigo.Generar_Codigo_Temporal();
                                    entDocumento.NOMBRE_ARCHIVO = nameFile;
                                    entDocumento.EXTENSION_ARCHIVO = "pdf";
                                    entDocumento.FEC_CREARION = DateTime.Now;
                                    entDocumento.USU_CREACCION = user;
                                    objDocumentoVenta.Insertar_DocumentoVenta(entDocumento, ref auditoria);

                                    entMVenta.TOTAL_IMPORTE = valorTemp;
                                    entMVenta.IGV = decimal.Parse(txtIGV.Text);
                                    entMVenta.DESCT_TOTAL = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text);
                                    entMVenta.TOTAL = decimal.Parse(txtTotal.Text);
                                    entMVenta.FEC_ENVIO = entMVenta.FEC_ENVIO;
                                    entMVenta.ID_VENTA = idVenta;
                                    //entMVenta.CODIGO_FILE = Css_Codigo.Generar_Codigo_Temporal();
                                    //entMVenta.NOMBRE_FILE = nameFile;
                                    //entMVenta.EXTENSION_FILE = "xml pdf";
                                    objVenta.Actualizar_Venta(entMVenta, ref auditoria);
                                    //ENVIAR POR CORREO
                                    //creamos nuestra lista de archivos a enviar
                                    List<string> lstArchivos = new List<string>();
                                    lstArchivos.Add(Environment.CurrentDirectory + "\\Recursos\\Voucher\\" + nameFile + ".pdf");
                                    lstArchivos.Add(Environment.CurrentDirectory + "\\Recursos\\Voucher\\" + nameFile + ".xml");

                                    //creamos nuestro objeto de la clase que hicimos
                                    Mail oMail = new Mail("aquino.yordan@gmail.com", "aquino.yordan@gmail.com",
                                                        "PRUEBA", "PRUEBA", lstArchivos);

                                    //y enviamos
                                    if (!oMail.enviaMail())
                                    {
                                        MessageBox.Show(oMail.error);

                                    }

                                    if (rdoPDF.Checked)
                                    {
                                        frmVisor = new Frm_Visor_PDF(Environment.CurrentDirectory + "\\Recursos\\Voucher\\" + nameFile + ".pdf");
                                        frmVisor.ShowDialog();
                                        Cargar_Producto(); //REFRESCA EL PRODUCTO
                                        limpiar = true;
                                        Limpiar();
                                    }
                                    else
                                    {
                                        CreaTicket Ticket1 = new CreaTicket();
                                        Ticket1.TextoCentro("BARBERIA");
                                        Ticket1.TextoCentro("\"EMOTIONS\"");
                                        Ticket1.TextoCentro(boleta.company.razonSocial);
                                        Ticket1.TextoCentro("av siempre vivas lurin");
                                        Ticket1.TextoCentro("RUC: " + boleta.company.ruc);
                                        Ticket1.LineasAsterisco();
                                        Ticket1.TextoCentro(cmbTipoDoc.Text + " DE VENTA ELECTRONICA");
                                        Ticket1.TextoCentro(boleta.serie + "-" + boleta.correlativo);
                                        Ticket1.LineasAsterisco();
                                        Ticket1.TextoExtremos(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                                        Ticket1.TextoIzquierda("CAJERO : " + cmbPersonal.Text);
                                        Ticket1.TextoIzquierda("CLIENTE : " + cmbCliente.Text);
                                        Ticket1.LineasGuion();
                                        Ticket1.EncabezadoVenta();
                                        foreach (DataGridViewRow item in dataGridView1.Rows)
                                        {
                                            Ticket1.AgregaArticulo(item.Cells["PRODUCTO"].Value.ToString(), int.Parse(item.Cells["CANTIDAD"].Value.ToString()), double.Parse(item.Cells["PRECIO"].Value.ToString()), double.Parse(item.Cells["IMPORTE"].Value.ToString()));
                                        }
                                        Ticket1.LineasGuion();
                                        Ticket1.AgregaTotales("SUBTOTAL", double.Parse(txtSubTotal.Text));
                                        Ticket1.AgregaTotales("DESCUENTO", double.Parse(boleta.sumOtrosDescuentos.ToString()));
                                        Ticket1.AgregaTotales("IGV (18%)", double.Parse(txtIGV.Text));
                                        Ticket1.AgregaTotales("TOTAL", double.Parse(txtTotal.Text));
                                        Ticket1.AgregaTotales("EFECTIVO", double.Parse(txtEfectivo.Text));
                                        Ticket1.AgregaTotales("VUELTO", double.Parse(txtVuelto.Text));
                                        Ticket1.TextoIzquierda("SON : " + boleta.legends[0].value);
                                        Ticket1.LineasGuion();
                                        Ticket1.TextoCentro("AGRADECEMOS SU PREFERENCIA");
                                        if (rdoTicket.Checked)
                                        {
                                            Ticket1.TextoCentro("COD. HASH : " + objDeserialisacion.hash.ToString());
                                        }
                                        //Ticket1.TextoCentro("COD. HASH : " + objDeserialisacion.hash.ToString());
                                        Ticket1.TextoCentro("CONSULTE SU DOCUMENTO ELECTRONICO EN:");
                                        Ticket1.TextoCentro("http://sunat.com.pe");
                                        Ticket1.CortaTicket();
                                        Cargar_Producto(); //REFRESCA EL PRODUCTO
                                        limpiar = true;
                                        Limpiar();
                                    }
                                }
                        
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un problema " + respuesta.Content.Substring(respuesta.Content.IndexOf("hash")), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        //    Autorizado mediante Resolución de Intendencia N° 032 - 005 Representación impresa de la Boleta de Venta Electronica. Consulte su documento electrónico en:
                        //http://sunat.com.pe
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un problema al guardar los registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == 0 || cmbPersonal.SelectedIndex == 0 || cmbCliente.SelectedIndex == 0 ||  nudCantidad.Value == 0)
            {
                MessageBox.Show("Rellene todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (int.Parse(txtStock.Text) >= 0)
                {
                    decimal total = 0;
                    decimal subTotal;
                    Int16 cantidadDGV = 0;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (cmbProducto.Text == item.Cells["PRODUCTO"].Value.ToString())
                        {
                            cantidadDGV = Int16.Parse(item.Cells["CANTIDAD"].Value.ToString());
                            Int16 index = (short)item.Cells["CANTIDAD"].RowIndex;
                            dataGridView1.Rows.RemoveAt(index);
                            break;
                        }
                    }

                    cantidadDGV = (short)(nudCantidad.Value + cantidadDGV);
                    subTotal = cantidadDGV * decimal.Parse(txtPrecVenta.Text);
                    dataGridView1.Rows.Add(cmbProducto.SelectedValue, cmbCliente.SelectedValue, cmbPersonal.SelectedValue, cmbCliente.Text, txtStock.Text, cmbProducto.Text, txtPrecVenta.Text, cantidadDGV, subTotal);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        total += decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                    }
                    dataGridView1.CurrentRow.Cells[0].Selected = false;
                    
                    valorTemp = total; //total importe
                    cmbProducto.SelectedIndex = 0;
                    nudCantidad.Value = 0;
                    txtStock.Text = string.Empty;
                    txtPrecVenta.Text = string.Empty;
                    errIconoError.Clear();
                    picImagen.Image = null;
                    if (txtDescuento.Text != "")
                    {
                        txtSubTotal.Text = (valorTemp - decimal.Parse(txtDescuento.Text)).ToString();
                    }
                    else
                    {
                        txtSubTotal.Text = total.ToString();
                    }
                    decimal igv = valorTemp * 0.18m;

                    txtIGV.Text = (igv).ToString("0.00");
                    txtTotal.Text = (decimal.Parse(txtSubTotal.Text) + igv).ToString("0.00");
                    valorTemp2 = decimal.Parse(txtTotal.Text);
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            decimal  dataGrid, result;

            dataGrid = decimal.Parse(dataGridView1.CurrentRow.Cells["IMPORTE"].Value.ToString());
            
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentRow.Selected = false;
                result = valorTemp - dataGrid;
                valorTemp = result;
                if (txtDescuento.Text != "")
                {
                    txtSubTotal.Text = (valorTemp - decimal.Parse(txtDescuento.Text)).ToString();
                }
                else
                {
                    txtSubTotal.Text = result.ToString();
                }
                txtIGV.Text = (valorTemp * 18 / 100).ToString();
                txtTotal.Text = (decimal.Parse(txtSubTotal.Text) + decimal.Parse(txtIGV.Text)).ToString();
            }
            else
            {
                
                txtEfectivo.Text = "";
                txtDescuento.Text = "0";
                txtVuelto.Text = "";
                txtSubTotal.Text = "";
                txtTotal.Text = "";
                txtIGV.Text = "";
            }
            Boton_Enabled(false);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar = true;
            Limpiar();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            int cantidad = (int)nudCantidad.Value;
            int result;
            result = nStock - cantidad;
            txtStock.Text = result.ToString();
            if (result < 0)
            {
                errIconoError.SetError(nudCantidad, "El estock no debe ser menor que 0");
            }
            else
            {
                errIconoError.Clear();
            }
            if ((int)nudCantidad.Value == 0)
            {
                errIconoError.SetError(nudCantidad, "Ingrese una cantidad");
            }
            else
            {
                errIconoError.Clear();
            }
        }

        private void nudCantidad_Validating(object sender, CancelEventArgs e)
        {
            if ((int)nudCantidad.Value == 0)
            {
                errIconoError.SetError(nudCantidad, "Ingrese una cantidad");
            }
            else
            {
                errIconoError.Clear();
            }
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Boton_Enabled(true);
            }

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            bool parse;
            if (!(txtDescuento.Text == ""))
            {
                if (!limpiar)
                {
                    parse = decimal.TryParse(txtDescuento.Text, out decimal descuento);
                    if (parse)
                    {
                        //txtTotal.Text = (valorTemp - (valorTemp * descuento / 100)).ToString(); para porcentaje
                        if (txtTotal.Text != "")
                        {
                            txtTotal.Text = (Decimal.Parse(txtTotal.Text) - descuento).ToString();
                            errIconoError.Clear();
                        }
                        
                    }
                    else
                    {
                        errIconoError.SetError(txtDescuento, "Ingrese número");
                    }
                }
                
            }
            else
            {
                if (limpiar)
                {
                    txtTotal.Text = "";
                }
                else
                {
                    txtTotal.Text = (valorTemp + decimal.Parse(txtIGV.Text)).ToString();
                }
                

            }
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (errIconoError.GetError(txtEfectivo) != "")
                txtEfectivo.Focus();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
           {
                if (txtTotal.Text != "")
                {
                    if (txtEfectivo.Text != "")
                    {
                        bool exito;
                        exito = decimal.TryParse(txtEfectivo.Text, out decimal result);
                        if (!exito)
                        {
                            errIconoError.SetError(txtEfectivo, "No se pudo convertir a número");
                            //txtEfectivo.Focus();
                        }
                        else
                        {
                            txtVuelto.Text = (decimal.Parse(txtEfectivo.Text) - decimal.Parse(txtTotal.Text)).ToString();
                            errIconoError.Clear();
                        } 
                    }
                    else
                    {
                        txtVuelto.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            if (errIconoError.GetError(txtEfectivo) != "")
                txtEfectivo.Focus();
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void picBusProducto_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("PRODUCTO", user); // envio el tipo a buscar
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbProducto.SelectedIndex = 0;
            else
                cmbProducto.Text = form.DevolverNombre;

        }

        private void picBusPersonal_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("PERSONAL", user); // envio el tipo a buscar
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbPersonal.SelectedIndex = 0;
            else
                cmbPersonal.Text = form.DevolverNombre;
        }



        private void picBusCliente_Click(object sender, EventArgs e)
        {
            //Frm_Buscar form = new Frm_Buscar("CLIENTE", user); // envio el tipo a buscar
            //AddOwnedForm(form);
            //form.ShowDialog();

            Frm_Buscar form = new Frm_Buscar("CLIENTE", user);
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbCliente.SelectedIndex = 0;
            else
            {
                cmbCliente.Text = form.DevolverNombre;
                if (cmbCliente.Text != form.DevolverNombre)
                {
                    Cargar_Cliente();
                    cmbCliente.Text = form.DevolverNombre;
                }
            }
                
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (cmbCliente.SelectedIndex > 0)
            {
                if (cmbTipoDoc.Text == "FACTURA")
                {
                    T_M_CLIENTES entCliente = new T_M_CLIENTES();
                    entCliente = ObjCliente.Buscar_Clientes(int.Parse(cmbCliente.SelectedValue.ToString()), ref auditoria);
                    if (entCliente.TIPO_DOC == "1")
                    {
                        MessageBox.Show("El cliente no cuenta con RUC", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Comprobantes frm = new Frm_Comprobantes();
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                if (txtTotal.Text != "")
                {
                    txtVuelto.Text = (decimal.Parse(txtEfectivo.Text) - decimal.Parse(txtTotal.Text)).ToString();
                }
                
            }
            else
            {
                txtVuelto.Text = "";
            }
            txtIGV.Text = (valorTemp * 18 / 100).ToString();
        }
    }
}
