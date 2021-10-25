using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barberia.Entidad;
using Barberia.Negocio;
using Barberia.Presentacion.Frm_Principal;

namespace Barberia.Presentacion.Frm_loggins
{
    public partial class Frm_Loggin : Form
    {
        //Cls_Rule_Usuario objUsuario = new Cls_Rule_Usuario();
        public Frm_Loggin()
        {
            InitializeComponent();
        }

        private void Frm_Loggin_Load(object sender, EventArgs e)
        {
            pnlLoggin.BackColor = Color.FromArgb(240,237,237,237);
            this.ActiveControl = label1;
        }

        private void pnlLoggin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
            }
          
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje;
            if (txtUsuario.Text.ToUpper().Trim() != "" && txtPassword.Text.ToUpper().Trim() != "")
            {
                var md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text.Trim().ToUpper()));
                string result = BitConverter.ToString(hash).Replace("-", "");
                Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
                //mensaje = objUsuario.Login_Usuario(txtUsuario.Text, result, out int IdPerfil, out int IdPersonal, ref auditoria);

                //if (mensaje == "")
                //{
                //    Frm_Inicio form = new Frm_Inicio(txtUsuario.Text.ToUpper(), IdPerfil, IdPersonal);
                //    this.Hide();
                //    form.Show();
                    
                //}
                //else
                //{
                //    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            else
            {
                MessageBox.Show("Rellene todos los campos","Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Loggin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
