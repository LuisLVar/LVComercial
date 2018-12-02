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
        NuevoProveedor nuevo;
        Login login;
        MostrarProveedor mostrar;
        public InicioSistema(Login login)
        {
            mostrar = new MostrarProveedor();
            nuevo = new NuevoProveedor();
            this.login = login;
            InitializeComponent();
            this.ControlBox = false;
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

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            nuevo.Show();
            nuevo.Activate();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (mostrar.IsDisposed){
                mostrar = new MostrarProveedor();
                mostrar.Show();
                mostrar.Activate();
            }
            else
            {
                mostrar.Dispose();
                mostrar = new MostrarProveedor();
                mostrar.Show();
                mostrar.Activate();
            }


        }
    }
}
