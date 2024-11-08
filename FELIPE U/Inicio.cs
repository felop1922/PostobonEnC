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

namespace FELIPE_U
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            CargarProductosEnGridView();
        }



         void Inicio_Load(object sender, EventArgs e)
        {
            
        }

        public void CargarProductosEnGridView()
        {

            Console.WriteLine("AQUI");
            try
            {
                string consulta_productos = "SELECT * FROM productos";
                var conexionDB = Conexion.conexion();
                MySqlCommand command = new MySqlCommand();

                command.Connection = conexionDB;
                command.CommandText = consulta_productos;
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = command;


                
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                //dataGridViewProductos.Columns["id"].HeaderText = "ID";
                //dataGridViewProductos.Columns["producto"].HeaderText = "Producto";
                //dataGridViewProductos.Columns["precio"].HeaderText = "Precio";
                //dataGridViewProductos.Columns["cantidad"].HeaderText = "Cantidad"; 
                Console.WriteLine("AQUI2");
                conexionDB.Close();
            }
            catch (Exception)
            {

                throw;
            }
            // Llama al método ObtenerProductos para obtener los datos
            //DataTable productos = Conexion.ObtenerProductos();

            //// Asigna el DataTable al DataGridView
            //dataGridViewProductos.DataSource = productos;

            //// Configura las columnas si deseas cambiar los encabezados o el formato
            
        }


    }
}
