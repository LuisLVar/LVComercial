using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial_León_Vargas.Datos
{
    class ConsultaSQL
    {
        public void insertarProveedor(string nombre, string nit)
        {
            //crear un objeto conexion
            MySqlConnection conectar = Conexion.getConexion();

            Console.WriteLine("Entro insertar User");

            try
            {
                //Abrir conexion
                conectar.Open();

                //crear objeto de tipo MySqlCommand
                MySqlCommand comando = new MySqlCommand();

                //Enviar la cadena conexión
                comando.Connection = conectar;


                //Pondremos tipo text y enviar sql
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "INSERT INTO PROVEEDORES(nombre, nit) VALUES(@a, @b);";
                
                //Agregar los parametros
                comando.Parameters.AddWithValue("@a", nombre);
                comando.Parameters.AddWithValue("@b", nit);

                //Ejecutar comando sql
                try
                {
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Entro catch1");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Entro catch2");
            }
        }

        public void EditarProveedor(string nombreMod, string nombre, string nit)
        {

            //crear un objeto conexion
            MySqlConnection conectar = Conexion.getConexion();

            try
            {
                //Abrir conexion
                conectar.Open();

                //crear objeto de tipo MySqlCommand
                MySqlCommand comando = new MySqlCommand();

                //Enviar la cadena conexión
                comando.Connection = conectar;

                //Pondremos tipo text y enviar sql
                comando.CommandType = System.Data.CommandType.Text;
                //Agregar los parametros
                comando.Parameters.AddWithValue("@a", nombreMod);
                comando.Parameters.AddWithValue("@b", nombre);
                comando.Parameters.AddWithValue("@c", nit);

                if (nombre != "")
                {
                    comando.CommandText = "UPDATE PROVEEDORES SET nombre = @b where nombre = @a";
                    insertQuery(comando);
                }
                if (nit != "")
                {
                    comando.CommandText = "UPDATE PROVEEDORES SET nit = @c where nombre = @a";
                    insertQuery(comando);
                }


                //Ejecutar comando sql
                conectar.Close();
                MessageBox.Show(null, "Proveedor modificado exitosamente", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Error al modificar proveedor, verificar datos", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(e.ToString());
                Console.WriteLine("Entro catch2");
            }

        }
        public void insertQuery(MySqlCommand comando)
        {
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Entro catch1, " + e.ToString());

            }
        }

        public void EliminarProveedor(string nombre)
        {
            //crear un objeto conexion
            MySqlConnection conectar = Conexion.getConexion();

            try
            {
                //Abrir conexion
                conectar.Open();

                //crear objeto de tipo MySqlCommand
                MySqlCommand comando = new MySqlCommand();

                //Enviar la cadena conexión
                comando.Connection = conectar;


                //Pondremos tipo text y enviar sql
                comando.CommandType = System.Data.CommandType.Text;

                //Agregar los parametros
                comando.Parameters.AddWithValue("@a", nombre);


                comando.CommandText = "DELETE FROM PROVEEDORES WHERE nombre = @a";
                insertQuery(comando);
                MessageBox.Show(null, "Proveedor eliminado exitosamente", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ejecutar comando sql
                conectar.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Proveedor no elimnado, verificar datos", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(e.ToString());
                Console.WriteLine("Entro catch2");
            }

        }
    }
}
