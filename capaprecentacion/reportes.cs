using conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaprecentacion
{
    public partial class reportes : Form
    {
        private DatabaseConnection conectar;

        public reportes()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscarreporte_Click(object sender, EventArgs e)
        {
            mostrar();
        }
        private void mostrar()
        {
            // Obtener las fechas seleccionadas en los DateTimePicker
            DateTime fechaInicio = txtfechainicio.Value.Date;
            DateTime fechaFin = txtfechafin.Value.Date.AddDays(1).AddSeconds(-1); // Incluye todo el día de la fechaFin

            // Verificar que la fecha de inicio no sea mayor que la fecha de fin
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.");
                return;
            }

            string queryReporte = @"
        SELECT p.codigo, p.nombre, v.cantidad, v.precio, v.subtotal, v.fecha_de_registro 
        FROM ventasn v
        JOIN producto p ON v.idproducto = p.idproducto
        WHERE v.fecha_de_registro BETWEEN @FechaInicio AND @FechaFin";
            try
            {
                // Ejecutar la consulta y obtener los resultados
                DataTable resultados = conectar.ExecuteQuery2(queryReporte, new
                {
                    FechaInicio = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                    FechaFin = fechaFin.ToString("yyyy-MM-dd HH:mm:ss")
                });

                // Asignar los resultados al DataGridView
                dgvdata.DataSource = resultados;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
            }
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {
            // Crear un nuevo libro de Excel
            using (var workbook = new XLWorkbook())
            {
                // Crear una nueva hoja de trabajo
                var worksheet = workbook.Worksheets.Add("Ventas");

                // Agregar encabezados
                for (int i = 1; i < dgvdata.Columns.Count + 1; i++)
                {
                    worksheet.Cell(1, i).Value = dgvdata.Columns[i - 1].HeaderText;
                }

                // Agregar datos
                for (int i = 0; i < dgvdata.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvdata.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgvdata.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Guardar el archivo Excel
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel";
                    saveFileDialog.FileName = "Ventas.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Datos exportados correctamente a Excel.");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private string selectedIdProductoPagare = string.Empty;
        private string selectedTipoVenta = string.Empty;
        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
