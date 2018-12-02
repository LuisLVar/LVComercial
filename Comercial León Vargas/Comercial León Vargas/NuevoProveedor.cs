using Comercial_León_Vargas.Datos;
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
    public partial class NuevoProveedor : Form
    {
        public NuevoProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNit.Text = "";
            txtNombre.Text = "";
        }

        private void NuevoProveedor_Load(object sender, EventArgs e)
        {

        }
        private void NuevoProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConsultaSQL insercion = new ConsultaSQL();
            string nombre, nit;

            nombre = txtNombre.Text;
            nit = txtNit.Text;

            MessageBox.Show(null, "Proveedor ingresado exitosamente", "Nuevo Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            insercion.insertarProveedor(nombre, nit);
            txtNit.Text = "";
            txtNombre.Text = "";
        }
    }
}
