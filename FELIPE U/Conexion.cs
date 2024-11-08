using MySql.Data.MySqlClient;
using System;
using System.Data; // Necesario para usar DataTable
using System.Windows.Forms;

namespace FELIPE_U
{
    internal class Conexion
    {
        private static string conexionString = "Server=localhost;Database=postobon;User ID=root;Password=123456;Pooling=true;";

        public static MySqlConnection conexion()
        {
            MySqlConnection conexionBD = new MySqlConnection(conexionString);
            try
            {
                conexionBD.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
                return conexionBD;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error de conexión: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable ObtenerProductos()
        {
            DataTable productos = new DataTable();
            string query = "SELECT * FROM productos"; // Consulta para obtener los productos

            using (MySqlConnection conexionBD = conexion())
            {
                if (conexionBD != null)
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand(query, conexionBD);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                        adapter.Fill(productos); // Llenamos el DataTable con los datos de la consulta
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al obtener productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
            }
            return productos;
        }
    }
}
