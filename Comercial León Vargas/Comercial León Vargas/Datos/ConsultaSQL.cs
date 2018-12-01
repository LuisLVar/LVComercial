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
        public void insertarUsuario(int carnet, string nombre, string fecha_nacimiento, string email, string telefono, string user, string password, string Palabra_clave, char rol)
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
                if (rol == 'O' || rol == 'A')
                {
                    comando.CommandText = "INSERT INTO USUARIO VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i);";
                }
                else if (rol == 'E')
                {
                    comando.CommandText = "INSERT INTO ESTUDIANTE VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i);";
                }
                else if (rol == 'I')
                {
                    Console.WriteLine("Entro Instructor");
                    comando.CommandText = "INSERT INTO INSTRUCTOR VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i);";
                }
                else
                {
                    Console.WriteLine("Rol de usuario incorrecto");
                }

                //Agregar los parametros
                comando.Parameters.AddWithValue("@a", carnet);
                comando.Parameters.AddWithValue("@b", nombre);
                comando.Parameters.AddWithValue("@c", fecha_nacimiento);
                comando.Parameters.AddWithValue("@d", email);
                comando.Parameters.AddWithValue("@e", telefono);
                comando.Parameters.AddWithValue("@f", user);
                comando.Parameters.AddWithValue("@g", password);
                comando.Parameters.AddWithValue("@h", Palabra_clave);
                comando.Parameters.AddWithValue("@i", rol);


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

        public void modificarInsumo(string idMod, string id, string nombre, string tipo)
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
                comando.Parameters.AddWithValue("@a", idMod);
                comando.Parameters.AddWithValue("@b", id);
                comando.Parameters.AddWithValue("@c", nombre);
                comando.Parameters.AddWithValue("@d", tipo);

                if (nombre != "")
                {
                    comando.CommandText = "UPDATE INSUMO SET nombre = @c where id_insumo = @a";
                    insertQuery(comando);
                }
                if (id != "")
                {
                    comando.CommandText = "UPDATE INSUMO SET id_insumo = @b where id_insumo = @a";
                    insertQuery(comando);
                }
                if (tipo != "")
                {
                    comando.CommandText = "UPDATE INSUMO SET tipo = @d where id_insumo = @a";
                    insertQuery(comando);
                }



                //Ejecutar comando sql
                conectar.Close();
                MessageBox.Show(null, "Insumo modificado exitosamente", "Modificar Insumo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Error al modificar insumo, verificar datos", "Modificar Insumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
