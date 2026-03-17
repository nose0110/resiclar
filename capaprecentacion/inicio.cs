using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FontAwesome.Sharp;
using conexion;
using System.Data.Common;
using System.Data;
using programa_ventas;


namespace capaprecentacion
{

    public partial class inicio : Form
    {
        private DatabaseConnection conectar;
        private static IconMenuItem MenuActivo = null;
        private static Form formularioactivo = null;

        public inicio()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();

        }

        private void abrirpestañas(IconMenuItem menu, Form formularios)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;

            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (formularioactivo != null)
            {
                formularioactivo.Close();
            }
            formularioactivo = formularios;
            formularios.TopLevel = false;
            formularios.FormBorderStyle = FormBorderStyle.None;
            formularios.Dock = DockStyle.Fill;
            formularios.BackColor = Color.SteelBlue;
            contenedor.Controls.Add(formularios);
            formularios.Show();
        }





        private void menumantenedor_Click(object sender, EventArgs e)
        {
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new usuarios());
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new categoriaw());

        }

        private void menuventas_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new ventas());

        }

        private void menucompras_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new formnuevo());

        }

        private void menuprovedores_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new provedor());

        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new clientes());

        }

        private void menureportes_Click(object sender, EventArgs e)
        {

        }



        private void iconMenuItem1_Click_1(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new usuarios());

        }

        private void seccion_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new reportescompras());

        }

        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new reportes());

        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calculadora_clik(object sender, EventArgs e)
        {
            abrirpestañas((IconMenuItem)sender, new calculadora());

        }







        // Agrega aquí tus métodos para ejecutar consultas y manipular la base de datos
    }
}
    