namespace capaprecentacion
{
    partial class clientes
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
            panel2 = new Panel();
            button1 = new Button();
            dtpFecha = new DateTimePicker();
            txtNombreDeudor = new TextBox();
            label1 = new Label();
            flowLayoutPanelPagares = new FlowLayoutPanel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(txtNombreDeudor);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(429, 774);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(41, 457);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 5;
            button1.Text = "agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(243, 32);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(133, 31);
            dtpFecha.TabIndex = 4;
            // 
            // txtNombreDeudor
            // 
            txtNombreDeudor.Location = new Point(41, 225);
            txtNombreDeudor.Name = "txtNombreDeudor";
            txtNombreDeudor.Size = new Size(150, 31);
            txtNombreDeudor.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 178);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "nombre";
            // 
            // flowLayoutPanelPagares
            // 
            flowLayoutPanelPagares.AutoScroll = true;
            flowLayoutPanelPagares.Location = new Point(435, 12);
            flowLayoutPanelPagares.Name = "flowLayoutPanelPagares";
            flowLayoutPanelPagares.Size = new Size(1027, 763);
            flowLayoutPanelPagares.TabIndex = 2;
            flowLayoutPanelPagares.Paint += flowLayoutPanelPagares_Paint;
            // 
            // clientes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 798);
            Controls.Add(flowLayoutPanelPagares);
            Controls.Add(panel2);
            Name = "clientes";
            Text = "clientes";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DateTimePicker dtpFecha;
        private TextBox txtNombreDeudor;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelPagares;
        private Button button1;
    }
}