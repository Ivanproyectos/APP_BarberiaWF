using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Recursos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Cortes
{
    public partial class Frm_Corte : Form
    {

        //private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_D_Corte ObjDCorte = new Cls_Rule_D_Corte();
        private Cls_Rule_M_Corte ObjMCorte = new Cls_Rule_M_Corte();
        private Cls_Rule_Servicio ObjServicio = new Cls_Rule_Servicio();
        Cls_Rule_Voucher objVoucher = new Cls_Rule_Voucher();

        private decimal valorTemp;
        int _idPersonal;
        string user; //usuario logeado

        public Frm_Corte(int idPersonal, string usuario)
        {
            InitializeComponent();
            _idPersonal = idPersonal;
            user = usuario;
        }

        private void Cargar_Cliente()
        {
            List<V_CLIENTE> lisVCliente = new List<V_CLIENTE>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lisVCliente = ObjVCliente.Listar_V_Cliente(1,ref auditoria);
            lisVCliente.Insert(0, new V_CLIENTE{
                ID_CLIENTE = 0,
                NOMBRE = "-- SELECCIONE --"
            });
            cmbCliente.DataSource = lisVCliente;
            cmbCliente.DisplayMember = "NOMBRE";
            cmbCliente.ValueMember = "ID_CLIENTE";

            //List<T_M_CLIENTES> lisCliente = new List<T_M_CLIENTES>();
            //Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            //lisCliente = ObjCliente.Listar_Clientes(ref auditoria).OrderBy(x => x.NOMBRES).Select(x => new T_M_CLIENTES
            //{
            //    NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
            //    ID_CLIENTE = x.ID_CLIENTE
            //}).ToList();
            //if (!auditoria.EJECUCION_PROCEDIMIENTO)
            //{
            //    if (auditoria.RECHAZAR)
            //    {
            //        Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
            //    }
            //}
            //else
            //{
            //    lisCliente.Insert(0, new T_M_CLIENTES
            //    {
            //        ID_CLIENTE = 0,
            //        NOMBRES = "-- SELECCIONE --"
            //    });
            //    cmbCliente.DataSource = lisCliente;
            //    cmbCliente.DisplayMember = "NOMBRES";
            //    cmbCliente.ValueMember = "ID_CLIENTE";
            //}
        }

        private void Frm_Corte_Load(object sender, EventArgs e)
        {
            
            List<T_M_PERSONAL> lisPersonal = new List<T_M_PERSONAL>();
            List<T_M_SERVICIO> lisServicio = new List<T_M_SERVICIO>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            Cargar_Cliente();

            lisPersonal = ObjPersonal.Listar_Personal(1,ref auditoria).OrderBy(x => x.NOMBRES).Select(x => new T_M_PERSONAL
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
            cmbPersonal.SelectedValue = _idPersonal;

            lisServicio = ObjServicio.Listar_Servicio(ref auditoria).Select(x => new T_M_SERVICIO
            {
                ID_SERVICIO = x.ID_SERVICIO,
                DES_SERVICIO = x.DES_SERVICIO
            }).OrderBy(x => x.DES_SERVICIO).ToList();
            lisServicio.Insert(0, new T_M_SERVICIO
            {
                ID_SERVICIO = 0,
                DES_SERVICIO = "-- SELECCIONE --"
            });
            cmbServicio.DataSource = lisServicio;
            cmbServicio.DisplayMember = "DES_SERVICIO";
            cmbServicio.ValueMember = "ID_SERVICIO";
            cmbServicio.SelectedIndex = 0;

            Boton_Enabled(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCorte; // ALMACENA EL ID DESPUES DE INSERTAR EN LA TABLA M_CORTE 

            T_D_CORTE entDCorte = new T_D_CORTE();
            T_M_CORTE entMCorte = new T_M_CORTE();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            bool exito = false;
            List<Data_Corte> entDataCorte = new List<Data_Corte>();
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Inserte corte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtEfectivo.Text == "")
                {
                    MessageBox.Show("Inserte efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string numero = "";
                    string serie = "";
                    string anio = "";
                    int conteoDoc = 0;

                    T_VOUCHER entVoucher = objVoucher.Listar_Voucher(ref auditoria);
                    serie = entVoucher.SERIE;
                    conteoDoc = (int)entVoucher.NUMERO;
                    anio = entVoucher.ANIO;

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
                    objVoucher.Actualizar_Voucher(conteoDoc, DateTime.Now.Year.ToString(), ref auditoria);

                    //string ultimaFila = ObjMCorte.Numero_Corte(ref auditoria);
                    //if (ultimaFila == "0")
                    //{
                    //    ultimaFila = "00000000";
                    //}
                    //int conteo = int.Parse(ultimaFila.Substring(5));
                    //int anio = int.Parse(ultimaFila.Substring(0, 4));
                    //string numero = "";
                    //if (conteo == 0)
                    //{
                    //    conteo = 1;
                    //    numero = DateTime.Now.Year.ToString() + "-00000001";
                    //}
                    //else
                    //{
                    //    if (anio == DateTime.Now.Year)
                    //    {
                    //        conteo += 1;
                    //        numero = DateTime.Now.Year.ToString() + "-" + ("00000000" + conteo).Substring(conteo.ToString().Length, 8);
                    //    }
                    //    else
                    //    {
                    //        numero = DateTime.Now.Year.ToString() + "-00000001";
                    //    }

                    //}
                    entMCorte.ID_CLIENTE = int.Parse(dataGridView1.Rows[0].Cells["IDCLIENTE"].Value.ToString());
                    entMCorte.ID_PERSONAL = int.Parse(dataGridView1.Rows[0].Cells["IDPERSONAL"].Value.ToString());
                    entMCorte.VOUCHER = numero;
                    entMCorte.TOTAL_IMPORTE = decimal.Parse(txtTotal.Text);
                    entMCorte.IGV = (decimal?)0.00;
                    entMCorte.DESCT_TOTAL = (decimal?)0.00;
                    entMCorte.TOTAL = decimal.Parse(txtTotal.Text);
                    entMCorte.EFECTIVO = txtEfectivo.Text;
                    entMCorte.VUELTO = txtVuelto.Text;
                    entMCorte.USUARIO = user;
                    entMCorte.FLG_ESTADO = "1";
                    entMCorte.FEC_CORTE = DateTime.Now;
                    idCorte = ObjMCorte.Insertar_M_Corte(entMCorte, ref auditoria);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {

                        if (idCorte > 0)
                        {
                            entDCorte.ID_CORTE = idCorte;
                            //if (i == dataGridView1.RowCount - 1)//al ultimo refistro se agrega el total
                            //{

                            //    entDCorte.CANTIDAD = Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString());
                            //        entDCorte.PRECIO = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString());
                            //    entDCorte.IMPORTE = decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                            //    entDCorte.TOTAL = valorTemp;
                            //}
                            //else
                            //{
                            //    entDCorte.CANTIDAD = Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString());
                            //    entDCorte.PRECIO = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString());
                            //    entDCorte.IMPORTE = decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                            //}
                            entDCorte.CANTIDAD = Convert.ToInt16(dataGridView1.Rows[i].Cells["CANTIDAD"].Value.ToString());
                            entDCorte.PRECIO = decimal.Parse(dataGridView1.Rows[i].Cells["PRECIO"].Value.ToString());
                            entDCorte.IMPORTE = decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                            entDCorte.ID_SERVICIO = int.Parse(dataGridView1.Rows[i].Cells["IDSERVICIO"].Value.ToString());
                            //DATOS PARA LA IMPRESION
                            if (ObjDCorte.Insertar_D_Corte(entDCorte, ref auditoria))
                            {
                                exito = true;
                            }
                        }
                    }
                    entMCorte.TOTAL = valorTemp;
                    ObjMCorte.Actualizar_M_Corte(entMCorte, ref auditoria);

                    if (exito)
                    {
                        CreaTicket Ticket1 = new CreaTicket();
                        Ticket1.TextoCentro("BARBERIA");
                        Ticket1.TextoCentro("\"EMOTIONS\"");
                        Ticket1.LineasIgual();
                        Ticket1.TextoIzquierda("VOUCHER NRO. : " + numero);
                        Ticket1.TextoExtremos(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                        Ticket1.TextoIzquierda("CLIENTE : " + dataGridView1.Rows[0].Cells["CLIENTE"].Value.ToString());
                        Ticket1.LineasGuion();
                        Ticket1.EncabezadoServicio();
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            Ticket1.AgregaArticulo(item.Cells["SERVICIO"].Value.ToString(), int.Parse(item.Cells["CANTIDAD"].Value.ToString()), double.Parse(item.Cells["PRECIO"].Value.ToString()), double.Parse(item.Cells["IMPORTE"].Value.ToString()));
                        }
                        Ticket1.LineasGuion();
                        Ticket1.AgregaTotales("TOTAL", double.Parse(valorTemp.ToString()));
                        Ticket1.AgregaTotales("EFECTIVO", double.Parse(txtEfectivo.Text));
                        Ticket1.AgregaTotales("VUELTO", double.Parse(txtVuelto.Text));
                        Ticket1.LineasGuion();
                        Ticket1.TextoCentro("AGRADECEMOS SU PREFERENCIA");
                        Ticket1.CortaTicket();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un problema al registrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Limpiar()
        {
            cmbCliente.SelectedIndex = 0;
            cmbPersonal.SelectedValue = _idPersonal;
            cmbServicio.SelectedIndex = 0;
            foreach (Control item in pnlContainer.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            txtPrecio.Text = "10.00";
            //txtDescuento.Text = "0";
            nudCantidad.Value = 1;
            valorTemp = 0;
            dataGridView1.Rows.Clear();
            errIconoError.Clear();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            validar_precio();
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            validar_precio();
        }

        private void validar_precio()
        {
            if (txtPrecio.Text == "")
            {

                txtTotal.Text = "";
                errIconoError.SetError(txtPrecio, "Ingrese número");
                txtPrecio.Focus();
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {

            bool parse;
            if (txtTotal.Text != "")
            {
                if (txtEfectivo.Text != "")
                {
                    parse = decimal.TryParse(txtEfectivo.Text, out decimal efectivo);
                    if (parse)
                    {
                        txtVuelto.Text = (efectivo - decimal.Parse(txtTotal.Text)).ToString();
                        errIconoError.Clear();
                        if (efectivo == 0)
                        {
                            txtVuelto.Text = "0";
                        }
                    }
                    else
                    {
                        errIconoError.SetError(txtEfectivo, "Ingrese número");

                    }
                }
                else
                {
                    txtVuelto.Text = "";
                    errIconoError.Clear();
                }
            }

        }

        private void picBusCliente_Click(object sender, EventArgs e)
        {
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

        private void picBusPersonal_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("PERSONAL", user);
            AddOwnedForm(form);
            form.ShowDialog();
        }


        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPres(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == 0 || cmbPersonal.SelectedIndex == 0 || cmbServicio.SelectedIndex == 0 || nudCantidad.Value == 0)
            {
                MessageBox.Show("Rellene todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                decimal subTotal;
                decimal total = 0;
                subTotal = nudCantidad.Value * decimal.Parse(txtPrecio.Text);
                dataGridView1.Rows.Add(cmbCliente.SelectedValue, cmbPersonal.SelectedValue, cmbServicio.SelectedValue, cmbPersonal.Text, cmbCliente.Text, cmbServicio.Text, nudCantidad.Text, txtPrecio.Text, subTotal.ToString("0.00"));
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    total += decimal.Parse(dataGridView1.Rows[i].Cells["IMPORTE"].Value.ToString());
                }
                valorTemp = total;
                txtTotal.Text = total.ToString();
                dataGridView1.ClearSelection();
                cmbServicio.SelectedIndex = 0;
                nudCantidad.Value = 1;
                //dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            decimal dataGrid, result;

            dataGrid = decimal.Parse(dataGridView1.CurrentRow.Cells["IMPORTE"].Value.ToString());
            
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentRow.Selected = false;
                result = valorTemp - dataGrid;
                valorTemp = result;
                txtTotal.Text = result.ToString();
            }
            else
            {
                txtTotal.Text = "";
                txtVuelto.Text = "";
            }
            Boton_Enabled(false);
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Boton_Enabled(true);
            }
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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
