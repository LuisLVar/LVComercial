using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial_León_Vargas.Datos
{
    public class Conexion
    {

        //Cadena de conexion.
        private static MySqlConnection conexion = new MySqlConnection(
            "Server=localhost;Port=3306;Database=lvcomercialdb;Uid=root;Pwd=administrador;persistsecurityinfo=True;SslMode=none;"
            );
        //

        //recibir conexion
        public static MySqlConnection getConexion()
        {
            return conexion;
        }
    }
}
}
