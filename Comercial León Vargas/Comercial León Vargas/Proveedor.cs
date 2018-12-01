using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial_León_Vargas
{
    class Proveedor
    {
        string nombre, nit;

        public Proveedor(string nombre, string nit)
        {
            this.nombre = nombre;
            this.nit = nit;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Nit { get => nit; set => nit = value; }
    }

}
