using capadatos.Database;
using FontAwesome.Sharp;
using programa_ventas;
using SistemaHospitalario;
using System;
using System.Data;
using System.Drawing;
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
        }

        private void AjustarHeader()
        {
            if (panelHeader == null) return;
            int x = panelHeader.Width - lblNombreUsuario.Width - 20;
            lblNombreUsuario.Location = new Point(x, 32);
            lblSistemaProtegido.Location = new Point(x, 12);
        }

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

            // ── Tabla registros recientes (Fill — va primero) ─────────
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
            };
            dgvRecientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 250);
            dgvRecientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 46, 68);
            dgvRecientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRecientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 225, 245);
            dgvRecientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 46, 68);

            var panelTabla = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(14),
                Margin = new Padding(0, 10, 0, 0)
            };
            panelTabla.Paint += (s, pe) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 228, 240), 1);
                pe.Graphics.DrawRectangle(pen, 0, 0, panelTabla.Width - 1, panelTabla.Height - 1);
            };
            panelTabla.Controls.Add(dgvRecientes);
            panelTabla.Controls.Add(lblTitulo);

            // ── Tarjetas resumen (Top — va después) ───────────────────
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

            var (card1, num1, desc1) = CrearTarjeta("Pacientes hoy", "0", Color.FromArgb(59, 109, 17));
            lblCardPacientesNum = num1;
            lblCardPacientesDesc = desc1;

            var (card2, num2, desc2) = CrearTarjeta("Expedientes activos", "0", Color.FromArgb(100, 120, 160));
            lblCardActivosNum = num2;
            lblCardActivosDesc = desc2;

            var (card3, num3, desc3) = CrearTarjeta("Pendientes", "0", Color.FromArgb(163, 45, 45));
            lblCardPendientesNum = num3;
            lblCardPendientesDesc = desc3;

            panelCards.Controls.Add(card1, 0, 0);
            panelCards.Controls.Add(card2, 1, 0);
            panelCards.Controls.Add(card3, 2, 0);

            panelDashboard.Controls.Add(panelTabla);
            panelDashboard.Controls.Add(panelCards);
        }

        private (Panel card, Label numero, Label detalle) CrearTarjeta(string titulo, string valor, Color colorDetalle)
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
                pe.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            var lblTitulo = new Label
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

            var lblDetalle = new Label
            {
                Text = "Cargando...",
                Font = new Font("Segoe UI", 9F),
                ForeColor = colorDetalle,
                Dock = DockStyle.Top,
                Height = 22,
                BackColor = Color.Transparent
            };

            card.Controls.Add(lblDetalle);
            card.Controls.Add(lblNum);
            card.Controls.Add(lblTitulo);

            return (card, lblNum, lblDetalle);
        }

        // ── Carga de datos async ──────────────────────────────────────
        private async Task CargarDashboardAsync()
        {
            try
            {
                var (pacientesHoy, activos, pendientes, recientes) = await Task.Run(() =>
                {
                    using var conn = Conexion.ObtenerConexion();
                    conn.Open();

                    int pHoy = EjecutarScalar(conn,
                        "SELECT COUNT(*) FROM Pacientes WHERE CAST(fechaRegistro AS DATE) = CAST(GETDATE() AS DATE) AND activo = 1");

                    int pActivos = EjecutarScalar(conn,
                        "SELECT COUNT(*) FROM Expedientes WHERE estado = 'Activo'");

                    int pPendientes = EjecutarScalar(conn,
                        "SELECT COUNT(*) FROM Expedientes WHERE estado = 'Pendiente'");

                    var dt = new DataTable();
                    var adapter = new SqlDataAdapter(
                        @"SELECT TOP 20
                            p.nombre        AS Paciente,
                            e.fechaApertura AS Fecha,
                            e.estado        AS Estado
                          FROM Expedientes e
                          INNER JOIN Pacientes p ON e.idPaciente = p.id
                          ORDER BY e.fechaApertura DESC", conn);
                    adapter.Fill(dt);

                    return (pHoy, pActivos, pPendientes, dt);
                });

                lblCardPacientesNum.Text = pacientesHoy.ToString();
                lblCardPacientesDesc.Text = pacientesHoy == 1
                    ? "+1 registrado hoy"
                    : $"+{pacientesHoy} registrados hoy";

                lblCardActivosNum.Text = activos.ToString();
                lblCardActivosDesc.Text = "Total en sistema";

                lblCardPendientesNum.Text = pendientes.ToString();
                lblCardPendientesDesc.Text = pendientes > 0 ? "Requieren atención" : "Sin pendientes";

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

        // ── Navegación ────────────────────────────────────────────────
        private void abrirpestañas(Control menu, Form formularios)
        {
            if (MenuActivo != null)
                MenuActivo.BackColor = Color.Transparent;

            menu.BackColor = Color.FromArgb(62, 88, 124);
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

        // ── Eventos ───────────────────────────────────────────────────
        private void menumantenedor_Click(object sender, EventArgs e) { }
        private void menureportes_Click(object sender, EventArgs e) { }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void menucompras_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new formnuevo());
        private void iconMenuItem1_Click_1(object sender, EventArgs e) => abrirpestañas((Control)sender, new usuarios());
        private void iconMenuItem2_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new categoriaw());
        private void menuventas_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new ventas());
        private void menuprovedores_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new provedor());
        private void menuclientes_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new clientes());
        private void iconMenuItem3_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new reportescompras());
        private void iconMenuItem4_Click(object sender, EventArgs e) => abrirpestañas((Control)sender, new reportes());
        private void calculadora_clik(object sender, EventArgs e) => abrirpestañas((Control)sender, new calculadora());

        private void lblLogoIcon_Click(object sender, EventArgs e) { }
    }
}