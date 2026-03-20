using System;
using System.Windows.Forms;
using conexion;

namespace capaprecentacion
{
    public partial class formnuevo : Form
    {
        private DatabaseConnection conectar;

        public formnuevo()
        {
            InitializeComponent();
            conectar = new DatabaseConnection();
        }

        // ═════════════════════════════════════════════════════════════════
        // NAVEGACIÓN LATERAL
        // ═════════════════════════════════════════════════════════════════
        private string[] _sectionTitles = {
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

            System.Drawing.Color cPrimary = System.Drawing.Color.FromArgb(67, 105, 142);
            System.Drawing.Color cPrimaryLight = System.Drawing.Color.FromArgb(230, 241, 251);
            System.Drawing.Color cMuted = System.Drawing.Color.FromArgb(110, 130, 150);

            Button[] btns = { btnNav1, btnNav2, btnNav3, btnNav4, btnNav5, btnNav6, btnNav7, btnNav8 };
            foreach (Button b in btns)
            {
                b.BackColor = System.Drawing.Color.Transparent;
                b.ForeColor = cMuted;
            }
            btns[idx].BackColor = cPrimaryLight;
            btns[idx].ForeColor = cPrimary;
        }

        private void btnNav1_Click(object sender, EventArgs e) { NavegateToSection(0); }
        private void btnNav2_Click(object sender, EventArgs e) { NavegateToSection(1); }
        private void btnNav3_Click(object sender, EventArgs e) { NavegateToSection(2); }
        private void btnNav4_Click(object sender, EventArgs e) { NavegateToSection(3); }
        private void btnNav5_Click(object sender, EventArgs e) { NavegateToSection(4); }
        private void btnNav6_Click(object sender, EventArgs e) { NavegateToSection(5); }
        private void btnNav7_Click(object sender, EventArgs e) { NavegateToSection(6); }
        private void btnNav8_Click(object sender, EventArgs e) { NavegateToSection(7); }

        // ═════════════════════════════════════════════════════════════════
        // BOTONES SIGUIENTE / ANTERIOR (sincronizan con el sidebar)
        // ═════════════════════════════════════════════════════════════════

        // Tab 1 – Ficha: solo "Siguiente"
        private void button1_Click(object sender, EventArgs e)
        {
            NavegateToSection(1);
        }

        // Tab 2 – Heredofamiliares
        private void button2_Click(object sender, EventArgs e)
        {
            NavegateToSection(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NavegateToSection(0);
        }

        // Tab 3 – No Patológicos
        private void button3_Click(object sender, EventArgs e)
        {
            NavegateToSection(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NavegateToSection(1);
        }

        // Tab 4 – Patológicos
        private void button7_Click(object sender, EventArgs e)
        {
            NavegateToSection(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavegateToSection(2);
        }

        // ═════════════════════════════════════════════════════════════════
        // EVENTOS DE CAMPOS
        // ═════════════════════════════════════════════════════════════════

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Calcula FPP automáticamente sumando 280 días a la FUM
            DateTime fum = dateTimePicker1.Value;
            DateTime fpp = fum.AddDays(280);
            dateTimePicker2.Value = fpp;

            // Calcula edad gestacional en semanas
            TimeSpan diff = DateTime.Now - fum;
            int semanas = (int)(diff.TotalDays / 7);
            if (semanas >= 0 && semanas <= 42)
                numericUpDown1.Value = semanas;
        }

        private void estado_civil_TextChanged(object sender, EventArgs e) { }
        private void labeledad_Click(object sender, EventArgs e) { }
        private void asdasdasd_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }

        private void pnlPatientDet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTiempo_Click(object sender, EventArgs e)
        {

        }

        private void lblSlash1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void lblRM_Click(object sender, EventArgs e)
        {

        }

        private void lblSlash1_Click_1(object sender, EventArgs e)
        {

        }
    }
}