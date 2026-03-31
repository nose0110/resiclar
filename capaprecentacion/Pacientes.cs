using capadatos.Database;
using capaprecentacion;
using conexion;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaHospitalario
{
    public partial class Pacientes : Form
    {
        private TextBox txtBuscar;
        private FlowLayoutPanel flowPacientes;
        private Panel panelToolbar;
        private Label lblTotal;

        private readonly Color ColorAzul = Color.FromArgb(44, 111, 173);
        private readonly Color ColorFondo = Color.FromArgb(240, 244, 250);
        private readonly Color ColorBorde = Color.FromArgb(220, 228, 240);
        private readonly Color ColorVerde = Color.FromArgb(39, 174, 96);
        private readonly Color ColorGrisOsc = Color.FromArgb(150, 150, 150);

        public Pacientes()
        {
            InitializeComponent();
            ConstruirUI();
            CargarPacientes("");
        }

        // ════════════════════════════════════════════════════════════
        //  UI
        // ════════════════════════════════════════════════════════════
        private void ConstruirUI()
        {
            this.Text = "Pacientes registrados";
            this.BackColor = ColorFondo;
            this.Font = new Font("Segoe UI", 9f);

            // ── Toolbar ──────────────────────────────────────────────
            panelToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 56,
                BackColor = Color.White,
                Padding = new Padding(16, 12, 16, 12)
            };
            panelToolbar.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(ColorBorde), 0, 55,
                    panelToolbar.Width, 55);

            txtBuscar = new TextBox
            {
                PlaceholderText = "Buscar por nombre o expediente...",
                Font = new Font("Segoe UI", 10f),
                BorderStyle = BorderStyle.FixedSingle,
                Width = 320,
                Height = 30,
                Location = new Point(16, 13)
            };
            txtBuscar.TextChanged += (s, e) =>
                CargarPacientes(txtBuscar.Text.Trim());

            lblTotal = new Label
            {
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(350, 18)
            };

            panelToolbar.Controls.AddRange(new Control[] { txtBuscar, lblTotal });
            this.Controls.Add(panelToolbar);

            // ── Área de tarjetas ─────────────────────────────────────
            flowPacientes = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = ColorFondo,
                Padding = new Padding(16),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            this.Controls.Add(flowPacientes);
        }

        // ════════════════════════════════════════════════════════════
        //  CARGA DESDE BD
        // ════════════════════════════════════════════════════════════
        private void CargarPacientes(string filtro)
        {
            flowPacientes.Controls.Clear();

            try
            {
                using var conn = Conexion.ObtenerConexion();
                conn.Open();

                string sql = @"
                    SELECT id, nombre, noExpediente, edad, sexo,
                           tipoSangre, medico, activo,
                           ocupacion, estadoCivil, telefono,
                           servicio, cama, nacionalidad,
                           residencia, escolaridad, religion
                    FROM dbo.Pacientes
                    WHERE (@f = '' OR nombre LIKE @f OR noExpediente LIKE @f)
                    ORDER BY nombre";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f",
                    string.IsNullOrEmpty(filtro) ? "" : "%" + filtro + "%");

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                lblTotal.Text = $"{dt.Rows.Count} paciente(s) encontrado(s)";

                flowPacientes.SuspendLayout();
                foreach (DataRow row in dt.Rows)
                    flowPacientes.Controls.Add(CrearTarjeta(row));
                flowPacientes.ResumeLayout();
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Error al cargar pacientes";
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  TARJETA DE PACIENTE
        // ════════════════════════════════════════════════════════════
        private Panel CrearTarjeta(DataRow row)
        {
            string nombre = row["nombre"].ToString();
            string expediente = row["noExpediente"].ToString();
            string edad = row["edad"].ToString();
            string sexo = row["sexo"].ToString();
            string sangre = row["tipoSangre"].ToString();
            string medico = row["medico"].ToString();
            bool activo = row["activo"] != DBNull.Value && Convert.ToBoolean(row["activo"]);
            string ocupacion = row["ocupacion"].ToString();
            string edoCivil = row["estadoCivil"].ToString();
            string telefono = row["telefono"].ToString();
            string servicio = row["servicio"].ToString();
            string cama = row["cama"].ToString();
            int idPaciente = Convert.ToInt32(row["id"]);

            // Iniciales para avatar
            string[] partes = nombre.Split(' ');
            string iniciales = partes.Length >= 2
                ? $"{partes[0][0]}{partes[1][0]}"
                : nombre.Length > 0 ? nombre[0].ToString() : "?";

            // Color avatar basado en nombre
            Color[] paleta = {
                Color.FromArgb(214, 234, 248), Color.FromArgb(213, 245, 227),
                Color.FromArgb(253, 235, 208), Color.FromArgb(245, 208, 254),
                Color.FromArgb(254, 220, 220)
            };
            Color[] paletaTexto = {
                Color.FromArgb(26, 82, 118),  Color.FromArgb(30, 132, 73),
                Color.FromArgb(147, 81, 22),  Color.FromArgb(100, 30, 140),
                Color.FromArgb(140, 40, 40)
            };
            int idx = Math.Abs(nombre.GetHashCode()) % paleta.Length;
            Color colorAv = paleta[idx];
            Color colorAvTxt = paletaTexto[idx];

            // ── Panel contenedor ─────────────────────────────────────
            var card = new Panel
            {
                Width = 320,
                Height = 260,
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                Tag = idPaciente
            };

            card.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(ColorBorde, 1f);
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using var path = RoundedRect(rect, 10);
                g.DrawPath(pen, path);
            };

            // Hover
            card.MouseEnter += (s, e) => { card.BackColor = Color.FromArgb(247, 250, 255); };
            card.MouseLeave += (s, e) => { card.BackColor = Color.White; };
            card.Click += (s, e) => AbrirExpediente(idPaciente);

            // ── Avatar ───────────────────────────────────────────────
            var avatar = new Panel
            {
                Width = 52,
                Height = 52,
                Location = new Point(16, 16),
                BackColor = colorAv
            };
            avatar.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(colorAv),
                    0, 0, avatar.Width - 1, avatar.Height - 1);
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(iniciales,
                    new Font("Segoe UI", 14f, FontStyle.Bold),
                    new SolidBrush(colorAvTxt),
                    new RectangleF(0, 0, avatar.Width, avatar.Height), sf);
            };
            avatar.Cursor = Cursors.Hand;
            avatar.Click += (s, e) => AbrirExpediente(idPaciente);
            avatar.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(247, 250, 255);
            avatar.MouseLeave += (s, e) => card.BackColor = Color.White;
            // ── Estado (punto verde/gris) ────────────────────────────
            var dot = new Panel
            {
                Width = 10,
                Height = 10,
                Location = new Point(card.Width - 22, 16),
                BackColor = activo ? ColorVerde : ColorGrisOsc
            };
            dot.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(activo ? ColorVerde : ColorGrisOsc),
                    0, 0, 9, 9);
            };
            card.Controls.Add(dot);

            // ── Nombre ───────────────────────────────────────────────
            var lblNombre = Lbl(nombre, new Font("Segoe UI", 11f, FontStyle.Bold),
                Color.FromArgb(30, 40, 60), new Point(78, 18), 220);
            PropagateClick(lblNombre, card);
            card.Controls.Add(lblNombre);

            // ── Expediente ───────────────────────────────────────────
            var lblExp = Lbl($"Exp. #{expediente}", new Font("Segoe UI", 8.5f),
                ColorAzul, new Point(78, 42), 220);
            PropagateClick(lblExp, card);
            card.Controls.Add(lblExp);

            // ── Separador ────────────────────────────────────────────
            var sep = new Panel
            {
                Location = new Point(16, 76),
                Width = card.Width - 32,
                Height = 1,
                BackColor = ColorBorde
            };
            card.Controls.Add(sep);

            // ── Datos en dos columnas ─────────────────────────────────
            int yBase = 88;
            int col1 = 16;
            int col2 = 170;

            AgregarDato(card, "Edad / Sexo", $"{edad} años · {sexo}", col1, yBase);
            AgregarDato(card, "Tipo de sangre", sangre, col2, yBase);

            AgregarDato(card, "Ocupación", ocupacion, col1, yBase + 46);
            AgregarDato(card, "Estado civil", edoCivil, col2, yBase + 46);

            AgregarDato(card, "Servicio", servicio, col1, yBase + 92);
            AgregarDato(card, "Cama", cama, col2, yBase + 92);

            AgregarDato(card, "Teléfono", telefono, col1, yBase + 138);
            AgregarDato(card, "Médico", medico, col2, yBase + 138);

            // Propagar click a todos los hijos
            foreach (Control c in card.Controls)
                PropagateClick(c, card);

            return card;
        }

        // ════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════
        private void AgregarDato(Panel card, string etiqueta, string valor,
            int x, int y)
        {
            var lEtiq = new Label
            {
                Text = etiqueta,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                Location = new Point(x, y),
                AutoSize = false,
                Width = 140,
                Height = 16
            };
            var lVal = new Label
            {
                Text = string.IsNullOrWhiteSpace(valor) ? "—" : valor,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(30, 40, 60),
                Location = new Point(x, y + 17),
                AutoSize = false,
                Width = 140,
                Height = 20
            };
            card.Controls.Add(lEtiq);
            card.Controls.Add(lVal);
        }

        private Label Lbl(string texto, Font font, Color color,
            Point loc, int width)
        {
            return new Label
            {
                Text = texto,
                Font = font,
                ForeColor = color,
                Location = loc,
                AutoSize = false,
                Width = width,
                Height = 22
            };
        }

        private void PropagateClick(Control c, Panel card)
        {
            c.Cursor = Cursors.Hand;
            c.Click += (s, e) => AbrirExpediente((int)card.Tag);
            c.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(247, 250, 255);
            c.MouseLeave += (s, e) => card.BackColor = Color.White;
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Y,
                radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2,
                radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius * 2,
                radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void AbrirExpediente(int idPaciente)
        {
            var form = new ExpedienteVista(idPaciente);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Busca el contenedor principal de inicio
            var inicio = this.ParentForm as inicio;
            if (inicio != null)
            {
                inicio.AbrirEnContenedor(form);
            }
            else
            {
                // Fallback: abrir como ventana normal
                var vista = new ExpedienteVista(idPaciente);
                vista.Show();
            }
        }
    }
}