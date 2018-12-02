using Comercial_León_Vargas.Datos;
using MySql.Data.MySqlClient;
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
    public partial class MostrarProveedor : Form
    {

        MostrarProveedor mostrar;
        public MostrarProveedor()
        {
            //mostrar = new MostrarProveedor();
            InitializeComponent();

            MySqlConnection conectar = Conexion.getConexion();

            try
            {

                //Abrir conexion
                //conectar.Open();

                //crear objeto de tipo MySqlCommand
                MySqlCommand comando = new MySqlCommand("SELECT * FROM PROVEEDORES;", conectar);
                conectar.Open();
                DataTable datos = new DataTable();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);


                adaptador.Fill(datos);

                dataGridView1.DataSource = datos;
                // dataGridView1.DataBind();
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);



                conectar.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Entro catch2");
            }

            try
            {
                comboBox1.Items.Clear();
                if (dataGridView1.RowCount != 1)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
                        {
                            break;
                        }
                        comboBox1.Items.Add(row.Cells[1].Value.ToString());
                    }
                }
            }
            catch
            {

            }
            

        }

        private void MostrarProveedor_Load(object sender, EventArgs e)
        {

        }
        private void MostrarProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            if (selected == "")
            {
                MessageBox.Show("Elige una opción correcta");
            }
            else
            {
                ConsultaSQL insercion = new ConsultaSQL();

                insercion.EliminarProveedor(selected);
                comboBox1.Text = "";
                txtNombre.Text = "";
                txtNit.Text = "";

                //MessageBox.Show(selected);
                this.Dispose();
                mostrar = new MostrarProveedor();
                mostrar.Show();
                mostrar.Activate();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string nombre = txtNombre.Text;
            string nit = txtNit.Text;
            if (selected == "")
            {
                MessageBox.Show("Elige una opción correcta");
            }
            else
            {
                ConsultaSQL insercion = new ConsultaSQL();

                insercion.EditarProveedor(selected, nombre, nit);
                comboBox1.Text = "";
                txtNombre.Text = "";
                txtNit.Text = "";

                //MessageBox.Show(selected);
                this.Dispose();
                mostrar = new MostrarProveedor();
                mostrar.Show();
                mostrar.Activate();
            }
        }
    }
}
