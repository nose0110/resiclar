using conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using capaprecentacion.utilidades;

namespace capaprecentacion.complementos
{

    public partial class mdproductos2 : Form

    {
        public string DatoSeleccionado { get; private set; }
        public string nombreseleccionado { get; private set; }
        public string precio { get; private set; }
        public string stock { get; private set; }
        public string descripcion { get; private set; }
        public string provedor { get; private set; }
        public string idproductoseleccionado { get; private set; }
        private DatabaseConnection conectar;


        public mdproductos2()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();

            mdProducto_Load();
        }
        private void ActualizarDataGridView()

        {
            string query = "SELECT * FROM producto"; // Reemplaza TuTabla con el nombre de tu tabla

            try
            {
                DataTable result = conectar.ExecuteQuery(query);

                // Mostrar los resultados en el DataGridView
                dgvdata.DataSource = result;
                dgvdata.Columns["ProveedorID"].Visible = false; // Asegúrate de que el nombre sea correcto
                dgvdata.Columns["idproducto"].Visible = false; // Asegúrate de que el nombre sea correcto

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }
        private void mdProducto_Load()
        {
            ActualizarDataGridView();
            // Llenar el ComboBox con las columnas visibles del DataGridView
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Actualizar el DataGridView con los datos de la base de datos

        }



        private void btnbuscar_Click(object sender, EventArgs e)
        {
            {
                // Obtener la columna seleccionada del ComboBox
                string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

                // Obtener el texto de búsqueda del TextBox
                string textoBusqueda = txtbusqueda.Text.Trim();

                // Construir la consulta SQL con LIKE
                string query = $"SELECT * FROM producto WHERE {columnaFiltro} LIKE @TextoBusqueda";

                try
                {
                    // Ejecutar la consulta y obtener los resultados
                    DataTable resultados = conectar.ExecuteQuery(query, new { TextoBusqueda = "%" + textoBusqueda + "%" });

                    // Asignar los resultados al DataGridView
                    dgvdata.DataSource = resultados;
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción
                    MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
                }
            }

        }



        private void btnlimpiarbuscador_Click_1(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvdata_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            if (iRow >= 0)
            {
                DatoSeleccionado = dgvdata.Rows[iRow].Cells["codigo"].Value.ToString();
                nombreseleccionado = dgvdata.Rows[iRow].Cells["nombre"].Value.ToString();
                stock = numericUpDown1.Value+"";
                precio = dgvdata.Rows[iRow].Cells["precio_venta"].Value.ToString();
                idproductoseleccionado = dgvdata.Rows[iRow].Cells["idproducto"].Value.ToString();
                provedor = dgvdata.Rows[iRow].Cells["nombre_proveedor"].Value.ToString();
                descripcion = dgvdata.Rows[iRow].Cells["descripcion"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }

}
