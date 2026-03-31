using capadatos.Database;
using capaprecentacion;
using Microsoft.Data.SqlClient;
using programa_ventas;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaHospitalario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Resize += AjustarPantalla;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            RedondearControl(PanelLogin, 40);
            RedondearControl(button1, 40);
            AjustarPantalla(null, null);
        }

        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void AjustarPantalla(object sender, EventArgs e)
        {
            int mitad = this.ClientSize.Width / 2;

            PanelIzquierdo.Location = new Point(0, 0);
            PanelIzquierdo.Size = new Size(mitad, this.ClientSize.Height);
            PanelIzquierdo.BringToFront();

            PanelDerecho.Location = new Point(mitad, 0);
            PanelDerecho.Size = new Size(this.ClientSize.Width - mitad, this.ClientSize.Height);

            PanelLogin.Left = (PanelDerecho.Width - PanelLogin.Width) / 2;
            PanelLogin.Top = (PanelDerecho.Height - PanelLogin.Height) / 2;

            Logo.Left = (PanelIzquierdo.Width - Logo.Width) / 2;
            Logo.Top = (PanelIzquierdo.Height - Logo.Height) / 2 - 80;

            txtTitulo.Left = (PanelIzquierdo.Width - txtTitulo.Width) / 2;
            txtTitulo.Top = Logo.Bottom + 10;

            label1.Left = (PanelIzquierdo.Width - label1.Width) / 2;
            label1.Top = txtTitulo.Bottom + 5;

            label2.Left = (PanelIzquierdo.Width - label2.Width) / 2;
            label2.Top = label1.Bottom + 2;

            RedondearControl(PanelLogin, 40);
            RedondearControl(button1, 40);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "Cargando...";
            button1.ForeColor = Color.White;
            try
            {
                var (nombre, idUsuario) = await Task.Run(() =>
                {
                    using SqlConnection conn = Conexion.ObtenerConexion();
                    string query = "SELECT id_usuario, nombre FROM Usuarios WHERE usuario=@usuario AND password=@password";
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    conn.Open();
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        return (reader["nombre"].ToString(), Convert.ToInt32(reader["id_usuario"]));
                    return (null, 0);
                });

                if (nombre != null)
                {
                    Sesion.NombreUsuario = nombre;
                    Sesion.IdUsuario = idUsuario;
                    new inicio().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    button1.Enabled = true;
                    button1.Text = "Entrar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                button1.Enabled = true;
                button1.Text = "Entrar";
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void PanelLogin_Paint(object sender, PaintEventArgs e) { }
    }
}