using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Productos.BE
{
    public class ListaAlumnos

    {
        public Producto[] Lista { get; set; } = new Producto[10];

        private int fila = 0;   

        public void AgregarAlumno(Producto dato)

        {
            Lista[fila] = dato;
            fila=fila+1;
        }

        public string Listar()
        {
            {

            }
            string respuesta = "";

            foreach(Producto item in Lista)
            {
                if (item == null)
                {
                    break;
                }
                respuesta = respuesta + item.Listar() + "\r\n";
            }

            return respuesta;
        }

        public Producto BuscarAlumno(string Nombre)
        {
            Producto Prod = new Producto();

            foreach(Producto item in Lista)
            {
                if (item == null) 
                { 
                    break; 
                }
                if (item.Nombre == Nombre)
                {
                    Prod = item;
                    break;
                }
            }
            return Prod;
        }

        public int BuscarRenglonAlumno(string codigo)
        {
            int fila = -1;
            for (int i = 0; i <= Lista.Length; i++)
            {
                if (Lista[i]==null)
                {
                    break;
                }

                if (Lista[i].Nombre == codigo)
                { 
                    fila = i; 
                    break;
                }
            }
            return fila;
        }

        public bool ModificarAlumno(string Nombre, string Apellido, string Año)
        {
            bool resp = false;
            int filaAModificar = BuscarRenglonAlumno(Nombre);

            if (filaAModificar != -1)
            {
                Lista[filaAModificar].Modificar(Nombre, Apellido, Año);
                resp = true;    
            }

            return resp;
        }

     
        public bool BorrarAlumno(string codigo)
        {
            bool pudeborrar = false;

            int filaaBorra = BuscarRenglonAlumno(codigo);
            if (filaaBorra != -1)
            {
                Lista[filaaBorra] = Lista[fila - 1]; 
                
                Lista[fila - 1] = null;

                fila = fila - 1; 
                pudeborrar = true;
            }
            return pudeborrar;
        }
    }
}
