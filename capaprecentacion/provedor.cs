using conexion;
using System;
using System.Collections;
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
    public partial class provedor : Form
    {
        private DatabaseConnection conectar;
        public provedor()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();

            ActualizarDataGridView();

        }
        private void ActualizarDataGridView()

        {
            string query = "SELECT * FROM provedor"; // Reemplaza TuTabla con el nombre de tu tabla

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string numero = textBox2.Text.Trim();
            string nombre = textBox1.Text.Trim();

            try
            {
                // Consulta para verificar si la descripción ya existe
                string querySelect = "SELECT COUNT(*) FROM provedor WHERE Nombre = @nombre";
                int count = conectar.ExecuteScalar(querySelect, new { Nombre = nombre });

                if (count > 0)
                {
                    MessageBox.Show("El codigo ya existe en la base de datos.");
                    // Puedes decidir qué hacer aquí si la descripción ya existe (ej. mostrar un mensaje al usuario)
                }
                else
                {
                    // La descripción no existe, procede a insertarla
                    string queryInsert = @"
                    INSERT INTO provedor ( nombre, numero_telefono) 
                    VALUES ( @Nombre, @numero_telefono)";
                    int rowsAffected = conectar.ExecuteNonQuery(queryInsert, new
                    {
                        Nombre = nombre,
                        numero_telefono = numero
                    });

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                        // Puedes realizar acciones adicionales después de guardar la descripción
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron guardar los datos.");
                        // Manejar el caso en el que no se pudieron guardar los datos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            ActualizarDataGridView();
        }
        private int ObtenerIdSeleccionado()
        {
            // Implementa la lógica para obtener el ID de la fila seleccionada en el DataGridView
            // Por ejemplo:
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["idProvedor"].Value);
            }
            return id;
        }

        private void eliminar()
        {
            // Obtener el ID del registro que se está eliminando
            int id = ObtenerIdSeleccionado(); // Implementa tu lógica para obtener el ID seleccionado

            // Si tienes un ID válido
            if (id > 0)
            {
                // Consulta SQL para eliminar el registro en la base de datos
                string consulta = $"DELETE FROM provedor WHERE idProvedor = {id}";

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
        private void iconButton3_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void editar()
        {
            int id = ObtenerIdSeleccionado();
            string nombre = textBox1.Text.Trim();
            string numero = textBox2.Text.Trim();

            try
            {
                // Consulta para actualizar el registro
                string queryUpdate = @"
            UPDATE producto 
            SET nombre =@Nombre ,numero_telefono = @Numero
            WHERE idProvedor = @idprovedor";

                int rowsAffected = conectar.ExecuteNonQuery(queryUpdate, new
                {
                    idprovedor = id,
                    Nombre = nombre,
                    Numero = numero

                });

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datos actualizados correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudieron actualizar los datos.");
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

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nombre"].Value.ToString();
                textBox2.Text = row.Cells["numero_telefono"].Value.ToString();
            }
        }
    }
}
