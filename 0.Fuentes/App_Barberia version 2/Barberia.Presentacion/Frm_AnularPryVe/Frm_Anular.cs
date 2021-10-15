using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Frm_Ventas;
using Barberia.Presentacion.Recursos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_AnularPryVe
{
    public partial class Frm_Anular : Form
    {
        
        List<V_CORTE> listaCorte = new List<V_CORTE>();
        List<T_ACTUALIZAR_STOCK> listaActStock = new List<T_ACTUALIZAR_STOCK>();
         Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
        Cls_Rule_Venta objVenta = new Cls_Rule_Venta();
        Cls_Rule_V_Empresa ObjVEmpresa = new Cls_Rule_V_Empresa();
        Cls_Rule_Clientes ObjCliente;
        Frm_Visor_PDF frmVisor;

        string user; //usuario logeado

        string fechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
        string fechaFin = DateTime.Now.ToString("dd/MM/yyyy");
        public Frm_Anular(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        #region METODOS


        private void Boton_Disable(Button btn)
        {

                btn.Enabled = false;
                btn.BackColor = Color.Gray;
  
        }

        private void Boton_Enable(Button btn)
        {

            btn.Enabled = true;
            btn.BackColor = Color.SeaGreen;

        }

        private void Limpiar_Servicio() 
        {
            dataGridView2.DataSource = "";
            txtVoucher.Text = "";
            txtMotivoServicio.Text = "";
        }

        private void Limpiar_Venta()
        {
            dataGridView3.DataSource = "";
            txtNBoleta.Text = "";
            txtMotivoVenta.Text = "";
        }

        private void Limpiar_Producto()
        {
            dataGridView4.DataSource = "";
            txtMotivoProducto.Text = "";
            txtFactura.Text = "";
            txtGuia.Text = "";
            txtBoletaPro.Text = "";
        }
        #endregion


        private void Frm_Anular_Load(object sender, EventArgs e)
        {
            btnEliminarServicio.Enabled = false;
            btnEliminarVenta.Enabled = false;
            btnEliminarProducto.Enabled = false;
        }


        private void txtNBoleta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarServicio_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                if (txtVoucher.Text != "")
                {
                    Cls_Rule_V_Corte objVCorte = new Cls_Rule_V_Corte();
                    List<DataCorte> dataCorte = new List<DataCorte>();
                    V_CORTE entCorte = new V_CORTE();
                    entCorte.VOUCHER = txtVoucher.Text;
                    listaCorte = objVCorte.Buscar_Corte(entCorte, fechaInicio, fechaFin, ref auditoria);
                    foreach (var item in listaCorte)
                    {
                        if (item.TOTAL != null)
                        {
                            dataCorte.Add(new DataCorte
                            {
                                VOUCHER = item.VOUCHER,
                                CLIENTE = item.CLIENTE,
                                TOTAL = item.TOTAL.ToString(),
                                FECHA_OPERACION = (DateTime)item.FEC_CORTE,
                                USER_OPERACION = item.USUARIO
                            });
                            break;
                        }
                    }
                    dataGridView2.DataSource = dataCorte;
                    dataGridView2.Columns["FECHA_OPERACION"].Visible = false;
                    dataGridView2.Columns["USER_OPERACION"].Visible = false;
                    dataGridView2.ClearSelection();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Rule_Anular_Corte objAnularCorte = new Cls_Rule_Anular_Corte();
                Cls_Rule_M_Corte objCorte = new Cls_Rule_M_Corte();
                T_ANULAR_CORTE entAnularCorte = new T_ANULAR_CORTE();
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                string voucher;

                if (dataGridView2.Rows.Count > 0)
                {
                    voucher = dataGridView2.CurrentRow.Cells["VOUCHER"].Value.ToString();
                    if (objCorte.Anular_Corte(voucher, ref auditoria))
                    {
                        entAnularCorte.DESC_ANULAR = txtMotivoServicio.Text.Trim().ToUpper();
                        entAnularCorte.VOUCHER = voucher;
                        entAnularCorte.PERSONAL = listaCorte[0].PERSONAL;
                        entAnularCorte.CLIENTE = listaCorte[0].CLIENTE;
                        entAnularCorte.TOTAL = decimal.Parse(dataGridView2.CurrentRow.Cells["TOTAL"].Value.ToString());
                        entAnularCorte.FEC_OPERACION = DateTime.Parse(dataGridView2.CurrentRow.Cells["FECHA_OPERACION"].Value.ToString());
                        entAnularCorte.FEC_ANULAR = DateTime.Now;
                        entAnularCorte.USER_OPERACION = dataGridView2.CurrentRow.Cells["USER_OPERACION"].Value.ToString();
                        entAnularCorte.USER_ANULAR = user;
                        if (objAnularCorte.Insertar_Anular_Corte(entAnularCorte, ref auditoria))
                        {
                            MessageBox.Show("El registro ha sido anulado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        listaCorte.Clear();
                        Limpiar_Servicio();
                        Boton_Disable(btnEliminarServicio);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.RowCount > 0 && dataGridView2.CurrentRow.Selected)
            {
                Boton_Enable(btnEliminarServicio);
            }
        }



        //=======================================================
        //------------SECION DEL TAB VENTAS --------
        //=======================================================

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                if (txtNBoleta.Text != "")
                {
                    
                    //List<DataVenta> dataVenta = new List<DataVenta>();
                    //V_VENTA entVenta = new V_VENTA();
                    List<T_M_VENTA> lisTMVenta = new List<T_M_VENTA>();

                    lisTMVenta = objVenta.Buscar_Venta(txtNBoleta.Text, ref auditoria);

                    dataGridView3.DataSource = lisTMVenta;
                    dataGridView3.Columns["ID_VENTA"].Visible = false;
                    dataGridView3.Columns["ID_PERSONAL"].Visible = false;
                    dataGridView3.Columns["ID_CLIENTE"].Visible = false;
                    dataGridView3.Columns["FLG_ESTADO"].Visible = false;
                    dataGridView3.Columns["T_D_VENTA"].Visible = false;
                    dataGridView3.Columns["T_M_CLIENTES"].Visible = false;
                    dataGridView3.Columns["T_M_PERSONAL"].Visible = false;
                    dataGridView3.Columns["FEC_ENVIO"].Visible = false;
                    //dataGridView3.Columns["USUARIO"].Visible = false;
                    dataGridView3.Columns["VOUCHER"].HeaderText = "FACTURA";
                    dataGridView3.Columns["TOTAL_IMPORTE"].HeaderText = "SUBTOTAL";
                    dataGridView3.Columns["DESCT_TOTAL"].HeaderText = "DESCUENTO";
                    dataGridView3.Columns["FEC_VENTA"].HeaderText = "FECHA";
                    dataGridView3.ClearSelection();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            Cls_Rule_Anular_Venta objAnularVenta = new Cls_Rule_Anular_Venta();
            T_ANULAR_VENTA entAnularVenta = new T_ANULAR_VENTA();
            Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            List<T_M_PRODUCTO> listaProducto = new List<T_M_PRODUCTO>();
            List<V_VENTA> listaVenta = new List<V_VENTA>();
            Cls_Rule_V_Venta objVVenta = new Cls_Rule_V_Venta();
            Cls_Rule_C_Anular objCAnular = new Cls_Rule_C_Anular();
            Cls_Ent_Anular_Fac entAnularFac;
            Cls_Ent_Anular_Bol entAnularBol;
            int stock = 0;
            if (dataGridView3.Rows.Count > 0)
            {
                string voucher = dataGridView3.CurrentRow.Cells["VOUCHER"].Value.ToString();
                int id = int.Parse(dataGridView3.CurrentRow.Cells["ID_VENTA"].Value.ToString());
                string autorizacion = "bearer " + ConfigurationManager.AppSettings["token"].ToString();
                string url = "", numero="";
                DBApi apisPeru = new DBApi();
                List<T_C_ANULAR> cAnular = objCAnular.Listar_C_Anular(ref auditoria);
                if (voucher.Substring(0,1) == "F")
                {
                    entAnularFac = new Cls_Ent_Anular_Fac();
                    url = "https://facturacion.apisperu.com/api/v1/voided/send";
                    numero = cAnular[0].NUMERO;
                    int conteo = int.Parse(numero);
                    if (cAnular[0].FECHA.ToString().Substring(0, 10).Equals(DateTime.Now.ToShortDateString()))
                    {
                        if (conteo == 0)
                        {
                            numero = "00001";
                        }
                        else
                        {
                            conteo += 1;
                            numero = ("00000" + conteo).Substring(conteo.ToString().Length, 5);
                        }
                    }
                    else
                    {
                        numero = "00001";

                    }
                    entAnularFac.correlativo = numero;
                    entAnularFac.fecGeneracion = dataGridView3.CurrentRow.Cells["FEC_ENVIO"].Value.ToString();
                    entAnularFac.fecComunicacion = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK");
                    List<V_EMPRESA> entEmpresa = new List<V_EMPRESA>();
                    entEmpresa = ObjVEmpresa.Listar_Empresa(ref auditoria);
                    entAnularFac.company = new Empresa()
                    {
                        ruc = entEmpresa[0].RUC,
                        razonSocial = entEmpresa[0].R_SOCIAL,
                        nombreComercial = entEmpresa[0].NOM_COMERCIAL
                    };
                    entAnularFac.company.address = new Address()
                    {
                        direccion = entEmpresa[0].DIRECCION,
                        provincia = entEmpresa[0].PROVINCIA,
                        departamento = entEmpresa[0].DEPARTAMENTO,
                        distrito = entEmpresa[0].DISTRITO,
                        ubigueo = entEmpresa[0].UBIGEO
                    };
                    List<Cls_Ent_Anular_Fac.DetalleAnular> detalle = new List<Cls_Ent_Anular_Fac.DetalleAnular>();
                    //string voucher = dataGridView3.CurrentRow.Cells["VOUCHER"].Value.ToString();
                    string serie = voucher.Substring(0, 4);
                    string correlativo = voucher.Substring(5, 8);
                    detalle.Add(new Cls_Ent_Anular_Fac.DetalleAnular
                    {
                        tipoDoc = "01",
                        serie = serie,
                        correlativo = correlativo,
                        desMotivoBaja = txtMotivoVenta.Text.Trim().ToUpper()
                    });
                    entAnularFac.details = detalle;
                    string json = JsonConvert.SerializeObject(entAnularFac);
                    var respuesta = apisPeru.Post(url, json, autorizacion);
                    dynamic objDeserialisacion = JsonConvert.DeserializeObject(respuesta.Content);
                    MessageBox.Show(respuesta.Content.Substring(respuesta.Content.IndexOf("hash")));
                    if ((bool)objDeserialisacion.sunatResponse.success)
                    {
                        url = "https://facturacion.apisperu.com/api/v1/voided/pdf";
                        respuesta = apisPeru.Post(url, json, autorizacion);

                        byte[] bytes = respuesta.RawBytes;
                        string path = Environment.CurrentDirectory + "\\bajaFactura.pdf";
                        BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                        frmVisor = new Frm_Visor_PDF(path);
                        frmVisor.ShowDialog();

                        listaVenta = objVVenta.Buscar_Venta(id, ref auditoria);
                        foreach (var item in listaVenta)
                        {
                            // devolver el stock
                            entProducto.PRODUCTO = item.PRODUCTO;
                            listaProducto = objProducto.Buscar_Producto(entProducto, ref auditoria);
                            stock = (int)(item.CANTIDAD + listaProducto[0].STOCK);
                            objProducto.NuevoStock_Producto(listaProducto[0].ID_PRODUCTO, stock, ref auditoria);
                        }
                        entAnularVenta.VOUCHER = listaVenta[0].VOUCHER;
                        entAnularVenta.DESC_ANULAR = txtMotivoVenta.Text.Trim().ToUpper();
                        entAnularVenta.PERSONAL = listaVenta[0].PERSONAL;
                        entAnularVenta.CLIENTE = listaVenta[0].CLIENTE;
                        entAnularVenta.SUBTOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL_IMPORTE"].Value.ToString());
                        entAnularVenta.DESC_TOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["DESCT_TOTAL"].Value.ToString());
                        entAnularVenta.TOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL"].Value.ToString());

                        entAnularVenta.FEC_OPERACION = DateTime.Parse(dataGridView3.CurrentRow.Cells["FEC_VENTA"].Value.ToString());
                        entAnularVenta.USER_OPERACION = dataGridView3.CurrentRow.Cells["USUARIO"].Value.ToString();

                        entAnularVenta.FEC_ANULAR = DateTime.Now;
                        entAnularVenta.USER_ANULAR = user;

                        if (objVenta.Anular_Venta(id, ref auditoria))
                        {

                            if (objAnularVenta.Insertar_Anular_Venta(entAnularVenta, ref auditoria))
                            {
                                objCAnular.Actualizar_C_Anular(cAnular[0].ID_C_ANULAR, numero, DateTime.Now, ref auditoria);
                                MessageBox.Show("El registro ha sido anulado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Boton_Disable(btnEliminarVenta);
                                Limpiar_Venta();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema " + respuesta.Content.Substring(respuesta.Content.IndexOf("hash")), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (voucher.Substring(0, 1) == "B")
                {
                    entAnularBol = new Cls_Ent_Anular_Bol();
                    url = "https://facturacion.apisperu.com/api/v1/summary/send";
                    numero = cAnular[1].NUMERO;
                    int conteo = int.Parse(numero);
                    if (cAnular[1].FECHA.ToString().Substring(0,10).Equals(DateTime.Now.ToShortDateString()))
                    {
                        if (conteo == 0)
                        {
                            numero = "00001";
                        }
                        else
                        {
                            conteo += 1;
                            numero = ("00000" + conteo).Substring(conteo.ToString().Length, 5);
                        }
                    }
                    else
                    {
                        numero = "00001";
                    }
                    entAnularBol.correlativo = numero;
                    entAnularBol.fecGeneracion = dataGridView3.CurrentRow.Cells["FEC_ENVIO"].Value.ToString();
                    entAnularBol.fecResumen = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK");
                    entAnularBol.moneda = "PEN";
                    List<V_EMPRESA> entEmpresa = new List<V_EMPRESA>();
                    entEmpresa = ObjVEmpresa.Listar_Empresa(ref auditoria);
                    entAnularBol.company = new Empresa()
                    {
                        ruc = entEmpresa[0].RUC,
                        razonSocial = entEmpresa[0].R_SOCIAL,
                        nombreComercial = entEmpresa[0].NOM_COMERCIAL
                    };
                    entAnularBol.company.address = new Address()
                    {
                        direccion = entEmpresa[0].DIRECCION,
                        provincia = entEmpresa[0].PROVINCIA,
                        departamento = entEmpresa[0].DEPARTAMENTO,
                        distrito = entEmpresa[0].DISTRITO,
                        ubigueo = entEmpresa[0].UBIGEO
                    };
                    List<Cls_Ent_Anular_Bol.DetalleAnular> detalle = new List<Cls_Ent_Anular_Bol.DetalleAnular>();
                    //string voucher = dataGridView3.CurrentRow.Cells["VOUCHER"].Value.ToString();
                    //string serie = voucher.Substring(0, 4);
                    //string correlativo = voucher.Substring(5, 8);
                    ObjCliente = new Cls_Rule_Clientes();
                    T_M_CLIENTES entCliente = ObjCliente.Buscar_Clientes(int.Parse(dataGridView3.CurrentRow.Cells["ID_CLIENTE"].Value.ToString()), ref auditoria);
                    detalle.Add(new Cls_Ent_Anular_Bol.DetalleAnular
                    {
                        tipoDoc = "03",
                        serieNro = voucher,
                        estado = "3",
                        clienteTipo = entCliente.TIPO_DOC,
                        clienteNro = entCliente.NUM_DOC,
                        mtoOperGravadas = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL_IMPORTE"].Value.ToString()),
                        mtoIGV = decimal.Parse(dataGridView3.CurrentRow.Cells["IGV"].Value.ToString()),
                        total = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL"].Value.ToString())
                    });
                    entAnularBol.details = detalle;
                    string json = JsonConvert.SerializeObject(entAnularBol);
                    var respuesta = apisPeru.Post(url, json, autorizacion);
                    dynamic objDeserialisacion = JsonConvert.DeserializeObject(respuesta.Content);
                    MessageBox.Show(respuesta.Content.Substring(respuesta.Content.IndexOf("hash")));
                    if ((bool)objDeserialisacion.sunatResponse.success)
                    {
                        url = "https://facturacion.apisperu.com/api/v1/summary/pdf";
                        respuesta = apisPeru.Post(url, json, autorizacion);

                        byte[] bytes = respuesta.RawBytes;
                        string path = Environment.CurrentDirectory + "\\bajaBoleta.pdf";
                        BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                        frmVisor = new Frm_Visor_PDF(path);
                        frmVisor.ShowDialog();

                        listaVenta = objVVenta.Buscar_Venta(id, ref auditoria);
                        foreach (var item in listaVenta)
                        {
                            // devolver el stock
                            entProducto.PRODUCTO = item.PRODUCTO;
                            listaProducto = objProducto.Buscar_Producto(entProducto, ref auditoria);
                            stock = (int)(item.CANTIDAD + listaProducto[0].STOCK);
                            objProducto.NuevoStock_Producto(listaProducto[0].ID_PRODUCTO, stock, ref auditoria);
                        }
                        entAnularVenta.VOUCHER = listaVenta[0].VOUCHER;
                        entAnularVenta.DESC_ANULAR = txtMotivoVenta.Text.Trim().ToUpper();
                        entAnularVenta.PERSONAL = listaVenta[0].PERSONAL;
                        entAnularVenta.CLIENTE = listaVenta[0].CLIENTE;
                        entAnularVenta.SUBTOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL_IMPORTE"].Value.ToString());
                        entAnularVenta.DESC_TOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["DESCT_TOTAL"].Value.ToString());
                        entAnularVenta.TOTAL = decimal.Parse(dataGridView3.CurrentRow.Cells["TOTAL"].Value.ToString());

                        entAnularVenta.FEC_OPERACION = DateTime.Parse(dataGridView3.CurrentRow.Cells["FEC_VENTA"].Value.ToString());
                        entAnularVenta.USER_OPERACION = dataGridView3.CurrentRow.Cells["USUARIO"].Value.ToString();

                        entAnularVenta.FEC_ANULAR = DateTime.Now;
                        entAnularVenta.USER_ANULAR = user;

                        if (objVenta.Anular_Venta(id, ref auditoria))
                        {

                            if (objAnularVenta.Insertar_Anular_Venta(entAnularVenta, ref auditoria))
                            {
                                objCAnular.Actualizar_C_Anular(cAnular[1].ID_C_ANULAR, numero, DateTime.Now, ref auditoria);
                                MessageBox.Show("El registro ha sido anulado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Boton_Disable(btnEliminarVenta);
                                Limpiar_Venta();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema " + respuesta.Content.Substring(respuesta.Content.IndexOf("hash")), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView3.RowCount > 0 && dataGridView3.CurrentRow.Selected)
            {
                Boton_Enable(btnEliminarVenta);

            }
        }


        //=======================================================
        //------------SECION DEL TAB PRODUCTO --------
        //=======================================================

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            //if (txtFactura.Text != "" || txtGuia.Text != "" || txtNBoleta.Text != "")
            //{
            //    Cls_Rule_Act_Stock objActStock = new Cls_Rule_Act_Stock();
            //    List<DataActStock> dataActStock = new List<DataActStock>();
            //    T_ACTUALIZAR_STOCK entActualizar = new T_ACTUALIZAR_STOCK();
            //    //entActualizar.PRODUCTO = txtProducto.Text.Trim().ToUpper();
            //    entActualizar.FACTURA = txtFactura.Text;
            //    entActualizar.GUIA = txtGuia.Text;
            //    entActualizar.NRO_BOLETA = txtNBoleta.Text;
            //    listaActStock = objActStock.Buscar_Act_Stock(entActualizar, fechaInicio, fechaFin, ref auditoria);
            //    foreach (var item in listaActStock)
            //    {
            //        dataActStock.Add(new DataActStock
            //        {
            //            ID_ACTUALIZAR = item.ID_ACTUALIZAR,
            //            PRODUCTO = item.PRODUCTO,
            //            MARCA = item.MARCA,
            //            CANTIDAD = item.CANTIDAD.ToString(),
            //            PRECIO_UND = (decimal)item.PRE_VENTA_UND,
            //            FECHA_OPERACION = (DateTime)item.FEC_OPERACION,
            //            USER_OPERACION = item.USER_OPERACION
            //        });

            //    }
            //    dataGridView4.DataSource = dataActStock;
            //    dataGridView4.Columns["ID_ACTUALIZAR"].Visible = false;
            //    dataGridView4.Columns["PRECIO_UND"].HeaderText = "PRECIO UNIDAD";
            //    dataGridView4.Columns["FECHA_OPERACION"].HeaderText = "FECHA";
            //    dataGridView4.Columns["USER_OPERACION"].Visible = false;
            //    dataGridView4.ClearSelection();
            //}
            
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Cls_Rule_Act_Stock objActSock = new Cls_Rule_Act_Stock();
            Cls_Rule_Anular_Stock objAnularStock = new Cls_Rule_Anular_Stock();
            Cls_Rule_Producto objProducto = new Cls_Rule_Producto();
            T_STOCK_ANULAR entAnularStock = new T_STOCK_ANULAR();
            T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
            List<T_M_PRODUCTO> listaProducto = new List<T_M_PRODUCTO>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            int id = 0;
            int nuevoStock = 0;
            if (dataGridView4.Rows.Count > 0)
            {
                id = int.Parse(dataGridView4.CurrentRow.Cells["ID_ACTUALIZAR"].Value.ToString());
                //if (objActSock.Anular_Act_Stock(id, ref auditoria))
                //{
                //    entAnularStock.DESC_ANULAR = txtMotivoProducto.Text.Trim().ToUpper();
                //    entAnularStock.PRODUCTO = dataGridView4.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                //    entAnularStock.CANTIDAD = int.Parse(dataGridView4.CurrentRow.Cells["CANTIDAD"].Value.ToString());
                //    entAnularStock.FEC_OPERACION = DateTime.Parse(dataGridView4.CurrentRow.Cells["FECHA_OPERACION"].Value.ToString());
                //    entAnularStock.USER_OPERACION = dataGridView4.CurrentRow.Cells["USER_OPERACION"].Value.ToString();
                //    entAnularStock.FEC_ANULAR = DateTime.Now;
                //    entAnularStock.USER_ANULAR = user;
                //    if (objAnularStock.Insertar_Anular_Stock(entAnularStock, ref auditoria))
                //    {
                //        // MODIFICAR EL PRODUCTO
                //        entProducto.PRODUCTO = entAnularStock.PRODUCTO;
                //        listaProducto = objProducto.Buscar_Producto(entProducto, ref auditoria);
                //        nuevoStock = (int)(listaProducto[0].STOCK - entAnularStock.CANTIDAD);
                //        objProducto.NuevoStock_Producto(listaProducto[0].ID_PRODUCTO, nuevoStock, ref auditoria);
                //        MessageBox.Show("El registro ha sido anulado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    listaActStock.Clear();
                //    Limpiar_Producto();
                //}
            }
        }

        private void tabPerfil_Click(object sender, EventArgs e)
        {
            if (tabPerfil.SelectedIndex == 0)
            {
                Limpiar_Servicio();
                Boton_Disable(btnEliminarServicio);
            }
            else if (tabPerfil.SelectedIndex == 1)
            {
                Limpiar_Venta();
                Boton_Disable(btnEliminarVenta);
            }
            else if (tabPerfil.SelectedIndex == 2)
            {
                Limpiar_Producto();
                Boton_Disable(btnEliminarProducto);
            }
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView4.RowCount > 0 && dataGridView4.CurrentRow.Selected)
            {
                Boton_Enable(btnEliminarProducto);

            }
        }
    }
}
