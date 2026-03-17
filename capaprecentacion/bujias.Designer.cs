namespace capaprecentacion
{
    partial class bujias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            cbMarca = new ComboBox();
            txtCodigoBujia = new TextBox();
            dgvEquivalencias = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquivalencias).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbMarca);
            panel1.Controls.Add(txtCodigoBujia);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(423, 705);
            panel1.TabIndex = 0;
            // 
            // cbMarca
            // 
            cbMarca.FormattingEnabled = true;
            cbMarca.Location = new Point(12, 181);
            cbMarca.Name = "cbMarca";
            cbMarca.Size = new Size(182, 33);
            cbMarca.TabIndex = 1;
            // 
            // txtCodigoBujia
            // 
            txtCodigoBujia.Location = new Point(230, 181);
            txtCodigoBujia.Name = "txtCodigoBujia";
            txtCodigoBujia.Size = new Size(150, 31);
            txtCodigoBujia.TabIndex = 0;
            txtCodigoBujia.TextChanged += txtCodigoBujia_TextChanged;
            // 
            // dgvEquivalencias
            // 
            dgvEquivalencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquivalencias.Location = new Point(429, 1);
            dgvEquivalencias.Name = "dgvEquivalencias";
            dgvEquivalencias.RowHeadersWidth = 62;
            dgvEquivalencias.Size = new Size(865, 705);
            dgvEquivalencias.TabIndex = 1;
            dgvEquivalencias.CellContentClick += dataGridView1_CellContentClick;
            // 
            // bujias
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 711);
            Controls.Add(dgvEquivalencias);
            Controls.Add(panel1);
            Name = "bujias";
            Text = "bujias";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquivalencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cbMarca;
        private TextBox txtCodigoBujia;
        private DataGridView dgvEquivalencias;
    }
}