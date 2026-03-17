using capaprecentacion.complementos;
using conexion;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace capaprecentacion
{
    public partial class clientes : Form
    {
        private DatabaseConnection conectar;
        private int currentPagarId;

        public clientes()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
            CargarPagares();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (txtNombreDeudor.Text != "")
            {
                string nombreDeudor = txtNombreDeudor.Text;
                DateTime fecha = dtpFecha.Value;

                string queryInsertPagar = "INSERT INTO Pagares (NombreDeudor, Fecha, Monto) VALUES (@NombreDeudor, @Fecha, 0)";
                conectar.ExecuteNonQuery(queryInsertPagar, new
                {
                    NombreDeudor = nombreDeudor,
                    Fecha = fecha
                });

                CargarPagares();
            }
            else
            {
                MessageBox.Show("Ingrese el nombre del deudor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarPagares()
        {
            flowLayoutPanelPagares.Controls.Clear();
            DateTime fechahoy = dtpFecha.Value;

            string querySelectPagares = "SELECT * FROM Pagares";
            DataTable pagares = conectar.ExecuteQuery(querySelectPagares);

            foreach (DataRow row in pagares.Rows)
            {
                int pagarId = Convert.ToInt32(row["Id"]);

                Panel pagarPanel = new Panel
                {
                    Size = new Size(950, 400),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.LightBlue
                };

                Label lblNombreDeudor = new Label
                {
                    Text = row["NombreDeudor"].ToString(),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblMonto = new Label
                {
                    Text = "Monto: " + Convert.ToDecimal(row["Monto"]).ToString("C"),
                    Location = new Point(10, 40),
                    AutoSize = true
                };

                Label lblFecha = new Label
                {
                    Text = "Fecha: " + Convert.ToDateTime(row["Fecha"]).ToShortDateString(),
                    Location = new Point(10, 70),
                    AutoSize = true
                };

                Label lblTotalMonto = new Label
                {
                    Text = "0.00",
                    Location = new Point(710, 290),
                    AutoSize = true
                };
                Label lblTotalpagando = new Label
                {
                    Text = "0.00",
                    Location = new Point(710, 250),
                    AutoSize = true
                };
                Label lbrestante = new Label
                {
                    Text = "deuda total :",
                    Location = new Point(710, 350),
                    AutoSize = true
                };
                Button btnPagar = new Button
                {
                    Text = "Marcar como Pagado",
                    Location = new Point(220, 10),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };
                btnPagar.Click += (s, args) =>
                {
                    string queryUpdatePagar = "UPDATE Pagares SET Pagado = TRUE WHERE Id = @Id";
                    conectar.ExecuteNonQuery(queryUpdatePagar, new { Id = pagarId });

                    flowLayoutPanelPagares.Controls.Remove(pagarPanel);
                };

                DataGridView dgvProductos = new DataGridView
                {
                    Location = new Point(10, 100),
                    Size = new Size(700, 200),
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.FixedSingle
                };

                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IdProducto",
                    HeaderText = "ID Producto",
                    DataPropertyName = "IdProducto",
                    Visible = false
                });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre del Producto",
                    DataPropertyName = "Nombre"
                });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    HeaderText = "Cantidad",
                    DataPropertyName = "Cantidad"
                });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Precio",
                    HeaderText = "Precio",
                    DataPropertyName = "Precio"
                });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "idventa",
                    HeaderText = "idventa",
                    DataPropertyName = "idventa",
                    Visible = false
                });
                dgvProductos.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);

                string querySelectProductos = "SELECT pp.IdProducto, p.Nombre, pp.Cantidad, pp.Precio FROM ProductosPagares pp INNER JOIN producto p ON pp.IdProducto = p.idproducto WHERE pp.IdPagar = @IdPagar";
                DataTable productos = conectar.ExecuteQuery(querySelectProductos, new { IdPagar = pagarId });

                dgvProductos.DataSource = productos;

                Button btnAgregarProducto = new Button
                {
                    AutoSize = true,
                    Text = "Agregar Producto",
                    Location = new Point(720, 80)
                };
                btnAgregarProducto.Click += (s, args) =>
                {
                    using (var frm = new mdproductos2())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            string idProducto = frm.idproductoseleccionado;
                            string nombre = frm.nombreseleccionado;
                            decimal cantidad = Convert.ToDecimal(frm.stock);
                            decimal precio = Convert.ToDecimal(frm.precio);

                            string queryInsertProducto = "INSERT INTO ProductosPagares (IdPagar, IdProducto, Cantidad, Precio) VALUES (@IdPagar, @IdProducto, @Cantidad, @Precio,0)";
                            conectar.ExecuteNonQuery(queryInsertProducto, new
                            {
                                IdPagar = pagarId,
                                IdProducto = idProducto,
                                Cantidad = cantidad,
                                Precio = precio
                            });

                            DataRow newRow = productos.NewRow();
                            newRow["IdProducto"] = idProducto;
                            newRow["Nombre"] = nombre;
                            newRow["Cantidad"] = cantidad;
                            newRow["Precio"] = precio;
                            productos.Rows.Add(newRow);
                            decimal totalMonto = productos.AsEnumerable()
                                            .Sum(r => Convert.ToDecimal(r["Cantidad"]) * Convert.ToDecimal(r["Precio"]));
                            lblTotalMonto.Text = "deuda total: " + totalMonto.ToString("C");


                            string queryUpdateMonto = "UPDATE Pagares SET Monto = @Monto WHERE Id = @Id";
                            conectar.ExecuteNonQuery(queryUpdateMonto, new { Monto = totalMonto, Id = pagarId });
                            string queryUpdateStock = @"
                            UPDATE producto 
                            SET stock = stock - @Cantidad
                            WHERE Idproducto = @idproducto;";

                            // Ejecuta la consulta de actualización del stock
                            int rowsUpdated = conectar.ExecuteNonQuery(queryUpdateStock, new
                            {

                                Cantidad = cantidad,
                                Idproducto = idProducto
                            });

                        }
                    }
                };
                decimal totalMonto = productos.AsEnumerable()
                                            .Sum(r => Convert.ToDecimal(r["Cantidad"]) * Convert.ToDecimal(r["Precio"]));
                lblTotalMonto.Text = "Total Monto: " + totalMonto.ToString("C");
                decimal totalPagado = 0;
                string querySelectDepositos = "SELECT SUM(Cantidad) FROM Depositos WHERE IdPagar = @IdPagar";
                object result = conectar.ExecuteScalar2(querySelectDepositos, new { IdPagar = pagarId });
                // Verifica si el resultado no es nulo y asigna el valor
                if (result != null && result != DBNull.Value)
                {
                    totalPagado = Convert.ToDecimal(result);
                }
                lblTotalpagando.Text = "total pagado" + totalPagado.ToString("C");
                decimal restante = totalMonto - totalPagado;
                lbrestante.Text = "deuda total" + restante.ToString("C");


                Button btnEliminarProducto = new Button
                {
                    AutoSize = true,
                    Text = "Eliminar Producto",
                    Location = new Point(720, 140)
                };
                btnEliminarProducto.Click += (s, args) =>
                {
                    if (indexseleccionado >= 0)
                    {
                        decimal totalMonto = productos.AsEnumerable()
                                                  .Sum(r => Convert.ToDecimal(r["Cantidad"]) * Convert.ToDecimal(r["Precio"]));
                        lblTotalMonto.Text = "Total Monto: " + totalMonto.ToString("C");

                        string queryUpdateMonto = "UPDATE Pagares SET Monto = @Monto WHERE Id = @Id";
                        conectar.ExecuteNonQuery(queryUpdateMonto, new { Monto = totalMonto, Id = pagarId });
                        string idProducto = dgvProductos.Rows[indexseleccionado].Cells["IdProducto"].Value.ToString();
                        string cantidadseleccionada = dgvProductos.Rows[indexseleccionado].Cells["Cantidad"].Value.ToString();

                        string queryDeleteProducto = "DELETE FROM ProductosPagares WHERE IdPagar = @IdPagar AND IdProducto = @IdProducto";
                        conectar.ExecuteNonQuery(queryDeleteProducto, new { IdPagar = pagarId, IdProducto = idProducto });

                        dgvProductos.Rows.RemoveAt(indexseleccionado);
                        string queryUpdateStock = @"
                         UPDATE producto 
                        SET stock = stock + @Cantidad
                        WHERE Idproducto = @idproducto;";

                        // Ejecuta la consulta de actualización del stock
                        int rowsUpdated = conectar.ExecuteNonQuery(queryUpdateStock, new
                        {
                            Cantidad = cantidadseleccionada,
                            Idproducto = idProducto
                        });
                    }
                };

                Label ldepositos = new Label
                {
                    Text = "Tipo de pago: ",
                    Location = new Point(10, 300),
                    AutoSize = true
                };

                Label cantidad = new Label
                {
                    Text = "Añadir cantidad de pago: ",
                    Location = new Point(300, 300),
                    AutoSize = true
                };

                CheckBox chkRevisado = new CheckBox
                {
                    Text = "Factura",
                    Location = new Point(180, 330),
                    AutoSize = true
                };

                TextBox txtCantidad = new TextBox
                {
                    Location = new Point(300, 340),
                    Size = new Size(200, 20)
                };

                Button btnCambiarPago = new Button
                {
                    AutoSize = true,
                    Text = "Cambiar Pago",
                    Location = new Point(510, 340)
                };
                ComboBox cmbMetodoPago = new ComboBox
                {
                    Location = new Point(10, 330),
                    Size = new Size(150, 20),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DataSource = new string[] { "Contado", "Crédito", "Deposito" }
                };
                btnCambiarPago.Click += (s, args) =>
                {
                    try
                    {
                        decimal cantidadd = decimal.Parse(txtCantidad.Text);
                        string metodoPago = cmbMetodoPago.Text;
                        bool factura = chkRevisado.Checked;

                        string queryInsertDeposito = @"
                            INSERT INTO Depositos (IdPagar, Cantidad, MetodoPago, Factura, FechaDeposito)
                            VALUES (@IdPagar, @Cantidad, @MetodoPago, @Factura, @FechaDeposito)
                            ON DUPLICATE KEY UPDATE Cantidad = @Cantidad, MetodoPago = @MetodoPago, Factura = @Factura";
                        conectar.ExecuteNonQuery(queryInsertDeposito, new
                        {
                            IdPagar = pagarId,
                            Cantidad = cantidadd,
                            MetodoPago = metodoPago,
                            Factura = factura,
                            FechaDeposito = fechahoy
                        });
                        MessageBox.Show("pago realisado con exito ");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el pago: " + ex.Message);
                    }
                };



                pagarPanel.Controls.Add(lblNombreDeudor);
                pagarPanel.Controls.Add(lblMonto);
                pagarPanel.Controls.Add(lblFecha);
                pagarPanel.Controls.Add(btnPagar);
                pagarPanel.Controls.Add(ldepositos);
                pagarPanel.Controls.Add(cmbMetodoPago);
                pagarPanel.Controls.Add(lbrestante);
                pagarPanel.Controls.Add(cantidad);
                pagarPanel.Controls.Add(txtCantidad);
                pagarPanel.Controls.Add(btnAgregarProducto);
                pagarPanel.Controls.Add(btnEliminarProducto);
                pagarPanel.Controls.Add(btnCambiarPago);
                pagarPanel.Controls.Add(lblTotalMonto);
                pagarPanel.Controls.Add(dgvProductos);
                pagarPanel.Controls.Add(lblTotalpagando);
                pagarPanel.Controls.Add(chkRevisado);

                flowLayoutPanelPagares.Controls.Add(pagarPanel);
            }
        }

        private int indexseleccionado = 0;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexseleccionado = e.RowIndex;

            }
        }

        private void flowLayoutPanelPagares_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
