namespace SistemaHospitalario
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            PanelDerecho = new Panel();
            PanelLogin = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtUsuario = new TextBox();
            button1 = new Button();
            txtPassword = new TextBox();
            InicioSesion = new Label();
            PanelIzquierdo = new Panel();
            label2 = new Label();
            label1 = new Label();
            txtTitulo = new Label();
            Logo = new PictureBox();
            PanelDerecho.SuspendLayout();
            PanelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // PanelDerecho
            // 
            PanelDerecho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelDerecho.BackColor = Color.FromArgb(67, 105, 142);
            PanelDerecho.Controls.Add(PanelLogin);
            PanelDerecho.Location = new Point(0, 0);
            PanelDerecho.Name = "PanelDerecho";
            PanelDerecho.Size = new Size(1366, 870);
            PanelDerecho.TabIndex = 1;
            PanelDerecho.Paint += PanelLogin_Paint;
            // 
            // PanelLogin
            // 
            PanelLogin.Anchor = AnchorStyles.None;
            PanelLogin.BackColor = Color.White;
            PanelLogin.Controls.Add(pictureBox2);
            PanelLogin.Controls.Add(pictureBox1);
            PanelLogin.Controls.Add(txtUsuario);
            PanelLogin.Controls.Add(button1);
            PanelLogin.Controls.Add(txtPassword);
            PanelLogin.Controls.Add(InicioSesion);
            PanelLogin.Location = new Point(502, 184);
            PanelLogin.Name = "PanelLogin";
            PanelLogin.Size = new Size(371, 302);
            PanelLogin.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(29, 144);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 28);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 98);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 28);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(65, 98);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Nombre de Usuario";
            txtUsuario.Size = new Size(242, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(67, 105, 142);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(105, 209);
            button1.Name = "button1";
            button1.Size = new Size(159, 33);
            button1.TabIndex = 4;
            button1.Text = "ENTRAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = Color.FromArgb(79, 108, 138);
            txtPassword.Location = new Point(65, 144);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(244, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // InicioSesion
            // 
            InicioSesion.AutoSize = true;
            InicioSesion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InicioSesion.ForeColor = Color.FromArgb(67, 105, 142);
            InicioSesion.Location = new Point(83, 33);
            InicioSesion.Name = "InicioSesion";
            InicioSesion.Size = new Size(205, 31);
            InicioSesion.TabIndex = 0;
            InicioSesion.Text = "INICIO DE SESIÓN";
            // 
            // PanelIzquierdo
            // 
            PanelIzquierdo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PanelIzquierdo.BackColor = SystemColors.Window;
            PanelIzquierdo.Controls.Add(label2);
            PanelIzquierdo.Controls.Add(label1);
            PanelIzquierdo.Controls.Add(txtTitulo);
            PanelIzquierdo.Controls.Add(Logo);
            PanelIzquierdo.Location = new Point(0, 0);
            PanelIzquierdo.Name = "PanelIzquierdo";
            PanelIzquierdo.Size = new Size(480, 870);
            PanelIzquierdo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(233, 482);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 9;
            label2.Text = "v1.0 © 2026";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(160, 459);
            label1.Name = "label1";
            label1.Size = new Size(256, 23);
            label1.TabIndex = 8;
            label1.Text = "Sistema de Gestión Hospitalaria \n";
            label1.Click += label1_Click_1;
            // 
            // txtTitulo
            // 
            txtTitulo.AutoSize = true;
            txtTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitulo.ForeColor = Color.FromArgb(67, 105, 142);
            txtTitulo.Location = new Point(46, 393);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(607, 46);
            txtTitulo.TabIndex = 7;
            txtTitulo.Text = "CENTRAL QUIRÚRGICA ESPECIALIZADA";
            txtTitulo.Click += label1_Click;
            // 
            // Logo
            // 
            Logo.Image = (Image)resources.GetObject("Logo.Image");
            Logo.Location = new Point(160, 134);
            Logo.Name = "Logo";
            Logo.Size = new Size(246, 256);
            Logo.TabIndex = 1;
            Logo.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 870);
            Controls.Add(PanelIzquierdo);
            Controls.Add(PanelDerecho);
            MinimumSize = new Size(1000, 600);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Central Quirúrgica Especializada";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            PanelDerecho.ResumeLayout(false);
            PanelLogin.ResumeLayout(false);
            PanelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelIzquierdo.ResumeLayout(false);
            PanelIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelDerecho;
        private Panel PanelLogin;
        private TextBox txtUsuario;
        private Label InicioSesion;
        private TextBox txtPassword;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel PanelIzquierdo;
        private Label txtTitulo;
        private PictureBox Logo;
        private Label label1;
        private Label label2;
    }
}
