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
    public partial class categoriaw : Form
    {
        private DatabaseConnection conectar;

        public categoriaw()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
            ActualizarDataGridView();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void eliminar()
        {
            // Obtener el ID del registro que se está eliminando
            int id = ObtenerIdSeleccionado(); // Implementa tu lógica para obtener el ID seleccionado

            // Si tienes un ID válido
            if (id > 0)
            {
                // Consulta SQL para eliminar el registro en la base de datos
                string consulta = $"DELETE FROM cateria WHERE idcateria = {id}";

                // Utilizar la instancia existente de DatabaseConnection
                int filasAfectadas = conectar.ExecuteNonQuery(consulta);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Eliminación exitosa");
                    // Volver a cargar los datos en el DataGridView
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
            ActualizarDataGridView();

        }
        private void editarvalor()
        {
            // Obtener el nuevo valor editado del TextBox
            string nuevoValor = textBoxDescripcion.Text;

            // Obtener el ID del registro que se está editando
            int id = ObtenerIdSeleccionado(); // Implementa tu lógica para obtener el ID seleccionado

            // Si tienes un ID válido y un nuevo valor no vacío
            if (id > 0 && !string.IsNullOrEmpty(nuevoValor))
            {
                // Escapar comillas simples en el nuevo valor
                nuevoValor = nuevoValor.Replace("'", "''");

                // Consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE cateria SET descripcion = '{nuevoValor}' WHERE idcateria = {id}";

                // Utilizar la instancia existente de DatabaseConnection
                int filasAfectadas = conectar.ExecuteNonQuery(consulta);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Actualización exitosa");
                    // Opcional: Volver a cargar los datos en el DataGridView
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro");
                }
            }
            else
            {


                MessageBox.Show("Seleccione un registro para editar y asegúrese de ingresar un valor válido.");
            }
        }
        private int ObtenerIdSeleccionado()
        {
            // Implementa la lógica para obtener el ID de la fila seleccionada en el DataGridView
            // Por ejemplo:
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["idcateria"].Value);
            }
            return id;
        }

        private void ActualizarDataGridView()

        {
            string query = "SELECT * FROM cateria"; // Reemplaza TuTabla con el nombre de tu tabla

            try
            {
                DataTable result = conectar.ExecuteQuery(query);

                // Mostrar los resultados en el DataGridView
                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {

            string query = "SELECT * FROM cateria"; // Reemplaza TuTabla con el nombre de tu tabla

            string descripcion = textBoxDescripcion.Text.Trim(); // Obtener la descripción del TextBox

            try
            {
                // Consulta para verificar si la descripción ya existe
                string querySelect = "SELECT COUNT(*) FROM cateria WHERE Descripcion = @Descripcion";
                int count = conectar.ExecuteScalar(querySelect, new { Descripcion = descripcion });

                if (count > 0)
                {
                    MessageBox.Show("La descripción ya existe en la base de datos.");
                    // Puedes decidir qué hacer aquí si la descripción ya existe (ej. mostrar un mensaje al usuario)
                }
                else
                {
                    // La descripción no existe, procede a insertarla
                    string queryInsert = "INSERT INTO cateria (Descripcion) VALUES (@Descripcion)";
                    int rowsAffected = conectar.ExecuteNonQuery(queryInsert, new { Descripcion = descripcion });

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Descripción guardada correctamente.");
                        // Puedes realizar acciones adicionales después de guardar la descripción
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la descripción.");
                        // Manejar el caso en el que no se pudo guardar la descripción
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            ActualizarDataGridView();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            editarvalor();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxDescripcion.Text = row.Cells["descripcion"].Value.ToString();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            textBoxDescripcion.Text = "";
        }
    }
}
