using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using capaprecentacion.complementos;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using conexion;

namespace capaprecentacion
{
    public partial class formnuevo : Form
    {
        private const string FilePath = "data.json";
        private DatabaseConnection conectar;

        public formnuevo()
        {
            InitializeComponent();

            conectar = new DatabaseConnection();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Cambia a la siguiente pestaña por índice
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cambia a la siguiente pestaña por índice
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex -= 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex -= 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex -= 1;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Sumamos 280 días a la FUM para obtener la FPP automáticamente
            //    DateTime fum = dateTimePicker2.Value;
            //   DateTime fpp = fum.AddDays(280);

            // Mostramos el resultado en el otro cuadro de fecha
            //   dateTimePicker2.Value = fpp;
        }

        private void labeledad_Click(object sender, EventArgs e)
        {

        }

        private void asdasdasd_Click(object sender, EventArgs e)
        {

        }

        private void estado_civil_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

