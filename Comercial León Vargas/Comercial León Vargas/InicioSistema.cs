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
    public partial class InicioSistema : Form
    {
        Login login;
        public InicioSistema(Login login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que desea salir del sistema?", "Comercial León Vargas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                login.Show();
                login.Activate();
                this.Hide();
            }
            else if (respuesta == DialogResult.No)
            {

            }
        }
    }
}
