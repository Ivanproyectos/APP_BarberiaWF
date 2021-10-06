using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Frm_Cliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Barberia.Presentacion.Frm_Cortes
{
    public partial class Frm_Buscar : Form
    {
        //private Cls_Rule_Clientes ObjCliente = new Cls_Rule_Clientes();
        private Cls_Rule_V_Cliente ObjVCliente = new Cls_Rule_V_Cliente();
        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        //private T_M_CLIENTES entCliente = new T_M_CLIENTES();
        private T_M_PERSONAL entPersonal = new T_M_PERSONAL();
        private string _opcion;
        public string DevolverNombre;
        string _user;
        Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
        List<string> lista = new List<string>();

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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Frm_Corte form = (Frm_Corte)this.Owner;
            
            if (dataGridView1.Rows.Count > 0)
            {
                if (_opcion == "CLIENTE")
                {
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                else
                {
                    DevolverNombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                    
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblNota.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            if (_opcion == "CLIENTE")
            {

                lista = ObjVCliente.Listar_V_Cliente(1,ref auditoria).Select(x => x.NOMBRE).ToList();
                dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");

            }
            else if (_opcion == "PERSONAL")
            {
                entPersonal.NOMBRES = txtNombre.Text.Trim().ToUpper();
                lista = ObjPersonal.Buscar_Personal(entPersonal, ref auditoria).Select(x => x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT).ToList();
                dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            }
            
            for (int i = 0; i < lista.Count(); i++)
            {
                dataGridView1.Rows.Add(lista[i]);
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_Buscar_Load(object sender, EventArgs e)
        {
            if (_opcion != "CLIENTE")
            {
                btnNuevoCliente.Enabled = false;
            }
        }


        private void picCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            entVCliente.NOMBRES = frmCliente.retornoNombre;
            lista = ObjVCliente.Buscar_V_Cliente(entVCliente, ref auditoria).Select(x => x.NOMBRE).ToList();
            dataGridView1.Columns.Add("NOMBRES", "NOMBRES Y APELLIDOS");
            
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
