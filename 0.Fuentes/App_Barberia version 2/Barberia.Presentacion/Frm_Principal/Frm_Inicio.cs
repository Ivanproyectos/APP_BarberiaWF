using Barberia.Entidad;
using Barberia.Negocio;

using Barberia.Presentacion.Frm_Cliente;

using Barberia.Presentacion.Frm_DashBoards;
using Barberia.Presentacion.Frm_loggins;

using Barberia.Presentacion.Frm_Productos;

using Barberia.Presentacion.Frm_Ventas;
using Barberia.Presentacion.Frm_Configuracion;
using Barberia.Presentacion.Frm_AnularPryVe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace Barberia.Presentacion.Frm_Principal
{
    public partial class Frm_Inicio : Form
    {
        //Cls_Rule_C_Perfil objCPerfil = new Cls_Rule_C_Perfil();
        //Cls_Rule_M_Perfil objMPerfil = new Cls_Rule_M_Perfil();
        //Cls_Rule_Personal objPersonal = new Cls_Rule_Personal();
        Cls_Rule_Backup objBackup = new Cls_Rule_Backup();
        int _idPersonal;

        string ruta = ConfigurationManager.AppSettings["Carpeta_Backup"].ToString();
        string rutaSQL = ConfigurationManager.AppSettings["Carpeta_Sql"].ToString();
        public Frm_Inicio(string user, int IdPerfil, int IdPersonal)
        {
            InitializeComponent();
            lblUsuario.Text = user;
            _idPersonal = IdPersonal;
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            //List<T_M_PERFIL> listMPerfil = new List<T_M_PERFIL>();
            //T_M_PERFIL entMPerfil = new T_M_PERFIL();
            //List<T_M_PERSONAL> listMPersonal = new List<T_M_PERSONAL>();
            //T_M_PERSONAL entMPersonal = new T_M_PERSONAL();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();

            //entMPerfil.ID_PERFIL = IdPerfil;
            //listMPerfil = objMPerfil.Buscar_Perfil(entMPerfil, ref auditoria);
            //lblPerfil.Text = listMPerfil[0].DESCRIPCION;

            //entMPersonal.ID_PERSONAL = IdPersonal;
            //listMPersonal = objPersonal.Buscar_Personal(entMPersonal, ref auditoria);
            //lblNombrePersonal.Text = listMPersonal[0].NOMBRES;

            lista = new List<Cls_Ent_Perfil>();//objCPerfil.Listar_Perfil(ref auditoria).Where(x => x.ID_PERFIL == IdPerfil).ToList();
            foreach (var item in lista)
            {
                if (item.DESCRIPCION == btnPersonal.Text.ToUpper())
                {
                    pnlPersonal.Visible = true;
                }
                else if (item.DESCRIPCION == btnCliente.Text.ToUpper())
                {
                    pnlCliente.Visible = true;
                }
                else if (item.DESCRIPCION == btnCargo.Text.ToUpper())
                {
                    pnlCargo.Visible = true;
                }
                else if (item.DESCRIPCION == btnCorte.Text.ToUpper())
                {
                    pnlCorte.Visible = true;
                }
                else if (item.DESCRIPCION == btnPerfil.Text.ToUpper())
                {
                    pnlPerfil.Visible = true;
                }
                else if (item.DESCRIPCION == btnUsuario.Text.ToUpper())
                {
                    pnlUsuario.Visible = true;
                }
                else if (item.DESCRIPCION == btnProducto.Text.ToUpper())
                {
                    pnlProductos.Visible = true;
                }
                else if (item.DESCRIPCION == btnVenta.Text.ToUpper())
                {
                    pnlVenta.Visible = true;
                }
                else if (item.DESCRIPCION == btnReporte.Text.ToUpper())
                {
                    pnlReporte.Visible = true;
                }
                
                else if (item.DESCRIPCION == btnConfig.Text.ToUpper())
                {
                    pnlConfig.Visible = true;
                }

                else if (item.DESCRIPCION == btnAnular.Text.ToUpper())
                {
                    pnlAnular.Visible = true;
                }
                //MessageBox.Show(btnConfig.Text.ToUpper());
            }
            //this.ControlBox = false;
        }

        private void Frm_Inicio_Load(object sender, EventArgs e)
        {
            //List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            //lista = objCPerfil.Listar_Perfil().Where(x => x.ID_PERFIL == _PerfilId).ToList();
            //foreach (var item in lista)
            //{
            //    if (item.DESCRIPCION == btnPersonal.Text.ToUpper())
            //    {
            //        pnlPersonal.Visible = true;
            //    }
            //    else if (item.DESCRIPCION == btnCliente.Text.ToUpper())
            //    {
            //        pnlCliente.Visible = true;
            //    }
            //    else if (item.DESCRIPCION == btnCargo.Text.ToUpper())
            //    {
            //        pnlCargo.Visible = true;
            //    }
            //    else if (item.DESCRIPCION == btnCorte.Text.ToUpper())
            //    {
            //        pnlCorte.Visible = true;
            //    }
            //    else if (item.DESCRIPCION == btnPerfil.Text.ToUpper())
            //    {
            //        pnlPerfil.Visible = true;
            //    }
            //    else if (item.DESCRIPCION == btnUsuario.Text.ToUpper())
            //    {
            //        pnlUsuario.Visible = true;
            //    }
            //}

        }



        private void btnCliente_Click(object sender, EventArgs e)
        {

            SeguirFlecha(pnlCliente);
            visible(false);
            visible2(false);

            Frm_RegistrarCliente form = new Frm_RegistrarCliente(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }


        private void btnCorte_Click(object sender, EventArgs e)
        {


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            objBackup.Ejecutar_Backup(ruta, rutaSQL, ref auditoria);
            Frm_Loggin form = new Frm_Loggin();
            form.Show();
            this.Dispose();
            this.Close();
            
        }


        private void btnUsuario_Click(object sender, EventArgs e)
        {
  
            //visible(false);
            //visible2(false);
            //SeguirFlecha(pnlUsuario);
            //Frm_Usuario form = new Frm_Usuario(lblUsuario.Text);
            //Agregar_Form(form);
            //form.dataGridView1.ClearSelection();
        }


        private void btnProducto_Click(object sender, EventArgs e)
        {

            visible(false);
            visible2(false);
            SeguirFlecha(pnlProductos);
            Frm_Producto form = new Frm_Producto(lblUsuario.Text, lblPerfil.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {

            visible(false);
            visible2(false);
            SeguirFlecha(pnlVenta);
            Frm_Venta form = new Frm_Venta(_idPersonal, lblUsuario.Text);
            Agregar_Form(form);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            picFlecha.Visible = false;
            visible2(false);
            visible(true);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            //SeguirFlecha(pnlSubReporte);

            visible2(false);
            picFlecha.Top = pnlSubReporte.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_Dashboard form = new Frm_Dashboard();
            Agregar_Form(form);
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {

      
        }

        private void btnReporteVenta_Click(object sender, EventArgs e)
        {

            //visible2(false);
            //picFlecha.Top = pnlSubReporte.Top + ((Button)sender).Top;
            //picFlecha.Visible = true;
            //Frm_ReporteVenta form = new Frm_ReporteVenta();
            //Agregar_Form(form);
        }

        

        private void Frm_Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            //string ruta = ConfigurationManager.AppSettings["Carpeta_Backup"].ToString();
            objBackup.Ejecutar_Backup(ruta, rutaSQL, ref auditoria);
            Frm_Loggin form = new Frm_Loggin();
            this.Dispose();
            form.Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            picFlecha.Visible = false;
            visible(false);
            visible2(true);
            //pnlSubConfig.Height = 200;

        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
  
            visible(false);
            //SeguirFlecha(pnlSubConfig);
            picFlecha.Top = pnlSubConfig.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_Servicio form = new Frm_Servicio(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }

        private void btnUndMedida_Click(object sender, EventArgs e)
        {

            visible(false);
            picFlecha.Top = pnlSubConfig.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_UndMedida form = new Frm_UndMedida(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {

            visible(false);
            picFlecha.Top = pnlSubConfig.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_Modelo form = new Frm_Modelo(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {

            visible(false);
            picFlecha.Top = pnlSubConfig.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_Marca form = new Frm_Marca(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }

        #region helper

        private void Agregar_Form(Form form)
        {
            pnlContenedor.Controls.Clear();
            form.TopLevel = false;
            pnlContenedor.Controls.Add(form);
            form.Show();

        }

        private void visible(bool estado)
        {
            if (estado)
            {
                pnlSubReporte.Visible = true;

            }
            else
            {
                pnlSubReporte.Visible = false;
            }
        }

        private void visible2(bool estado)
        {
            if (estado)
            {
                pnlSubConfig.Visible = true;
            }
            else
            {
                pnlSubConfig.Visible = false;
            }
        }

        private void SeguirFlecha(Panel panel)
        {
            picFlecha.Visible = true;
            picFlecha.Top = panel.Top + 2;
        }


        private void HoverFeclaColor()
        {
            picFlecha.BackColor = System.Drawing.Color.FromArgb(0, 80, 200);
        }
        #endregion

        private void btnReporteProducto_Click(object sender, EventArgs e)
        {
            
            visible2(false);
            picFlecha.Top = pnlSubReporte.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_ReporteProducto form = new Frm_ReporteProducto();
            Agregar_Form(form);

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea hacer un Backup de la Base de Datos?", "Mensaje",MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    //string ruta = ConfigurationManager.AppSettings["Carpeta_Backup"].ToString();
                    objBackup.Ejecutar_Backup(ruta, rutaSQL, ref auditoria);
                    MessageBox.Show("Operación completada sastifactoriamente", "Mensaje", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            visible(false);
            visible2(false);
            SeguirFlecha(pnlAnular);
            Frm_Anular form = new Frm_Anular(lblUsuario.Text);
            Agregar_Form(form);
            //form.dataGridView1.ClearSelection();
        }

        private void picFlecha_Click(object sender, EventArgs e)
        {

        }

        private void pnlCorte_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReporteAnular_Click(object sender, EventArgs e)
        {
            visible2(false);
            picFlecha.Top = pnlSubReporte.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_ReporteAnular form = new Frm_ReporteAnular();
            Agregar_Form(form);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnDashProducto_Click(object sender, EventArgs e)
        {
            visible2(false);
            picFlecha.Top = pnlSubReporte.Top + ((Button)sender).Top;
            picFlecha.Visible = true;
            Frm_DashboardProducto form = new Frm_DashboardProducto();
            Agregar_Form(form);
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            visible(false);
            SeguirFlecha(pnlSubConfig);
            Frm_Empresa form = new Frm_Empresa(lblUsuario.Text);
            Agregar_Form(form);
            form.dataGridView1.ClearSelection();
        }
    }
}
