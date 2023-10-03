using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Productos.BE;

namespace Productos.FE
{
    public partial class Form1 : Form
    {
        ListaAlumnos lista = new ListaAlumnos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)

        {


            if (ValidarDatos())
            {
                Producto producto = new Producto();

                producto.Nombre = txtNombre.Text;
                producto.Apellido = txtApellido.Text;
                producto.Año = Convert.ToDecimal(txtAno.Text);

                lista.AgregarAlumno(producto);

                lblResultado.Text = lista.Listar();

                LimpiarPantalla();
            }
            else
            {
                lblResultado.Text = " NO SE GUARDO EL REGISTRO";
                txtNombre.Focus();
                txtNombre.SelectAll();
            }

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = lista.BuscarAlumno(txtNombre.Text);

            if(producto.Nombre ==null)
            {
                txtApellido.Text = "";
                txtAno.Text = "";
                lblResultado.Text = "No se encontró al Alumno";
            }
            else
            {
                txtApellido.Text = producto.Nombre;
                txtAno.Text=producto.Nombre.ToString();
                lblResultado.Text = "Alumno Inscripto";

            }
            txtNombre.Focus();
            txtNombre.SelectAll();
        }

        private void btListar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = lista.Listar();

        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            bool resp =  lista.ModificarAlumno(txtNombre.Text, 
                                   txtApellido.Text, 
                                   ( txtAno.Text));
            if(!resp)
            {
                lblResultado.Text = "No se pudo modificar el registro "
                                     + txtNombre.Text; ;
            }
            lblResultado.Text = lista.Listar();
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            bool resp = lista.BorrarAlumno(txtNombre.Text);

            if(resp) 
            {
                lblResultado.Text = "EL ALUMNO "
                    + txtNombre.Text
                    + " SE BORRO DE LA LISTA.";
            }
            else
            {
                lblResultado.Text = "EL REGISTRO "
                    + txtNombre.Text
                    + " NO PUDO SER ELIMINADO.";
            }

            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtAno.Text = " ";

            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            bool res = false;

            if(txtNombre.Text!="" 
                && txtApellido.Text != ""
               )
            {
                res = true;
            }


            return res;
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        }
    }
    
    

