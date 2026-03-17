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
    public partial class usuarios : Form
    {
        private DatabaseConnection conectar;

        public usuarios()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
            LoadComboBox();
            LoadComboBox2();
            ActualizarDataGridView();
            CargarProveedoresEnComboBox();
        }

        private void productos_Load(object sender, EventArgs e)
        {

        }
        private void LoadComboBox()
        {
            string consulta = "SELECT descripcion FROM cateria"; // Ajusta la consulta según tu tabla y columnas
            DataTable dataTable = conectar.ExecuteQuery(consulta);

            comboBoxCaterias.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                comboBoxCaterias.Items.Add(row["descripcion"].ToString());
            }
        }
        private void LoadComboBox2()
        {
            string consulta = "SELECT nombre FROM provedor"; // Ajusta la consulta según tu tabla y columnas
            DataTable dataTable = conectar.ExecuteQuery(consulta);

            comboBoxprovedor.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                comboBoxprovedor.Items.Add(row["nombre"].ToString());
            }
        }


        private void ActualizarDataGridView()

        {
            string query = "SELECT * FROM producto"; // Reemplaza TuTabla con el nombre de tu tabla

            try
            {
                DataTable result = conectar.ExecuteQuery(query);

                // Mostrar los resultados en el DataGridView
                dataGridView1.DataSource = result;
                dataGridView1.Columns["ProveedorID"].Visible = false; // Asegúrate de que el nombre sea correcto

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void CargarProveedoresEnComboBox()
        {
            string query = "SELECT DISTINCT nombre_proveedor FROM producto";
            DataTable dtProveedores = conectar.ExecuteQuery(query);
            ordenarp.Items.Clear();
            ordenarp.Items.Add("Todos"); // Opción para mostrar todos los proveedores
            foreach (DataRow row in dtProveedores.Rows)
            {
                ordenarp.Items.Add(row["nombre_proveedor"].ToString());
            }
            ordenarp.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            string codi = textBoxCodi.Text.Trim();
            string nombre = textBoxNombre.Text.Trim();
            string descripcion = textBoxDescripcion.Text.Trim();
            int idprovedor = (int)ObtenerId2p(comboBoxprovedor.Text);
            int idcateria = (int)ObtenerId2(comboBoxCaterias.Text);
            decimal precioCompra = decimal.Parse(textBoxPrecioCompra.Text.Trim());
            decimal precioVenta = decimal.Parse(textBoxPrecioVenta.Text.Trim());
            int stock = int.Parse(stock1.Text.Trim());
            string nombrepovedor = comboBoxprovedor.Text.Trim();
            try
            {
                // Consulta para verificar si la descripción ya existe
                string querySelect = "SELECT COUNT(*) FROM producto WHERE codigo = @Codigo";
                int count = conectar.ExecuteScalar(querySelect, new { Codigo = codi });

                if (count > 0)
                {
                    MessageBox.Show("El codigo ya existe en la base de datos.");
                    // Puedes decidir qué hacer aquí si la descripción ya existe (ej. mostrar un mensaje al usuario)
                }
                else
                {
                    // La descripción no existe, procede a insertarla
                    string queryInsert = @"
                    INSERT INTO producto ( codigo, nombre, ProveedorID,nombre_proveedor,descripcion,idcateria, precio_compra, precio_venta,stock) 
                    VALUES (@Codi, @Nombre,@Idprovedor,@nombreprovedor, @Descripcion, @Idcateria, @PrecioCompra, @PrecioVenta,@Stock)";
                    int rowsAffected = conectar.ExecuteNonQuery(queryInsert, new
                    {
                        Codi = codi,
                        Nombre = nombre,
                        Idprovedor = idprovedor,
                        nombreprovedor = nombrepovedor,
                        Descripcion = descripcion,
                        Idcateria = idcateria,
                        PrecioCompra = precioCompra,
                        PrecioVenta = precioVenta,
                        Stock = stock
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

        private void comboBoxCaterias_DataContextChanged(object sender, EventArgs e)
        {
        }
        public int ObtenerId2(string texto)
        {
            string query = "SELECT idcateria FROM cateria WHERE descripcion = @descripcion";
            DataTable result = conectar.ExecuteQuery(query, new { descripcion = texto });

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["idcateria"]);
            }
            else
            {
                throw new Exception("No se encontró el ID para el texto proporcionado.");
            }
        }
        public string ObtenerDescripcionPorId(int idcateria)
        {
            string query = "SELECT descripcion FROM cateria WHERE idcateria = @Idcateria";
            DataTable result = conectar.ExecuteQuery(query, new { Idcateria = idcateria });

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["descripcion"].ToString();
            }
            else
            {
                throw new Exception("No se encontró la descripción para el ID de categoría proporcionado.");
            }
        }
        public int ObtenerId2p(string texto)
        {
            string query = "SELECT idProvedor FROM provedor WHERE nombre = @nombre";
            DataTable result = conectar.ExecuteQuery(query, new { Nombre = texto });

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["idProvedor"]);
            }
            else
            {
                throw new Exception("No se encontró el ID para el texto proporcionado.");
            }
        }
        public string ObtenerDescripcionPorIdp(int idprovedor)
        {
            string query = "SELECT nombre FROM provedor WHERE idProvedor = @IdProvedor";
            DataTable result = conectar.ExecuteQuery(query, new { IdProvedor = idprovedor });

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["nombre"].ToString();
            }
            else
            {
                throw new Exception("No se encontró la descripción para el ID de categoría proporcionado.");
            }
        }
        private void editar()
        {
            string idproducto = label7.Text.Trim();
            string codi = textBoxCodi.Text.Trim();
            string nombre = textBoxNombre.Text.Trim();
            string descripcion = textBoxDescripcion.Text.Trim();
            int idcateria = ObtenerId2(comboBoxCaterias.Text);
            int idprovedor = ObtenerId2p(comboBoxprovedor.Text);
            string nombreprovedor = comboBoxprovedor.Text.Trim();
            decimal precioCompra;
            decimal precioVenta;
            string stock = stock1.Text.Trim();
            // Verifica que los precios se puedan convertir a decimal
            if (!decimal.TryParse(textBoxPrecioCompra.Text.Trim(), out precioCompra))
            {
                MessageBox.Show("Por favor, ingresa un precio de compra válido.");
                return;
            }

            if (!decimal.TryParse(textBoxPrecioVenta.Text.Trim(), out precioVenta))
            {
                MessageBox.Show("Por favor, ingresa un precio de venta válido.");
                return;
            }

            try
            {
                // Consulta para actualizar el registro
                string queryUpdate = @"
            UPDATE producto 
            SET codigo =@Codi ,nombre = @Nombre,ProveedorID =@IDprovedor, nombre_proveedor=@Nombre2,descripcion = @Descripcion, idcateria = @Idcateria, 
                precio_compra = @PrecioCompra, precio_venta = @PrecioVenta,stock=@Stock
            WHERE idproducto = @idproducto";

                int rowsAffected = conectar.ExecuteNonQuery(queryUpdate, new
                {
                    Idproducto = idproducto,
                    Codi = codi,
                    Nombre = nombre,
                    IDprovedor = idprovedor,
                    Nombre2 = nombreprovedor,
                    Descripcion = descripcion,
                    Idcateria = idcateria,
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    Stock = stock
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
        private void SeleccionarItemEnComboBox(ComboBox comboBox, string textoABuscar)
        {
            bool itemEncontrado = false;

            // Recorrer todos los ítems del ComboBox
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Equals(textoABuscar, StringComparison.OrdinalIgnoreCase))
                {
                    // Seleccionar el ítem si se encuentra
                    comboBox.SelectedIndex = i;
                    itemEncontrado = true;
                    break;
                }
            }

            // Mostrar un mensaje si no se encuentra el ítem
            if (!itemEncontrado)
            {
                MessageBox.Show($"El texto '{textoABuscar}' no se encuentra en el ComboBox.");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["idproducto"].Value.ToString() != "")
                {
                    label7.Text = row.Cells["idproducto"].Value.ToString();
                    textBoxCodi.Text = row.Cells["codigo"].Value.ToString();
                    textBoxNombre.Text = row.Cells["nombre"].Value.ToString();
                    textBoxDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                    textBoxPrecioCompra.Text = row.Cells["precio_compra"].Value.ToString();
                    textBoxPrecioVenta.Text = row.Cells["precio_venta"].Value.ToString();
                    stock1.Text = row.Cells["stock"].Value.ToString();
                    string buscar = row.Cells["seccion"].Value.ToString();
                  
                    int idcateria = (int)row.Cells["idcateria"].Value;

                    string descripcionCateria = ObtenerDescripcionPorId(idcateria);

                    // Supongamos que 'textoBuscado' es el texto que deseas encontrar y seleccionar en el ComboBox
                    string textoBuscado = descripcionCateria;
                    int index = comboBoxCaterias.FindStringExact(textoBuscado);
                    if (index != -1)
                    {
                        comboBoxCaterias.SelectedIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("El texto no se encontró en el ComboBox.");
                    }
                    int provedorr = (int)row.Cells["ProveedorID"].Value;

                    string nombre = ObtenerDescripcionPorIdp(provedorr);
                    // Supongamos que 'textoBuscado' es el texto que deseas encontrar y seleccionar en el ComboBox
                    string textoBuscado2 = nombre;

                    // Verificar si el texto está presente en el ComboBox
                    int index2 = comboBoxprovedor.FindStringExact(textoBuscado2);

                    if (index2 != -1)
                    {
                        // Si se encuentra, selecciona el ítem en el ComboBox
                        comboBoxprovedor.SelectedIndex = index2;
                    }
                    else
                    {
                        // Si no se encuentra, muestra un mensaje o realiza alguna otra acción
                        MessageBox.Show("El texto no se encontró en el ComboBox.");
                    }
                }

            }



        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            editar();
        }
        private int ObtenerIdSeleccionado()
        {
            // Implementa la lógica para obtener el ID de la fila seleccionada en el DataGridView
            // Por ejemplo:
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["idproducto"].Value);
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
                string consulta = $"DELETE FROM producto WHERE idproducto  = {id}";

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

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            eliminar();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxseccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ordenarp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM producto WHERE nombre_proveedor  = @NombreFiltro";

            try
            {
                // Obtener el nombre seleccionado del ComboBox
                string nombreFiltro = ordenarp.SelectedItem.ToString();
                if (nombreFiltro == "Todos")
                {
                    ActualizarDataGridView();
                }
                else
                {
                    // Ejecutar la consulta y obtener los resultados
                    DataTable resultados = conectar.ExecuteQuery(query, new
                    {
                        NombreFiltro = nombreFiltro
                    });

                    // Asignar los resultados al DataGridView
                    dataGridView1.DataSource = resultados;
                }


            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
            }
        }

        private void ordenars_SelectedIndexChanged(object sender, EventArgs e)
        {
         

       
        }
    }
}
