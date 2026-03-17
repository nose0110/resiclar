using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programa_ventas
{
    public partial class calculadora : Form
    {
        float porcentaje = 16;
        public calculadora()
        {



            InitializeComponent();
         

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Verificar si el TextBox está vacío
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0"; // Establecer el texto como "0"
            }
          
            float a = float.Parse(textBox1.Text);
            float iva = a + (a * (porcentaje / 100));
            float valorRedondeado = (float)Math.Round(iva, 1);
            label8.Text = valorRedondeado.ToString();
            float seleccionado = Convert.ToSingle(numericUpDown2.Value);
            float b = iva + (iva * (seleccionado / 100));
            valorRedondeado = (float)Math.Round(b, 1);
            label1.Text = valorRedondeado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (porcentaje == 0)
            {
                porcentaje = 16;
                avisoiba.Text = "el iva esta avtivado";
           

                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "0"; // Establecer el texto como "0"
                }

                float a = float.Parse(textBox1.Text);
                float iva = a + (a * (porcentaje / 100));
                float valorRedondeado = (float)Math.Round(iva, 1);
                label8.Text = valorRedondeado.ToString();
                float seleccionado = Convert.ToSingle(numericUpDown2.Value);
                float b = iva + (iva * (seleccionado / 100));
                valorRedondeado = (float)Math.Round(b, 1);
                label1.Text = valorRedondeado.ToString();
            }
            else
            {
                porcentaje = 0;
                avisoiba.Text = "el iva esta desactivado";
         

                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "0"; // Establecer el texto como "0"
                }

                float a = float.Parse(textBox1.Text);
                float iva = a + (a * (porcentaje / 100));
                float valorRedondeado = (float)Math.Round(iva, 1);
                label8.Text = valorRedondeado.ToString();
                float seleccionado = Convert.ToSingle(numericUpDown2.Value);
                float b = iva + (iva * (seleccionado / 100));
                valorRedondeado = (float)Math.Round(b, 1);
                label1.Text = valorRedondeado.ToString();
            }
          

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Cancelar la entrada si ya hay un punto decimal en el texto
            }
            // Verificar si la tecla presionada no es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancelar la entrada si no es un número, un punto decimal ni la tecla de retroceso
            }
            // Verificar si el texto del TextBox es "0"
            if (textBox1.Text == "0" && e.KeyChar != '\b' && e.KeyChar != '\r' && e.KeyChar != '.')
            {
                textBox1.Text = e.KeyChar.ToString(); // Cambiar el contenido del TextBox por la tecla tocada
                textBox1.SelectionStart = 1; // Mover el cursor al final del texto
                e.Handled = true; // Indicar que la tecla ha sido manejada
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1.Text = "0";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            float a = Convert.ToSingle(numericUpDown1.Value);
            float b = float.Parse(label1.Text);
            float c = b / a;
            float valorRedondeado = (float)Math.Round(c, 1);
            label5.Text = valorRedondeado.ToString();
        }



        private void numericUpDown1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float a = Convert.ToSingle(numericUpDown1.Value);
            float b = float.Parse(label1.Text);
            float c = b / a;
            float valorRedondeado = (float)Math.Round(c, 1);
            label5.Text = valorRedondeado.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "0"; // Establecer el texto como "0"
            }
            float porcentaje = 16;
            float a = float.Parse(textBox1.Text);
            float iva = a + (a * (porcentaje / 100));
            float valorRedondeado = (float)Math.Round(iva, 1);
            label8.Text = valorRedondeado.ToString();
            float seleccionado = Convert.ToSingle(numericUpDown2.Value);
            float b = iva + (iva * (seleccionado / 100));
            valorRedondeado = (float)Math.Round(b, 1);
            label1.Text = valorRedondeado.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            numericUpDown2.Value = 40;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            numericUpDown2.Value = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 60;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 80;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 100;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 3;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 4;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 6;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 12;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 10;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 24;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 36;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 100;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
