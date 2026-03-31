using capadatos.Database;
using conexion;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaHospitalario
{
    public partial class ExpedienteVista : Form
    {
        private readonly int _idPaciente;
        private Panel panelHeader;
        private Panel panelScroll;
        private FlowLayoutPanel flow;

        private readonly Color ColorAzul = Color.FromArgb(44, 111, 173);
        private readonly Color ColorFondo = Color.FromArgb(240, 244, 250);
        private readonly Color ColorBorde = Color.FromArgb(220, 228, 240);
        private readonly Color ColorGrisL = Color.FromArgb(248, 249, 252);

        public ExpedienteVista(int idPaciente)
        {
            _idPaciente = idPaciente;
            ConstruirUI();
            CargarDatos();
        }

        // ════════════════════════════════════════════════════════════
        //  UI BASE
        // ════════════════════════════════════════════════════════════
        private void ConstruirUI()
        {
            this.Text = "Expediente clínico";
            this.BackColor = ColorFondo;
            this.Font = new Font("Segoe UI", 9f);
            this.MinimumSize = new Size(860, 600);

            // Header azul
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = ColorAzul,
                Padding = new Padding(20, 14, 20, 14)
            };
            this.Controls.Add(panelHeader);

            // Área scroll
            panelScroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = ColorFondo,
                Padding = new Padding(24, 16, 24, 24)
            };

            flow = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.Top,
                BackColor = ColorFondo,
                Padding = new Padding(0)
            };

            panelScroll.Controls.Add(flow);
            this.Controls.Add(panelScroll);
        }

        // ════════════════════════════════════════════════════════════
        //  CARGA DE DATOS
        // ════════════════════════════════════════════════════════════
        private void CargarDatos()
        {
            try
            {
                using var conn = Conexion.ObtenerConexion();
                conn.Open();

                // ── Consulta principal ────────────────────────────────
                var sql = @"
                SELECT p.*
                FROM dbo.Pacientes p
                WHERE p.id = @id";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", _idPaciente);

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                if (dt.Rows.Count == 0) return;
                var r = dt.Rows[0];

                // ── Header ────────────────────────────────────────────
                string nombre = Val(r, "nombre");
                string expediente = Val(r, "noExpediente");
                string edad = Val(r, "edad");
                string sexo = Val(r, "sexo");
                string sangre = Val(r, "tipoSangre");
                string medico = Val(r, "medico");

                var lblNom = new Label
                {
                    Text = nombre,
                    Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(20, 12)
                };
                var lblMeta = new Label
                {
                    Text = $"Exp. #{expediente}    ·    {edad} años    ·    {sexo}    ·    {sangre}    ·    {medico}",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = Color.FromArgb(200, 225, 255),
                    AutoSize = true,
                    Location = new Point(20, 42)
                };
                panelHeader.Controls.AddRange(new Control[] { lblNom, lblMeta });

                // ════════════════════════════════════════════════════
                //  SECCIONES
                // ════════════════════════════════════════════════════

                // 1 — FICHA DE IDENTIFICACIÓN
                var s1 = Seccion("FICHA DE IDENTIFICACIÓN");
                Grid3(s1,
                    "Nombre completo", nombre,
                    "Edad", edad,
                    "Sexo", sexo);
                Grid3(s1,
                    "Ocupación", Val(r, "ocupacion"),
                    "Estado civil", Val(r, "estadoCivil"),
                    "Nacionalidad", Val(r, "nacionalidad"));
                Grid3(s1,
                    "Residencia", Val(r, "residencia"),
                    "Escolaridad", Val(r, "escolaridad"),
                    "Religión", Val(r, "religion"));
                Grid3(s1,
                    "Servicio", Val(r, "servicio"),
                    "Cama", Val(r, "cama"),
                    "No. Expediente", expediente);
                Grid2(s1,
                    "Tel. de contacto", Val(r, "telefono"),
                    "Tipo de sangre", sangre);
                flow.Controls.Add(s1);

                // 2 — ANTECEDENTES HEREDOFAMILIARES
                var s2 = Seccion("ANTECEDENTES HEREDOFAMILIARES");
                Grid3(s2,
                    "Padres vivos", Val(r, "padresVivos"),
                    "Padres fallecidos/causas", Val(r, "padresFallecidos"),
                    "Hermanos vivos", Val(r, "hermanosVivos"));
                Grid3(s2,
                    "Hermanos fallecidos/causas", Val(r, "hermanosFallecidos"),
                    "Hijos vivos", Val(r, "hijosVivos"),
                    "Hijos fallecidos/causas", Val(r, "hijosFallecidos"));
                SubSeccion(s2, "Enfermedades familiares");
                FilaEnfBool(s2, "Diabetes Mellitus tipo 2", Val(r, "famDm2"));
                FilaEnfBool(s2, "Hipertensión Arterial", Val(r, "famHta"));
                FilaEnfBool(s2, "Tuberculosis", Val(r, "famTb"));
                FilaEnfBool(s2, "Cáncer", Val(r, "famCancer"));
                FilaEnfEsp(s2, "Otras", Val(r, "famOtras"));
                flow.Controls.Add(s2);

                // 3 — ANTECEDENTES PERSONALES NO PATOLÓGICOS
                var s3 = Seccion("ANTECEDENTES PERSONALES NO PATOLÓGICOS");
                SubSeccion(s3, "Hábitos tóxicos");
                Grid3(s3,
                    "Alcohol", Val(r, "alcohol"),
                    "Tabaco", Val(r, "tabaco"),
                    "Drogas", Val(r, "drogas"));
                SubSeccion(s3, "Fisiológicos");
                Grid3(s3,
                    "Alimentación", Val(r, "alimentacion"),
                    "Dipsia", Val(r, "dipsia"),
                    "Diuresis", Val(r, "diuresis"));
                Grid3(s3,
                    "Catarsis", Val(r, "catarsis"),
                    "Somnia", Val(r, "somnia"),
                    "Otros", Val(r, "fisOtros"));
                flow.Controls.Add(s3);

                // 4 — ANTECEDENTES PERSONALES PATOLÓGICOS
                var s4 = Seccion("ANTECEDENTES PERSONALES PATOLÓGICOS");
                Grid2(s4,
                    "Infancia", Val(r, "infancia"),
                    "Adulto", Val(r, "adulto"));
                FilaEnfBool(s4, "Diabetes Mellitus tipo 2", Val(r, "patDm2"));
                FilaEnfBool(s4, "Hipertensión Arterial", Val(r, "patHta"));
                FilaEnfBool(s4, "Tuberculosis", Val(r, "patTb"));
                FilaEnfBool(s4, "Cáncer", Val(r, "patCancer"));
                FilaEnfEsp(s4, "Otras", Val(r, "patOtras"));
                Grid2(s4,
                    "Quirúrgicos", Val(r, "quirurgicos"),
                    "Traumatológicos", Val(r, "traumatologicos"));
                Grid2(s4,
                    "Alérgicos", Val(r, "alergicos"),
                    "Otros", Val(r, "patOtros"));
                flow.Controls.Add(s4);

                // 5 — GINECO-OBSTÉTRICOS
                var s5 = Seccion("GINECO-OBSTÉTRICOS");
                Grid3(s5,
                    "FUM", Val(r, "fum"),
                    "FPP", Val(r, "fpp"),
                    "Edad gestacional (sem)", Val(r, "edadGestacional"));
                Grid3(s5,
                    "Menarca", Val(r, "menarca"),
                    "Ritmo menstrual", Val(r, "ritmoMenstrual"),
                    "IRS", Val(r, "irs"));
                Grid3(s5,
                    "Núm. de parejas", Val(r, "numParejas"),
                    "Flujo genital", Val(r, "flujoGenital"),
                    "Anticonceptivos", Val(r, "anticonceptivos"));
                Grid3(s5,
                    "Gestas", Val(r, "gestas"),
                    "Partos", Val(r, "partos"),
                    "Cesáreas", Val(r, "cesareas"));
                Grid3(s5,
                    "Abortos", Val(r, "abortos"),
                    "Tipo anticoncep.", Val(r, "tipoAnticonceptivo"),
                    "Tiempo de uso", Val(r, "tiempoAnticonceptivo"));
                Grid2(s5,
                    "Última toma", Val(r, "ultimaToma"),
                    "Cirugías ginecológicas", Val(r, "cirugiasGinec"));
                AreaTexto(s5, "Otros", Val(r, "ginecoOtros"));
                flow.Controls.Add(s5);

                // 6 — EXPLORACIÓN FÍSICA
                var s6 = Seccion("EXPLORACIÓN FÍSICA");
                SubSeccion(s6, "Signos vitales");
                Grid3(s6,
                    "T.A. (mmHg)", Val(r, "ta"),
                    "F.C. / Pulso", Val(r, "fc"),
                    "F.R. (rpm)", Val(r, "fr"));
                Grid3(s6,
                    "Temperatura (°C)", Val(r, "temperatura"),
                    "SpO2 (%)", Val(r, "spo2"),
                    "IMC / BMI", Val(r, "imc"));
                Grid3(s6,
                    "Peso (kg)", Val(r, "peso"),
                    "Talla (m)", Val(r, "talla"),
                    "", "");
                SubSeccion(s6, "Por segmentos");
                foreach (var (lbl, col) in new[]{
                    ("Impresión general",    "impresionGeneral"),
                    ("Cabeza",               "cabeza"),
                    ("Cuello",               "cuello"),
                    ("Tórax",                "torax"),
                    ("Abdomen",              "abdomen"),
                    ("Tacto vaginal/rectal", "tactoVaginal"),
                    ("Extremidades",         "extremidades"),
                    ("Exploración neurológica","neurologica"),
                    ("Órganos de los sentidos","organosSentidos"),
                    ("Síntomas generales",   "sintomasGenerales")
                })
                    AreaTexto(s6, lbl, Val(r, col));
                flow.Controls.Add(s6);

                // 7 — PADECIMIENTO ACTUAL E INTERROGATORIO
                var s7 = Seccion("PADECIMIENTO ACTUAL");
                AreaTexto(s7, "Padecimiento actual", Val(r, "padecimientoActual"));
                SubSeccion(s7, "Interrogatorio por aparatos y sistemas");
                foreach (var (lbl, col) in new[]{
                    ("Aparato respiratorio",            "aparatoResp"),
                    ("Aparato digestivo",               "aparatoDig"),
                    ("Aparato cardiovascular",          "aparatoCardio"),
                    ("Aparato renal y urinario",        "aparatoRenal"),
                    ("Aparato genital",                 "aparatoGenital"),
                    ("Sistema endocrino",               "sisEndocrino"),
                    ("Sistema hematopoyético y linfático","sisHemato"),
                    ("Piel y anexos",                   "pielAnexos"),
                    ("Músculo esquelético",             "musculoEsq"),
                    ("Sistema nervioso",                "sisNervioso")
                })
                    AreaTexto(s7, lbl, Val(r, col));
                flow.Controls.Add(s7);

                // 8 — DIAGNÓSTICO Y PLAN
                var s8 = Seccion("DIAGNÓSTICO Y PLAN");
                AreaTexto(s8, "Exámenes complementarios", Val(r, "examenesComp"));
                AreaTexto(s8, "Diagnóstico presuntivo", Val(r, "diagnostico"));
                AreaTexto(s8, "Plan terapéutico", Val(r, "planTerapeutico"));
                Grid3(s8,
                    "Médico tratante", Val(r, "medicoNombre"),
                    "Cédula profesional", Val(r, "medicoCedula"),
                    "Fecha", Val(r, "fechaConsulta"));
                flow.Controls.Add(s8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar expediente: " + ex.Message);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  HELPERS DE UI
        // ════════════════════════════════════════════════════════════
        private Panel Seccion(string titulo)
        {
            var p = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = 800,
                BackColor = Color.White,
                Padding = new Padding(20, 14, 20, 16),
                Margin = new Padding(0, 0, 0, 14)
            };
            p.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using var pen = new Pen(ColorBorde, 1f);
                g.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
                g.FillRectangle(new SolidBrush(ColorAzul),
                    0, 0, 4, p.Height);
            };

            var lbl = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = ColorAzul,
                Dock = DockStyle.Top,
                Height = 28,
                Padding = new Padding(6, 0, 0, 0)
            };
            p.Controls.Add(lbl);
            return p;
        }

        private void SubSeccion(Panel p, string texto)
        {
            p.Controls.Add(new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Top,
                Height = 26,
                Padding = new Padding(6, 6, 0, 0)
            });
        }

        private void Grid3(Panel p,
            string l1, string v1, string l2, string v2, string l3, string v3)
        {
            var t = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(4, 4, 4, 0),
                BackColor = Color.Transparent
            };
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            if (!string.IsNullOrEmpty(l1)) t.Controls.Add(Campo(l1, v1));
            if (!string.IsNullOrEmpty(l2)) t.Controls.Add(Campo(l2, v2));
            if (!string.IsNullOrEmpty(l3)) t.Controls.Add(Campo(l3, v3));
            p.Controls.Add(t);
        }

        private void Grid2(Panel p,
            string l1, string v1, string l2, string v2)
        {
            var t = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(4, 4, 4, 0),
                BackColor = Color.Transparent
            };
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            t.Controls.Add(Campo(l1, v1));
            t.Controls.Add(Campo(l2, v2));
            p.Controls.Add(t);
        }

        private Panel Campo(string etiqueta, string valor)
        {
            var c = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorGrisL,
                Margin = new Padding(4),
                Padding = new Padding(10, 8, 10, 8),
                Height = 58
            };
            c.Paint += (s, e) =>
            {
                using var pen = new Pen(ColorBorde, 1f);
                e.Graphics.DrawRectangle(pen, 0, 0,
                    c.Width - 1, c.Height - 1);
            };
            c.Controls.Add(new Label
            {
                Text = etiqueta,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 16
            });
            c.Controls.Add(new Label
            {
                Text = string.IsNullOrWhiteSpace(valor) ? "—" : valor,
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.FromArgb(30, 40, 60),
                Dock = DockStyle.Fill
            });
            return c;
        }

        private void AreaTexto(Panel p, string etiqueta, string valor)
        {
            var cont = new Panel
            {
                Dock = DockStyle.Top,
                Height = string.IsNullOrWhiteSpace(valor) ? 58 : 78,
                BackColor = ColorGrisL,
                Margin = new Padding(4),
                Padding = new Padding(10, 8, 10, 8)
            };
            cont.Paint += (s, e) =>
            {
                using var pen = new Pen(ColorBorde, 1f);
                e.Graphics.DrawRectangle(pen, 0, 0,
                    cont.Width - 1, cont.Height - 1);
            };
            cont.Controls.Add(new Label
            {
                Text = etiqueta,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 16
            });
            cont.Controls.Add(new Label
            {
                Text = string.IsNullOrWhiteSpace(valor) ? "—" : valor,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(30, 40, 60),
                Dock = DockStyle.Fill,
                AutoSize = false
            });
            p.Controls.Add(cont);
        }

        private void FilaEnfBool(Panel p, string nombre, string val)
        {
            var fila = new Panel
            {
                Dock = DockStyle.Top,
                Height = 28,
                BackColor = Color.Transparent,
                Padding = new Padding(6, 4, 6, 0)
            };
            bool si = val?.ToLower() == "si" || val == "1" || val?.ToLower() == "true";
            fila.Controls.Add(new Label
            {
                Text = $"{(si ? "✔" : "✘")}  {nombre}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = si ? Color.FromArgb(30, 130, 70) : Color.FromArgb(150, 150, 150),
                Dock = DockStyle.Fill
            });
            p.Controls.Add(fila);
        }

        private void FilaEnfEsp(Panel p, string nombre, string valor)
        {
            var fila = new Panel
            {
                Dock = DockStyle.Top,
                Height = 28,
                BackColor = Color.Transparent,
                Padding = new Padding(6, 4, 6, 0)
            };
            fila.Controls.Add(new Label
            {
                Text = $"Otras: {(string.IsNullOrWhiteSpace(valor) ? "—" : valor)}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Fill
            });
            p.Controls.Add(fila);
        }

        private string Val(DataRow r, string col)
        {
            try { return r[col] == DBNull.Value ? "" : r[col].ToString(); }
            catch { return ""; }
        }
    }
}