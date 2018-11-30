using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial_León_Vargas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            txtPassword.PasswordChar = '*';
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
         string usuario = txtUsuario.Text;
         string password = txtPassword.Text;
            if (usuario == "Administrador" && password == "comercial")
            {
                MessageBox.Show("Bienvenido, ingreso éxitosamente", "Comercial León Vargas", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Comercial León Vargas", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                txtPassword.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }
    }
}
