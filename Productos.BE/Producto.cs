using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Productos.BE
{
    public class Producto
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public decimal Año { get; set; }

      
        public string Listar()
        {
      
            string respuesta = Nombre
                               + " - "
                               + Nombre
                               + " - "
                               + Año.ToString();

            return respuesta;
        }

        public void Modificar(string Nombre, string Apellido, string Año)
        {
            Nombre = Nombre;
            Apellido = Apellido;
            Año = Año;
        }
    }
}
