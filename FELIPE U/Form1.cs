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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conexion = Conexion.conexion();


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM usuarios WHERE nombre_perfil = @nombre AND password = @password";

            try
            {
                // Abrir la conexión
                //conexion.Open();

                // Crear el comando MySQL con la consulta y la conexión
                MySqlCommand codigo = new MySqlCommand(query, conexion);

                // Agregar parámetros para el nombre de usuario y la contraseña
                codigo.Parameters.AddWithValue("@nombre", textBoxNombrePerfil.Text);
                codigo.Parameters.AddWithValue("@password", textBoxPassword.Text);

                // Ejecutar la consulta y leer los resultados
                MySqlDataReader leer = codigo.ExecuteReader();

                // Verificar si hay resultados, lo que indica que las credenciales son correctas
                if (leer.Read())
                {
                    // Mostrar mensaje de bienvenida
                    MessageBox.Show("¡Bienvenido, " + textBoxNombrePerfil.Text + "!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    // Cerrar el formulario de inicio de sesión actual
                    this.Hide();

                    // Crear y mostrar el formulario principal de la aplicación (Inicio)
                   Inicio formInicio = new Inicio();
                    formInicio.Show();
                }
                else
                {
                    // Mostrar mensaje de error si no se encuentran coincidencias
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Cerrar el lector y la conexión
                leer.Close();
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                // Manejar errores de MySQL
                MessageBox.Show("Error en la conexión a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    
    
    
    
    }




}
