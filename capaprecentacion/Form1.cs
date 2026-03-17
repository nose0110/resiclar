using conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaprecentacion
{
    public partial class Form1 : Form
    {
        private DatabaseConnection conectar;
        public Form1()
        {
            conectar = new DatabaseConnection();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtén los datos ingresados por el usuario
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {
                // Consulta para verificar las credenciales
                string query = "SELECT COUNT(*) FROM login WHERE username = @username AND password = @password";

                // Ejecuta la consulta usando tu clase de conexión
                int count = conectar.ExecuteScalar(query, new
                {
                    username = username,
                    password = password
                });

                if (count > 0)
                {
                    MessageBox.Show("inicio de secion exitoso");
                    // Aquí puedes abrir el siguiente formulario o realizar alguna acción
                    inicio mainForm = new inicio();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
