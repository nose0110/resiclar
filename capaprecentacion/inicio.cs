using capadatos.Database;
using FontAwesome.Sharp;
using programa_ventas;
using SistemaHospitalario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace capaprecentacion
{
    public partial class inicio : Form
    {
        private static Control MenuActivo = null;
        private static Form formularioactivo = null;

        private Panel panelDashboard;
        private Label lblCardPacientesNum, lblCardPacientesDesc;
        private Label lblCardActivosNum, lblCardActivosDesc;
        private Label lblCardPendientesNum, lblCardPendientesDesc;
        private DataGridView dgvRecientes;

        // ── Secciones inyectadas ──────────────────────────────────────
        private formnuevo _expedienteActivo = null;
        private readonly List<Control> _seccionControls = new List<Control>();

        public inicio()
        {
            InitializeComponent();
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = "Bienvenido Dr. " + Sesion.NombreUsuario;
            AjustarHeader();
            CrearDashboard();
            _ = CargarDashboardAsync();
            this.ActiveControl = null;

            // Conectar búsqueda
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void AjustarHeader()
        {
            if (panelHeader == null) return;
            int x = panelHeader.Width - lblNombreUsuario.Width - 20;
            lblNombreUsuario.Location = new Point(x, 32);
            lblSistemaProtegido.Location = new Point(x, 12);
        }

        // ═════════════════════════════════════════════════════════════
        // DASHBOARD
        // ═════════════════════════════════════════════════════════════
        private void CrearDashboard()
        {
            btnNuevoExpediente.Visible = false;
            btnGenerarResumen.Visible = false;
            btnExportarDB.Visible = false;
            lblPacientesRecientes.Visible = false;
            panelLinea.Visible = false;
            dgvPacientes.Visible = false;

            panelDashboard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 244, 250),
                Padding = new Padding(24, 20, 24, 20)
            };
            panelMain.Controls.Add(panelDashboard);

            var lblTitulo = new Label
            {
                Text = "Registros recientes",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 46, 68),
                Dock = DockStyle.Top,
                Height = 34,
                BackColor = Color.Transparent
            };

            dgvRecientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 10F),
                GridColor = Color.FromArgb(230, 235, 245),
                EnableHeadersVisualStyles = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ReadOnly = true
            };
            dgvRecientes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRecientes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 225, 245);
            dgvRecientes.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(33, 46, 68);
            dgvRecientes.ClearSelection();
            dgvRecientes.Enabled = false;

            var panelTabla = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(14)
            };
            panelTabla.Paint += (s, pe) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 228, 240), 1);
                pe.Graphics.DrawRectangle(pen, 0, 0,
                    panelTabla.Width - 1, panelTabla.Height - 1);
            };
            panelTabla.Controls.Add(dgvRecientes);
            panelTabla.Controls.Add(lblTitulo);

            var panelCards = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Top,
                Height = 175,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 10)
            };
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));

            var (card1, num1, desc1) = CrearTarjeta("Pacientes hoy",
                "0", Color.FromArgb(59, 109, 17));
            lblCardPacientesNum = num1; lblCardPacientesDesc = desc1;

            var (card2, num2, desc2) = CrearTarjeta("Expedientes activos",
                "0", Color.FromArgb(100, 120, 160));
            lblCardActivosNum = num2; lblCardActivosDesc = desc2;

            var (card3, num3, desc3) = CrearTarjeta("Pendientes",
                "0", Color.FromArgb(163, 45, 45));
            lblCardPendientesNum = num3; lblCardPendientesDesc = desc3;

            panelCards.Controls.Add(card1, 0, 0);
            panelCards.Controls.Add(card2, 1, 0);
            panelCards.Controls.Add(card3, 2, 0);

            panelDashboard.Controls.Add(panelTabla);
            panelDashboard.Controls.Add(panelCards);
        }

        private (Panel card, Label numero, Label detalle) CrearTarjeta(
            string titulo, string valor, Color colorDetalle)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 12, 0),
                Padding = new Padding(18)
            };
            card.Paint += (s, pe) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 228, 240), 1);
                pe.Graphics.DrawRectangle(pen, 0, 0,
                    card.Width - 1, card.Height - 1);
            };

            var lblTit = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(100, 120, 160),
                Dock = DockStyle.Top,
                Height = 24,
                BackColor = Color.Transparent
            };
            var lblNum = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 46, 68),
                Dock = DockStyle.Top,
                Height = 75,
                BackColor = Color.Transparent
            };
            var lblDet = new Label
            {
                Text = "Cargando...",
                Font = new Font("Segoe UI", 9F),
                ForeColor = colorDetalle,
                Dock = DockStyle.Top,
                Height = 22,
                BackColor = Color.Transparent
            };

            card.Controls.Add(lblDet);
            card.Controls.Add(lblNum);
            card.Controls.Add(lblTit);

            return (card, lblNum, lblDet);
        }

        private async Task CargarDashboardAsync()
        {
            try
            {
                var (pacientesHoy, activos, pendientes, recientes) =
                    await Task.Run(() =>
                    {
                        using var conn = Conexion.ObtenerConexion();
                        conn.Open();

                        int pHoy = EjecutarScalar(conn,
                            "SELECT COUNT(*) FROM Pacientes " +
                            "WHERE CAST(fechaRegistro AS DATE) = CAST(GETDATE() AS DATE) " +
                            "AND activo = 1");

                        int pActivos = EjecutarScalar(conn,
                            "SELECT COUNT(*) FROM Expedientes WHERE estado = 'Activo'");

                        int pPendientes = EjecutarScalar(conn,
                            "SELECT COUNT(*) FROM Expedientes WHERE estado = 'Pendiente'");

                        var dt = new DataTable();
                        new SqlDataAdapter(
                            @"SELECT TOP 20
                                p.nombre        AS Paciente,
                                e.fechaApertura AS Fecha,
                                e.estado        AS Estado
                              FROM Expedientes e
                              INNER JOIN Pacientes p ON e.idPaciente = p.id
                              ORDER BY e.fechaApertura DESC", conn).Fill(dt);

                        return (pHoy, pActivos, pPendientes, dt);
                    });

                lblCardPacientesNum.Text = pacientesHoy.ToString();
                lblCardPacientesDesc.Text = pacientesHoy == 1
                    ? "+1 registrado hoy"
                    : $"+{pacientesHoy} registrados hoy";

                lblCardActivosNum.Text = activos.ToString();
                lblCardActivosDesc.Text = "Total en sistema";

                lblCardPendientesNum.Text = pendientes.ToString();
                lblCardPendientesDesc.Text = pendientes > 0
                    ? "Requieren atención" : "Sin pendientes";

                dgvRecientes.DataSource = recientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el dashboard: " + ex.Message);
            }
        }

        private int EjecutarScalar(SqlConnection conn, string query)
        {
            using var cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // ═════════════════════════════════════════════════════════════
        // BÚSQUEDA DE PACIENTES
        // ═════════════════════════════════════════════════════════════
        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();

            // Limpiar si está vacío
            if (string.IsNullOrEmpty(termino))
            {
                OcultarDropdownBusqueda();
                return;
            }

            if (termino.Length < 2) return;

            try
            {
                var dt = await Task.Run(() =>
                {
                    using var conn = Conexion.ObtenerConexion();
                    conn.Open();
                    var cmd = new SqlCommand(
                        @"SELECT TOP 8
                            id,
                            nombre,
                            noExpediente,
                            edad,
                            sexo
                          FROM dbo.Pacientes
                          WHERE (nombre LIKE @t OR noExpediente LIKE @t)
                            AND activo = 1
                          ORDER BY nombre", conn);
                    cmd.Parameters.AddWithValue("@t", "%" + termino + "%");
                    var tabla = new DataTable();
                    new SqlDataAdapter(cmd).Fill(tabla);
                    return tabla;
                });

                MostrarDropdownBusqueda(dt);
            }
            catch { /* silencioso en búsqueda */ }
        }

        // ── Dropdown de resultados de búsqueda ────────────────────────
        private Panel _dropdownBusqueda = null;

        private void MostrarDropdownBusqueda(DataTable dt)
        {
            OcultarDropdownBusqueda();
            if (dt.Rows.Count == 0) return;

            // Coordenadas del txtBuscar relativas al formulario principal
            var puntoEnForm = panelHeader.PointToScreen(
                new Point(txtBuscar.Left, txtBuscar.Bottom + 2));
            var puntoLocal = this.PointToClient(puntoEnForm);

            _dropdownBusqueda = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = puntoLocal,
                Width = txtBuscar.Width,
                AutoSize = false
            };

            int yPos = 0;
            foreach (DataRow row in dt.Rows)
            {
                var nombre = row["nombre"].ToString();
                var expediente = row["noExpediente"].ToString();
                var edad = row["edad"].ToString();
                var sexo = row["sexo"].ToString();
                int idPaciente = Convert.ToInt32(row["id"]);

                var itemPanel = new Panel
                {
                    Width = txtBuscar.Width - 2,
                    Height = 44,
                    Location = new Point(0, yPos),
                    Cursor = Cursors.Hand,
                    BackColor = Color.White,
                    Tag = idPaciente
                };

                var lblNom = new Label
                {
                    Text = nombre,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(33, 46, 68),
                    Location = new Point(10, 4),
                    AutoSize = true
                };
                var lblMeta = new Label
                {
                    Text = $"Exp: {expediente}  ·  {edad} años  ·  {sexo}",
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(100, 120, 160),
                    Location = new Point(10, 24),
                    AutoSize = true
                };
                var sep = new Panel
                {
                    BackColor = Color.FromArgb(230, 235, 245),
                    Dock = DockStyle.Bottom,
                    Height = 1
                };

                itemPanel.Controls.Add(lblNom);
                itemPanel.Controls.Add(lblMeta);
                itemPanel.Controls.Add(sep);

                // Hover
                EventHandler hoverOn = (s, e) => itemPanel.BackColor =
                    Color.FromArgb(240, 245, 255);
                EventHandler hoverOff = (s, e) => itemPanel.BackColor =
                    Color.White;

                foreach (Control c in new Control[]
                    { itemPanel, lblNom, lblMeta })
                {
                    c.MouseEnter += hoverOn;
                    c.MouseLeave += hoverOff;
                    c.Click += (s, e) =>
                        SeleccionarPaciente(idPaciente, nombre);
                }

                _dropdownBusqueda.Controls.Add(itemPanel);
                yPos += 44;
            }

            _dropdownBusqueda.Height = yPos;

            // Agregarlo al formulario principal para que quede por encima de todo
            this.Controls.Add(_dropdownBusqueda);
            _dropdownBusqueda.BringToFront();

            this.Click += CerrarDropdownAlHacerClickFuera;
        }

        private void OcultarDropdownBusqueda()
        {
            if (_dropdownBusqueda != null)
            {
                panelHeader.Controls.Remove(_dropdownBusqueda);
                _dropdownBusqueda.Dispose();
                _dropdownBusqueda = null;
                this.Click -= CerrarDropdownAlHacerClickFuera;
            }
        }

        private void CerrarDropdownAlHacerClickFuera(object sender, EventArgs e)
        {
            OcultarDropdownBusqueda();
        }

        private void SeleccionarPaciente(int idPaciente, string nombrePaciente)
        {
            OcultarDropdownBusqueda();
            txtBuscar.Text = "";

            var form = new ExpedienteVista(idPaciente);
            abrirpestañas(lblNavExpedientes, form);
        }
        // ═════════════════════════════════════════════════════════════
        // SECCIONES EN SIDEBAR (solo en Expedientes)
        // ═════════════════════════════════════════════════════════════

        private void ResaltarSeccionActiva(Button btnActivo)
        {
            foreach (var c in _seccionControls.OfType<Button>())
            {
                c.BackColor = Color.Transparent;
                c.ForeColor = Color.FromArgb(210, 228, 248);
                c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
            btnActivo.BackColor = Color.FromArgb(50, 80, 115);
            btnActivo.ForeColor = Color.White;
            btnActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void LimpiarSeccionesSidebar()
        {
            foreach (var c in _seccionControls)
                panelSidebar.Controls.Remove(c);
            _seccionControls.Clear();
            _expedienteActivo = null;
        }

        // ═════════════════════════════════════════════════════════════
        // NAVEGACIÓN
        // ═════════════════════════════════════════════════════════════
        private void abrirpestañas(Control menu, Form formularios)
        {
            if (MenuActivo != null)
                MenuActivo.BackColor = Color.Transparent;

            menu.BackColor = Color.FromArgb(50, 80, 115);
            MenuActivo = menu;

            if (formularioactivo != null)
                formularioactivo.Close();

            panelMain.Visible = false;
            contenedor.Visible = true;

            formularioactivo = formularios;
            formularios.TopLevel = false;
            formularios.FormBorderStyle = FormBorderStyle.None;
            formularios.Dock = DockStyle.Fill;
            formularios.BackColor = Color.FromArgb(240, 244, 250);
            contenedor.Controls.Add(formularios);
            formularios.Show();
        }

        private void lblNavInicio_Click(object sender, EventArgs e)
        {
            LimpiarSeccionesSidebar();
            OcultarDropdownBusqueda();

            if (formularioactivo != null)
            {
                formularioactivo.Close();
                formularioactivo = null;
            }
            if (MenuActivo != null)
                MenuActivo.BackColor = Color.Transparent;

            MenuActivo = null;
            contenedor.Visible = false;
            panelMain.Visible = true;
            _ = CargarDashboardAsync();
        }

        private void navExpedientes_Click(object sender, EventArgs e)
        {
            LimpiarSeccionesSidebar();
            var form = new formnuevo();
            _expedienteActivo = form;
            abrirpestañas((Control)sender, form);
        }

        private void navResumenes_Click(object sender, EventArgs e)
        {
            LimpiarSeccionesSidebar();
            abrirpestañas((Control)sender, new reportes());
        }

        private void navRespaldo_Click(object sender, EventArgs e)
        {
            LimpiarSeccionesSidebar();
            MessageBox.Show("Módulo de Respaldo en construcción.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ═════════════════════════════════════════════════════════════
        // EVENTOS RESTANTES
        // ═════════════════════════════════════════════════════════════
        private void menumantenedor_Click(object sender, EventArgs e) { }
        private void menureportes_Click(object sender, EventArgs e) { }
        private void menuStrip1_ItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        { }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
        public void AbrirEnContenedor(Form formulario)
        {
            abrirpestañas(lblNavExpedientes, formulario);
        }

        private void menucompras_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new formnuevo());
        private void iconMenuItem1_Click_1(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new usuarios());
        private void iconMenuItem2_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new categoriaw());
        private void menuventas_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new ventas());
        private void menuclientes_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new Pacientes());
        private void iconMenuItem3_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new reportescompras());
        private void iconMenuItem4_Click(object sender, EventArgs e) =>
            abrirpestañas((Control)sender, new reportes());
        private void lblLogoIcon_Click(object sender, EventArgs e) { }
    }

}