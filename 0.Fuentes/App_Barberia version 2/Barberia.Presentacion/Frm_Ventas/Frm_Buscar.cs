using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Frm_Cliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_Ventas
{
    public partial class Frm_Buscar : Form
    {
        //private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Producto ObjProducto = new Cls_Rule_Producto();
        //private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        //private T_M_CLIENTES entCliente = new T_M_CLIENTES();
       // private T_M_PERSONAL entPersonal = new T_M_PERSONAL();
        private T_M_PRODUCTO entProducto = new T_M_PRODUCTO();
        //Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
        List<string> lista = new List<string>();
        private string _opcion;
        public string DevolverNombre;
        string _user;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Frm_Buscar(string opcion, string user)
        {
            InitializeComponent();
            _opcion = opcion;
            _user = user;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Frm_Venta form = (Frm_Venta)this.Owner;

            if (dataGridView1.Rows.Count > 0)
            {
                if (_opcion == "PERSONAL")
                {
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                else if (_opcion == "PRODUCTO")
                {
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                else if (_opcion == "CLIENTE")
                {
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
            }
        }

        private void Cargar_Cliente()
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            lblNota.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (_opcion == "PERSONAL")
            {
                //entPersonal.NOMBRES = txtNombre.Text.Trim().ToUpper();
                //lista = ObjPersonal.Buscar_Personal(entPersonal, ref auditoria).OrderBy(x => x.NOMBRES).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
                //dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            }
            else if (_opcion == "PRODUCTO")
            {
                entProducto.PRODUCTO = txtNombre.Text.Trim().ToUpper();
                lista = ObjProducto.Buscar_Producto(entProducto, ref auditoria).OrderBy(x => x.PRODUCTO).Select(x => x.PRODUCTO).ToList();
                dataGridView1.Columns.Add("PRODUCTO", "PRODUCTO");
            }
            else if (_opcion == "CLIENTE")
            {
                //entCliente.NOMBRES = txtNombre.Text.Trim().ToUpper();
                //lista = ObjCliente.Buscar_Clientes(entCliente, ref auditoria).OrderBy(x => x.NOMBRES).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
                lista = ObjVCliente.Listar_V_Cliente(1,ref auditoria).Select(x => x.NOMBRE).ToList();
                dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
                //if (!auditoria.EJECUCION_PROCEDIMIENTO)
                //{
                //    if (auditoria.RECHAZAR)
                //    {
                //        Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                //    }
                //}
                //else
                //{
                //    dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
                //}
            }

            for (int i = 0; i < lista.Count(); i++)
            {
                dataGridView1.Rows.Add(lista[i]);
            }
            dataGridView1.ClearSelection();
        }

        private void picCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Buscar_Load(object sender, EventArgs e)
        {
            if (_opcion == "PERSONAL")
            {
                btnNuevoCliente.Enabled = false;
            }
            else if (_opcion == "PRODUCTO")
            {
                btnNuevoCliente.Enabled = false;
            }

        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Frm_RegistrarCliente frmCliente = new Frm_RegistrarCliente(_user);
            V_CLIENTE entVCliente = new V_CLIENTE();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            frmCliente.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmCliente.WindowState = FormWindowState.Normal;
            frmCliente.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            frmCliente.StartPosition = FormStartPosition.CenterScreen;
            frmCliente.btnActualizar.Visible = false;
            frmCliente.btnEliminar.Visible = false;
            _ = frmCliente.ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            //entCliente.NOMBRES = frmCliente.retornoNombre;
            entVCliente.NOMBRES = frmCliente.retornoNombre;
            lista = ObjVCliente.Buscar_V_Cliente(entVCliente, ref  auditoria).Select(x => x.NOMBRE).ToList();
            dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            //lista = ObjCliente.Buscar_Clientes(entCliente, ref auditoria).OrderBy(x => x.NOMBRES).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
            //if (!auditoria.EJECUCION_PROCEDIMIENTO)
            //{
            //    if (auditoria.RECHAZAR)
            //    {
            //        Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
            //    }
            //}
            //else
            //{
            //    dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            //}
            for (int i = 0; i < lista.Count(); i++)
            {
                dataGridView1.Rows.Add(lista[i]);
            }
            dataGridView1.ClearSelection();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
