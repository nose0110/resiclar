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
    public partial class ventas : Form
    {
        private const string FilePath = "data.json";
        private DatabaseConnection conectar;

        public ventas()
        {
            InitializeComponent();
            cargar();
            conectar = new DatabaseConnection();

            LoadData();
            this.FormClosing += new FormClosingEventHandler(this.ventas_FormClosing);

        }
  
        private void SaveData()
        {
            DataTable dataTable = (DataTable)dgvdata.DataSource;
            if (dataTable != null)
            {
                string json = JsonConvert.SerializeObject(dataTable);
                File.WriteAllText(FilePath, json);
            }
        }

        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(json);
                dgvdata.DataSource = dataTable;
            }
        }
        private void cargar()
        {
            txtidproducto.Text = "0";
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";
            txtpagocon.Text = "0";
        }
        private void ventas_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal precio = 0;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtprecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecio.Select();
                return;
            }

            if (Convert.ToInt32(txtstock.Text) < Convert.ToInt32(txtcantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool productoExistente = false;

            // Verificar si el producto ya está en la DataGridView
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["IdProducto"].Value != null && row.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int nuevaCantidad = cantidadActual + Convert.ToInt32(txtcantidad.Value);
                    if (Convert.ToInt32(txtstock.Text) < nuevaCantidad)
                    {
                        MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    // Producto encontrado, actualizar el stock

                    row.Cells["Cantidad"].Value = nuevaCantidad;

                    // Actualizar el precio total
                    decimal precioTotal = nuevaCantidad * precio;
                    row.Cells["SubTotal"].Value = precioTotal.ToString("0.00");

                    productoExistente = true;
                    break;
                }
            }

            // Si el producto no existe en la DataGridView, agregar una nueva fila
            if (!productoExistente)
            {
                dgvdata.Rows.Add(new object[] {
            txtidproducto.Text,
            txtproducto.Text,
            precio.ToString("0.00"),
            txtcantidad.Value.ToString(),
            (txtcantidad.Value * precio).ToString("0.00")
        });
            }

            calcularTotal();
            limpiarProducto();
            txtcodproducto.Select();
        }


        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";
            txtcantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        private void txttotalpagar_TextChanged(object sender, EventArgs e)
        {
            calcularcambio();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            {
                using (var frm = new mdproductos())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string dato = frm.DatoSeleccionado;
                        string stock = frm.stock;
                        string precio = frm.precio;
                        string nombre = frm.nombreseleccionado;
                        string idproducto = frm.idproductoseleccionado;
                        // Usa el dato recibido, por ejemplo, mostrarlo en un TextBox
                        txtcodproducto.Text = dato;
                        txtproducto.Text = nombre;
                        txtprecio.Text = precio;
                        txtstock.Text = stock;
                        txtidproducto.Text = idproducto;
                    }

                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Ruta de la carpeta de imágenes dentro del directorio de salida
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "delete25.png");

                // Depuración: Verificar la ruta de la imagen
                Debug.WriteLine("Ruta de la imagen: " + imagePath);

                if (File.Exists(imagePath))
                {
                    try
                    {
                        using (Image image = Image.FromFile(imagePath))
                        {
                            var w = image.Width;
                            var h = image.Height;
                            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                            e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Depuración: Mostrar el error en caso de que falle la carga de la imagen
                        Debug.WriteLine("Error al cargar la imagen: " + ex.Message);
                        e.Graphics.DrawString("X", e.CellStyle.Font, Brushes.Red, e.CellBounds);
                    }
                }
                else
                {
                    // Depuración: Mostrar un mensaje si el archivo no existe
                    Debug.WriteLine("La imagen no se encontró en la ruta especificada.");
                    e.Graphics.DrawString("X", e.CellStyle.Font, Brushes.Red, e.CellBounds);
                }

                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                dgvdata.Rows.RemoveAt(index);
                calcularTotal();
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
        }
        private void calcularcambio()
        {

            if (txttotalpagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            decimal pagacon;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);

            if (txtpagocon.Text.Trim() == "")
            {
                txtpagocon.Text = "0";
            }

            if (decimal.TryParse(txtpagocon.Text.Trim(), out pagacon))
            {

                if (pagacon < total)
                {
                    txtcambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtcambio.Text = cambio.ToString("0.00");

                }
            }



        }
        private void txtpagocon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }
        private void txtpagocon_TextChanged(object sender, EventArgs e)
        {
            calcularcambio();
        }
        private void ventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
        private void stockdisminuir()
        {

        }
        private void btncrearventa_Click(object sender, EventArgs e)
        {
            
                // Iterar sobre cada fila del DataGridView
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Ignorar filas nuevas o vacías
                    if (row.IsNewRow) continue;

                    // Obtener los datos de cada columna
                    string idproducto = row.Cells["idproducto"].Value.ToString(); // Cambia "nombre" por el nombre de tu columna
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value); // Cambia "id_proveedor" por el nombre de tu columna
                decimal precio = Convert.ToDecimal(row.Cells["precio"].Value); // Cambia "descripcion" por el nombre de tu columna
                decimal subtotal = Convert.ToDecimal(row.Cells["subtotal"].Value);


                    // Consulta para insertar los datos en la base de datos
                     string queryInsert = @"
                      INSERT INTO ventasn (idproducto, cantidad, precio, subtotal) 
                      VALUES ( @Idproducto, @Cantidad, @Precio, @Subtotal)";

                    // Ejecuta la consulta de inserción
                    int rowsAffected = conectar.ExecuteNonQuery(queryInsert, new
                    {
                        Idproducto = idproducto,
                        Cantidad = cantidad,
                        Precio = precio,
                        Subtotal = subtotal              
                    });

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                    // Mensaje de éxito al guardar la venta
                    MessageBox.Show("Datos guardados correctamente.");

                    // Reducir el stock del producto
                    string queryUpdateStock = @"
                         UPDATE producto 
                        SET stock = stock - @Cantidad
                        WHERE Idproducto = @idproducto;";

                    // Ejecuta la consulta de actualización del stock
                    int rowsUpdated = conectar.ExecuteNonQuery(queryUpdateStock, new
                    {
                        Cantidad = cantidad,
                        Idproducto = idproducto
                    });

                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Stock actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el stock.");
                    }
                }
                else
                    {
                        MessageBox.Show("No se pudieron guardar los datos.");
                    }
                }
            dgvdata.Rows.Clear(); // Esto elimina todas las filas del DataGridView


        }


    }
}

