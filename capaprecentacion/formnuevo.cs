using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using conexion;
using programa_ventas;

namespace capaprecentacion
{
    public partial class formnuevo : Form
    {
        private DatabaseConnection conectar;

        public formnuevo() : this(0) { }

        // Constructor para cargar expediente existente
        public formnuevo(int idPaciente)
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
            this.Load += formnuevo_Load;
            this.Resize += formnuevo_Resize;

            if (idPaciente > 0)
                _ = CargarExpedienteAsync(idPaciente);
        }
        private void formnuevo_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            // Seleccionar la primera sección al abrir
            NavegateToSection(0);
        }

        private void formnuevo_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        private void AjustarLayout()
        {
            if (this.Width == 0 || this.Height == 0) return;

            // Sidebar interno siempre visible
            pnlSidebar.Visible = true;
            pnlVLine.Visible = true;

            // Sidebar ocupa toda la altura
            pnlSidebar.Height = this.Height;

            // pnlContent ocupa el resto del ancho y toda la altura
            pnlContent.Location = new System.Drawing.Point(pnlSidebar.Width + 1, 0);
            pnlContent.Width = this.Width - pnlSidebar.Width - 1;
            pnlContent.Height = this.Height;

            // tabControl ocupa todo el pnlContent
            tabControl1.Width = pnlContent.Width;
            tabControl1.Height = pnlContent.Height - pnlTopBar.Height;

            // Estilo claro del sidebar interno
            pnlSidebar.BackColor = Color.FromArgb(67, 105, 142);
            lblPatientName.ForeColor = Color.FromArgb(255, 255, 255);
            lblPatientMeta.ForeColor = Color.FromArgb(255, 255, 255);
            lblExpLabel.ForeColor = Color.FromArgb(255, 255, 255);
            lblExpValue.ForeColor = Color.FromArgb(255, 255, 255);
            lblCamaLabel.ForeColor = Color.FromArgb(255, 255, 255);
            lblCamaValue.ForeColor = Color.FromArgb(255, 255, 255);
            lblInitials.BackColor = Color.FromArgb(225, 235, 248);
            lblInitials.ForeColor = Color.White;
            lblNavTitle.ForeColor = Color.FromArgb(255, 255, 255);
            pnlSepSide.BackColor = Color.FromArgb(255, 255, 255);

            Button[] btns = { btnNav1, btnNav2, btnNav3, btnNav4,
                       btnNav5, btnNav6, btnNav7, btnNav8 };
            foreach (var b in btns)
            {
                b.ForeColor = Color.FromArgb(220, 235, 250);
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 235, 248);
            }
        }
        // ═════════════════════════════════════════════════════════════════
        // NAVEGACIÓN LATERAL (sidebar interno del formnuevo)
        // ═════════════════════════════════════════════════════════════════
        private readonly string[] _sectionTitles =
        {
            "Ficha de identificación",
            "Antecedentes heredofamiliares",
            "Antecedentes no patológicos",
            "Antecedentes patológicos",
            "Gineco-obstétricos",
            "Padecimiento actual",
            "Exploración física",
            "Diagnóstico y plan"
        };

        private void NavegateToSection(int idx)
        {
            tabControl1.SelectedIndex = idx;
            lblSectionTitle.Text = _sectionTitles[idx];

            Button[] btns = { btnNav1, btnNav2, btnNav3, btnNav4,
                       btnNav5, btnNav6, btnNav7, btnNav8 };

            foreach (Button b in btns)
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.Transparent;
                b.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            btns[idx].BackColor = Color.FromArgb(220, 232, 248);
            btns[idx].ForeColor = Color.FromArgb(40, 75, 120);
            btns[idx].Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        // Expuesto para que inicio.cs pueda navegar desde el sidebar principal
        public void NavegateToSectionPublic(int idx) => NavegateToSection(idx);

        private void btnNav1_Click(object sender, EventArgs e) { NavegateToSection(0); }
        private void btnNav2_Click(object sender, EventArgs e) { NavegateToSection(1); }
        private void btnNav3_Click(object sender, EventArgs e) { NavegateToSection(2); }
        private void btnNav4_Click(object sender, EventArgs e) { NavegateToSection(3); }
        private void btnNav5_Click(object sender, EventArgs e) { NavegateToSection(4); }
        private void btnNav6_Click(object sender, EventArgs e) { NavegateToSection(5); }
        private void btnNav7_Click(object sender, EventArgs e) { NavegateToSection(6); }
        private void btnNav8_Click(object sender, EventArgs e) { NavegateToSection(7); }

        // ═════════════════════════════════════════════════════════════════
        // EVENTOS DE CAMPOS
        // ═════════════════════════════════════════════════════════════════
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fum = dateTimePicker1.Value;
            DateTime fpp = fum.AddDays(280);
            dateTimePicker2.Value = fpp;

            TimeSpan diff = DateTime.Now - fum;
            int semanas = (int)(diff.TotalDays / 7);
            if (semanas >= 0 && semanas <= 42)
                numericUpDown1.Value = semanas;
        }

        // Eventos vacíos requeridos por el designer
        private void estado_civil_TextChanged(object sender, EventArgs e) { }
        private void labeledad_Click(object sender, EventArgs e) { }
        private void asdasdasd_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }
        private void tabPage5_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label29_Click(object sender, EventArgs e) { }
        private void label30_Click(object sender, EventArgs e) { }
        private void label34_Click(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }
        private void lblRM_Click(object sender, EventArgs e) { }
        private void lblSlash1_Click(object sender, EventArgs e) { }
        private void lblSlash1_Click_1(object sender, EventArgs e) { }
        private void lblTiempo_Click(object sender, EventArgs e) { }
        private void lblCedMed_Click(object sender, EventArgs e) { }
        private void lblSectionTitle_Click(object sender, EventArgs e) { }
        private void pnlPatientDet_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }

        // Botones de navegación anterior (no usados actualmente pero requeridos)
        private void button1_Click(object sender, EventArgs e) { NavegateToSection(1); }
        private void button2_Click(object sender, EventArgs e) { NavegateToSection(2); }
        private void button3_Click(object sender, EventArgs e) { NavegateToSection(3); }
        private void button4_Click(object sender, EventArgs e) { NavegateToSection(1); }
        private void button5_Click(object sender, EventArgs e) { NavegateToSection(0); }
        private void button6_Click(object sender, EventArgs e) { NavegateToSection(2); }
        private void button7_Click(object sender, EventArgs e) { NavegateToSection(4); }

        // ═════════════════════════════════════════════════════════════════
        // GUARDAR
        // ═════════════════════════════════════════════════════════════════
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                MessageBox.Show("El nombre del paciente es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = capadatos.Database.Conexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int pacienteId = GuardarPaciente(conn, transaction);
                            GuardarAntecHeredofamiliares(conn, transaction, pacienteId);
                            GuardarAntecNoPatologicos(conn, transaction, pacienteId);
                            GuardarAntecPatologicos(conn, transaction, pacienteId);
                            GuardarAntecGineco(conn, transaction, pacienteId);
                            GuardarPadecimientoActual(conn, transaction, pacienteId);
                            GuardarExploracionFisica(conn, transaction, pacienteId);
                            GuardarDiagnosticoYPlan(conn, transaction, pacienteId);
                            GuardarExpediente(conn, transaction, pacienteId);

                            transaction.Commit();

                            // Actualizar sidebar interno
                            lblPatientName.Text = nombre.Text.Trim();
                            lblPatientMeta.Text = $"{edad1.Value} años · {comboBox1.Text}";
                            lblExpValue.Text = no_expediente.Text.Trim();
                            lblCamaValue.Text = cama.Text.Trim();

                            MessageBox.Show(
                                $"Expediente guardado correctamente.\nID Paciente: {pacienteId}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en base de datos:\n{ex.Message}",
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 1 – dbo.Pacientes
        // ═══════════════════════════════════════════════════════════════════
        private int GuardarPaciente(SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"
                INSERT INTO dbo.Pacientes
                    (nombre, edad, sexo, ocupacion, estadoCivil, nacionalidad,
                     escolaridad, religion, servicio, cama, noExpediente,
                     telefono, fechaRegistro, activo)
                VALUES
                    (@nombre, @edad, @sexo, @ocupacion, @estadoCivil, @nacionalidad,
                     @escolaridad, @religion, @servicio, @cama, @noExpediente,
                     @telefono, @fechaRegistro, @activo);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre.Text.Trim());
                cmd.Parameters.AddWithValue("@edad", (int)edad1.Value);
                cmd.Parameters.AddWithValue("@sexo", comboBox1.SelectedIndex > 0
                                                                 ? comboBox1.Text
                                                                 : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ocupacion", ocupacion.Text.Trim());
                cmd.Parameters.AddWithValue("@estadoCivil", estado_civil.Text.Trim());
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad.Text.Trim());
                cmd.Parameters.AddWithValue("@escolaridad", escolaridad.Text.Trim());
                cmd.Parameters.AddWithValue("@religion", religion.Text.Trim());
                cmd.Parameters.AddWithValue("@servicio", servicio.Text.Trim());
                cmd.Parameters.AddWithValue("@cama", cama.Text.Trim());
                cmd.Parameters.AddWithValue("@noExpediente", no_expediente.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", telefono.Text.Trim());
                cmd.Parameters.AddWithValue("@fechaRegistro", DateTime.Now);
                cmd.Parameters.AddWithValue("@activo", true);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 2 – dbo.AntecedentesHeredofamiliares
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarAntecHeredofamiliares(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.AntecedentesHeredofamiliares
                    (idPaciente, padresVivos, padresFallecidos, padresCausas,
                     hermanosVivos, hermanosFallecidos, hermanosCausas,
                     hijosVivos, hijosFallecidos, hijosCausas,
                     diabetesMellitus, hipertensionArterial,
                     tuberculosis, cancer, otrasEnfermedades)
                VALUES
                    (@idPaciente, @padresVivos, @padresFallecidos, @padresCausas,
                     @hermanosVivos, @hermanosFallecidos, @hermanosCausas,
                     @hijosVivos, @hijosFallecidos, @hijosCausas,
                     @diabetesMellitus, @hipertensionArterial,
                     @tuberculosis, @cancer, @otrasEnfermedades)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@padresVivos", vp.Text.Trim());
                cmd.Parameters.AddWithValue("@padresFallecidos", fpadres.Text.Trim());
                cmd.Parameters.AddWithValue("@padresCausas", causasp.Text.Trim());
                cmd.Parameters.AddWithValue("@hermanosVivos", vhemanos.Text.Trim());
                cmd.Parameters.AddWithValue("@hermanosFallecidos", fhermanos.Text.Trim());
                cmd.Parameters.AddWithValue("@hermanosCausas", causashermanos.Text.Trim());
                cmd.Parameters.AddWithValue("@hijosVivos", vhijos.Text.Trim());
                cmd.Parameters.AddWithValue("@hijosFallecidos", fhijos.Text.Trim());
                cmd.Parameters.AddWithValue("@hijosCausas", causashijos.Text.Trim());
                cmd.Parameters.AddWithValue("@diabetesMellitus", radioButton1.Checked);
                cmd.Parameters.AddWithValue("@hipertensionArterial", radioButton3.Checked);
                cmd.Parameters.AddWithValue("@tuberculosis", radioButton5.Checked);
                cmd.Parameters.AddWithValue("@cancer", radioButton7.Checked);
                cmd.Parameters.AddWithValue("@otrasEnfermedades", radioButton9.Checked);
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 3 – dbo.AntecedentesNoPatologicos
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarAntecNoPatologicos(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.AntecedentesNoPatologicos
                    (idPaciente, alcohol, tabaco, drogas, alimentacion,
                     dipsia, diuresis, catarsis, somnia, otrosFisiolog)
                VALUES
                    (@idPaciente, @alcohol, @tabaco, @drogas, @alimentacion,
                     @dipsia, @diuresis, @catarsis, @somnia, @otrosFisiolog)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@alcohol", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@tabaco", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@drogas", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@alimentacion", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@dipsia", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@diuresis", textBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@catarsis", textBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@somnia", textBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@otrosFisiolog", textBox9.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 4 – dbo.AntecedentesPatologicos
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarAntecPatologicos(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.AntecedentesPatologicos
                    (idPaciente, infancia, adulto,
                     diabetesMellitus, diabetesDetalle,
                     hipertensionArterial, hipertensionDetalle,
                     tuberculosis, tuberculosisDetalle,
                     cancer, cancerDetalle,
                     otrasEnfermedades, otrasDetalle,
                     quirurgicos, traumatologicos, alergicos, otros)
                VALUES
                    (@idPaciente, @infancia, @adulto,
                     @diabetesMellitus, @diabetesDetalle,
                     @hipertensionArterial, @hipertensionDetalle,
                     @tuberculosis, @tuberculosisDetalle,
                     @cancer, @cancerDetalle,
                     @otrasEnfermedades, @otrasDetalle,
                     @quirurgicos, @traumatologicos, @alergicos, @otros)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@infancia", textBox15.Text.Trim());
                cmd.Parameters.AddWithValue("@adulto", textBox16.Text.Trim());
                cmd.Parameters.AddWithValue("@diabetesMellitus", radioButton11.Checked);
                cmd.Parameters.AddWithValue("@diabetesDetalle", textBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@hipertensionArterial", radioButton13.Checked);
                cmd.Parameters.AddWithValue("@hipertensionDetalle", textBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@tuberculosis", radioButton15.Checked);
                cmd.Parameters.AddWithValue("@tuberculosisDetalle", textBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@cancer", radioButton17.Checked);
                cmd.Parameters.AddWithValue("@cancerDetalle", textBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@otrasEnfermedades", radioButton19.Checked);
                cmd.Parameters.AddWithValue("@otrasDetalle", textBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@quirurgicos", textBox17.Text.Trim());
                cmd.Parameters.AddWithValue("@traumatologicos", textBox18.Text.Trim());
                cmd.Parameters.AddWithValue("@alergicos", textBox19.Text.Trim());
                cmd.Parameters.AddWithValue("@otros", textBox20.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 5 – dbo.AntecedentesGineco
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarAntecGineco(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.AntecedentesGineco
                    (idPaciente, fum, fpp, edadGestacional, menarca,
                     ritmoMenstrual, irs, numParejas, flujoGenital,
                     gestas, partos, cesareas, abortos,
                     anticonceptivos, anticonceptivoTipo, anticonceptivoTiempo,
                     anticonceptivoUltToma, cirugiaGinecologica, otros)
                VALUES
                    (@idPaciente, @fum, @fpp, @edadGestacional, @menarca,
                     @ritmoMenstrual, @irs, @numParejas, @flujoGenital,
                     @gestas, @partos, @cesareas, @abortos,
                     @anticonceptivos, @anticonceptivoTipo, @anticonceptivoTiempo,
                     @anticonceptivoUltToma, @cirugiaGinecologica, @otros)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@fum", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@fpp", dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@edadGestacional", (int)numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@menarca", textBox21.Text.Trim());
                cmd.Parameters.AddWithValue("@ritmoMenstrual", $"{nudRM.Value}/{nudRitmo.Value}");
                cmd.Parameters.AddWithValue("@irs", (int)nudIRS.Value);
                cmd.Parameters.AddWithValue("@numParejas", (int)nudParejas.Value);
                cmd.Parameters.AddWithValue("@flujoGenital", txtFlujo.Text.Trim());
                cmd.Parameters.AddWithValue("@gestas", (int)nudGestas.Value);
                cmd.Parameters.AddWithValue("@partos", (int)nudPartos.Value);
                cmd.Parameters.AddWithValue("@cesareas", (int)nudCesareas.Value);
                cmd.Parameters.AddWithValue("@abortos", (int)nudAbortos.Value);
                cmd.Parameters.AddWithValue("@anticonceptivos", rbAnticoSi.Checked);
                cmd.Parameters.AddWithValue("@anticonceptivoTipo", txtTipo.Text.Trim());
                cmd.Parameters.AddWithValue("@anticonceptivoTiempo", txtTiempo.Text.Trim());
                cmd.Parameters.AddWithValue("@anticonceptivoUltToma", txtUltToma.Text.Trim());
                cmd.Parameters.AddWithValue("@cirugiaGinecologica", txtCirGin.Text.Trim());
                cmd.Parameters.AddWithValue("@otros", txtOtrosGin.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 6 – dbo.PadecimientoActual
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarPadecimientoActual(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.PadecimientoActual
                    (idPaciente, padecimiento, apRespiratorio, apDigestivo,
                     apCardiovascular, apRenalUrinario, apGenital, sistEndocrino,
                     sistHematopoyetico, pielAnexos, musculoEsqueletico,
                     sistNervioso, organosSentidos, sintomasGenerales)
                VALUES
                    (@idPaciente, @padecimiento, @apRespiratorio, @apDigestivo,
                     @apCardiovascular, @apRenalUrinario, @apGenital, @sistEndocrino,
                     @sistHematopoyetico, @pielAnexos, @musculoEsqueletico,
                     @sistNervioso, @organosSentidos, @sintomasGenerales)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@padecimiento", rtbPadActual.Text.Trim());
                cmd.Parameters.AddWithValue("@apRespiratorio", txtAp1.Text.Trim());
                cmd.Parameters.AddWithValue("@apDigestivo", txtAp2.Text.Trim());
                cmd.Parameters.AddWithValue("@apCardiovascular", txtAp3.Text.Trim());
                cmd.Parameters.AddWithValue("@apRenalUrinario", txtAp4.Text.Trim());
                cmd.Parameters.AddWithValue("@apGenital", txtAp5.Text.Trim());
                cmd.Parameters.AddWithValue("@sistEndocrino", txtAp6.Text.Trim());
                cmd.Parameters.AddWithValue("@sistHematopoyetico", txtAp7.Text.Trim());
                cmd.Parameters.AddWithValue("@pielAnexos", txtAp8.Text.Trim());
                cmd.Parameters.AddWithValue("@musculoEsqueletico", txtAp9.Text.Trim());
                cmd.Parameters.AddWithValue("@sistNervioso", txtAp10.Text.Trim());
                cmd.Parameters.AddWithValue("@organosSentidos", txtAp11.Text.Trim());
                cmd.Parameters.AddWithValue("@sintomasGenerales", txtAp12.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 7 – dbo.ExploracionFisica
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarExploracionFisica(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.ExploracionFisica
                    (idPaciente, impresionGeneral, fc, ta, fr, pulso, temperatura,
                     peso, talla, bmi, inspeccionGeneral, cabeza, cuello, torax,
                     abdomen, tactoVaginalRectal, extremidades, exploracionNeurologica)
                VALUES
                    (@idPaciente, @impresionGeneral, @fc, @ta, @fr, @pulso, @temperatura,
                     @peso, @talla, @bmi, @inspeccionGeneral, @cabeza, @cuello, @torax,
                     @abdomen, @tactoVaginalRectal, @extremidades, @exploracionNeurologica)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@impresionGeneral", txtImpGen.Text.Trim());
                cmd.Parameters.AddWithValue("@fc", txtSVFC.Text.Trim());
                cmd.Parameters.AddWithValue("@ta", txtSVTA.Text.Trim());
                cmd.Parameters.AddWithValue("@fr", txtSVFR.Text.Trim());
                cmd.Parameters.AddWithValue("@pulso", txtSVPulso.Text.Trim());
                cmd.Parameters.AddWithValue("@temperatura", txtSVTemperatura.Text.Trim());
                cmd.Parameters.AddWithValue("@peso", txtPeso.Text.Trim());
                cmd.Parameters.AddWithValue("@talla", txtTalla.Text.Trim());
                cmd.Parameters.AddWithValue("@bmi", txtBMI.Text.Trim());
                cmd.Parameters.AddWithValue("@inspeccionGeneral", rtbRegInspGen.Text.Trim());
                cmd.Parameters.AddWithValue("@cabeza", rtbRegCabeza.Text.Trim());
                cmd.Parameters.AddWithValue("@cuello", rtbRegCuello.Text.Trim());
                cmd.Parameters.AddWithValue("@torax", rtbRegTorax.Text.Trim());
                cmd.Parameters.AddWithValue("@abdomen", rtbRegAbdomen.Text.Trim());
                cmd.Parameters.AddWithValue("@tactoVaginalRectal", rtbRegTacto.Text.Trim());
                cmd.Parameters.AddWithValue("@extremidades", rtbRegExtremidades.Text.Trim());
                cmd.Parameters.AddWithValue("@exploracionNeurologica", rtbRegNeurologica.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA 8 – dbo.DiagnosticoYPlan
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarDiagnosticoYPlan(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.DiagnosticoYPlan
                    (idPaciente, examenesComplementarios, diagnosticoPresuntivo,
                     planTerapeutico, nombreMedico, cedulaMedico)
                VALUES
                    (@idPaciente, @examenesComplementarios, @diagnosticoPresuntivo,
                     @planTerapeutico, @nombreMedico, @cedulaMedico)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@examenesComplementarios", rtbExamComp.Text.Trim());
                cmd.Parameters.AddWithValue("@diagnosticoPresuntivo", rtbDiagPresun.Text.Trim());
                cmd.Parameters.AddWithValue("@planTerapeutico", rtbPlanTer.Text.Trim());
                cmd.Parameters.AddWithValue("@nombreMedico", txtNomMed.Text.Trim());
                cmd.Parameters.AddWithValue("@cedulaMedico", txtCedMed.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        // ═══════════════════════════════════════════════════════════════════
        // TABLA – dbo.Expedientes
        // ═══════════════════════════════════════════════════════════════════
        private void GuardarExpediente(SqlConnection conn, SqlTransaction tx, int idPaciente)
        {
            string sql = @"
                INSERT INTO dbo.Expedientes
                    (idPaciente, idUsuario, fechaApertura, fechaUltimaMod, estado)
                VALUES
                    (@idPaciente, @idUsuario, @fechaApertura, @fechaUltimaMod, @estado)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@fechaApertura", DateTime.Now);
                cmd.Parameters.AddWithValue("@fechaUltimaMod", DateTime.Now);
                cmd.Parameters.AddWithValue("@estado", "Activo");
                cmd.ExecuteNonQuery();
            }
        }
        private async Task CargarExpedienteAsync(int idPaciente)
        {
            try
            {
                await Task.Run(() =>
                {
                    using var conn = capadatos.Database.Conexion.ObtenerConexion();
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT nombre, edad, sexo, noExpediente, cama " +
                        "FROM dbo.Pacientes WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", idPaciente);

                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string nom = reader["nombre"].ToString();
                        string edad = reader["edad"].ToString();
                        string sexo = reader["sexo"].ToString();
                        string exp = reader["noExpediente"].ToString();
                        string cama = reader["cama"].ToString();

                        // Actualizar UI en hilo principal
                        this.Invoke(() =>
                        {
                            nombre.Text = nom;
                            lblPatientName.Text = nom;
                            lblPatientMeta.Text = $"{edad} años · {sexo}";
                            lblExpValue.Text = exp;
                            lblCamaValue.Text = cama;

                            if (nom.Length >= 2)
                                lblInitials.Text = (nom[0].ToString() +
                                    nom.Split(' ').LastOrDefault()?[0])
                                    .ToUpper();
                        });
                    }
                });
            }
            catch { /* silencioso al cargar */ }
        }

        private void lblPatientName_Click(object sender, EventArgs e)
        {

        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInitials_Click(object sender, EventArgs e)
        {

        }
    }
}