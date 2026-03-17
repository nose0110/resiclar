using capaprecentacion.utilidades;
using conexion;
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

namespace capaprecentacion
{
    public partial class bujias : Form
    {
        private DatabaseConnection conectar;

        public bujias()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
            CargarComboBoxConColumna();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActualizarDataGridView()

        {
            string query = "SELECT * FROM equivalencias_bujias"; // Reemplaza TuTabla con el nombre de tu tabla

            try
            {
                DataTable result = conectar.ExecuteQuery(query);

                // Mostrar los resultados en el DataGridView
                dgvEquivalencias.DataSource = result;
         

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }

        private void txtCodigoBujia_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtCodigoBujia.Text.Trim();

            // Construir la consulta SQL con LIKE
            string query = "SELECT * FROM equivalencias_bujias WHERE codigo_bujia LIKE @TextoBusqueda AND marca = @NombreFiltro";

            try
            {
                // Obtener el nombre seleccionado del ComboBox
                string nombreFiltro = cbMarca.SelectedItem.ToString();

                // Ejecutar la consulta y obtener los resultados
                DataTable resultados = conectar.ExecuteQuery(query, new
                {
                    TextoBusqueda = "%" + textoBusqueda + "%",
                    NombreFiltro = nombreFiltro
                });

                // Asignar los resultados al DataGridView
                dgvEquivalencias.DataSource = resultados;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
            }
        }
        private void CargarComboBoxConColumna()
        {
            ActualizarDataGridView();
            cbMarca.Items.Clear(); // Limpiar los elementos existentes

            foreach (DataGridViewRow row in dgvEquivalencias.Rows)
            {
                if (!row.IsNewRow) // Ignorar la fila nueva
                {
                    string nombre = row.Cells["marca"].Value?.ToString();
                    if (!string.IsNullOrEmpty(nombre) && !cbMarca.Items.Contains(nombre))
                    {
                        cbMarca.Items.Add(nombre);
                    }
                }
            }

            if (cbMarca.Items.Count > 0)
            {
                cbMarca.SelectedIndex = 0; // Seleccionar el primer elemento por defecto si hay elementos
            }
        }


    }
}
