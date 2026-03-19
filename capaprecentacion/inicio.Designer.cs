namespace capaprecentacion
{
    partial class inicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inicio));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panelSidebar = new Panel();
            panelNavItems = new Panel();
            iconNavInicio = new FontAwesome.Sharp.IconPictureBox();
            lblNavInicio = new Label();
            iconNavRegistrar = new FontAwesome.Sharp.IconPictureBox();
            lblNavRegistrar = new Label();
            iconNavMantenedor = new FontAwesome.Sharp.IconPictureBox();
            lblNavMantenedor = new Label();
            iconNavVentas = new FontAwesome.Sharp.IconPictureBox();
            lblNavVentas = new Label();
            iconNavProveedores = new FontAwesome.Sharp.IconPictureBox();
            lblNavProveedores = new Label();
            iconNavReportes = new FontAwesome.Sharp.IconPictureBox();
            lblNavReportes = new Label();
            iconNavCalculadora = new FontAwesome.Sharp.IconPictureBox();
            lblNavCalculadora = new Label();
            panelLogo = new Panel();
            lblLogoIcon = new PictureBox();
            btnCerrarSesion = new Button();
            panelHeader = new Panel();
            txtBuscar = new TextBox();
            lblSistemaProtegido = new Label();
            lblNombreUsuario = new Label();
            panelMain = new Panel();
            btnNuevoExpediente = new Button();
            btnGenerarResumen = new Button();
            btnExportarDB = new Button();
            lblPacientesRecientes = new Label();
            panelLinea = new Panel();
            dgvPacientes = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            contenedor = new Panel();
            menuStrip1 = new MenuStrip();
            menucompras = new FontAwesome.Sharp.IconMenuItem();
            menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            menuventas = new FontAwesome.Sharp.IconMenuItem();
            menuprovedores = new FontAwesome.Sharp.IconMenuItem();
            menureportes = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem4 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem5 = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            panelSidebar.SuspendLayout();
            panelNavItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconNavInicio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavRegistrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavMantenedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavReportes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconNavCalculadora).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lblLogoIcon).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(67, 105, 142);
            panelSidebar.Controls.Add(panelNavItems);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Controls.Add(btnCerrarSesion);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 816);
            panelSidebar.TabIndex = 3;
            // 
            // panelNavItems
            // 
            panelNavItems.BackColor = Color.Transparent;
            panelNavItems.Controls.Add(iconNavInicio);
            panelNavItems.Controls.Add(lblNavInicio);
            panelNavItems.Controls.Add(iconNavRegistrar);
            panelNavItems.Controls.Add(lblNavRegistrar);
            panelNavItems.Controls.Add(iconNavMantenedor);
            panelNavItems.Controls.Add(lblNavMantenedor);
            panelNavItems.Controls.Add(iconNavVentas);
            panelNavItems.Controls.Add(lblNavVentas);
            panelNavItems.Controls.Add(iconNavProveedores);
            panelNavItems.Controls.Add(lblNavProveedores);
            panelNavItems.Controls.Add(iconNavReportes);
            panelNavItems.Controls.Add(lblNavReportes);
            panelNavItems.Controls.Add(iconNavCalculadora);
            panelNavItems.Controls.Add(lblNavCalculadora);
            panelNavItems.ForeColor = SystemColors.ControlDarkDark;
            panelNavItems.Location = new Point(0, 188);
            panelNavItems.Name = "panelNavItems";
            panelNavItems.Size = new Size(200, 500);
            panelNavItems.TabIndex = 0;
            // 
            // iconNavInicio
            // 
            iconNavInicio.BackColor = Color.Transparent;
            iconNavInicio.Cursor = Cursors.Hand;
            iconNavInicio.IconChar = FontAwesome.Sharp.IconChar.HomeLgAlt;
            iconNavInicio.IconColor = Color.White;
            iconNavInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavInicio.IconSize = 24;
            iconNavInicio.Location = new Point(22, 10);
            iconNavInicio.Name = "iconNavInicio";
            iconNavInicio.Size = new Size(24, 24);
            iconNavInicio.TabIndex = 0;
            iconNavInicio.TabStop = false;
            iconNavInicio.Click += lblNavInicio_Click;
            // 
            // lblNavInicio
            // 
            lblNavInicio.Cursor = Cursors.Hand;
            lblNavInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavInicio.ForeColor = Color.White;
            lblNavInicio.Location = new Point(54, 8);
            lblNavInicio.Name = "lblNavInicio";
            lblNavInicio.Size = new Size(140, 28);
            lblNavInicio.TabIndex = 1;
            lblNavInicio.Text = "INICIO";
            lblNavInicio.Click += lblNavInicio_Click;
            // 
            // iconNavRegistrar
            // 
            iconNavRegistrar.BackColor = Color.Transparent;
            iconNavRegistrar.Cursor = Cursors.Hand;
            iconNavRegistrar.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            iconNavRegistrar.IconColor = Color.White;
            iconNavRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavRegistrar.IconSize = 24;
            iconNavRegistrar.Location = new Point(22, 60);
            iconNavRegistrar.Name = "iconNavRegistrar";
            iconNavRegistrar.Size = new Size(24, 24);
            iconNavRegistrar.TabIndex = 2;
            iconNavRegistrar.TabStop = false;
            iconNavRegistrar.Click += menucompras_Click;
            // 
            // lblNavRegistrar
            // 
            lblNavRegistrar.Cursor = Cursors.Hand;
            lblNavRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavRegistrar.ForeColor = Color.White;
            lblNavRegistrar.Location = new Point(54, 58);
            lblNavRegistrar.Name = "lblNavRegistrar";
            lblNavRegistrar.Size = new Size(140, 28);
            lblNavRegistrar.TabIndex = 3;
            lblNavRegistrar.Text = "REGISTRAR";
            lblNavRegistrar.Click += menucompras_Click;
            // 
            // iconNavMantenedor
            // 
            iconNavMantenedor.BackColor = Color.Transparent;
            iconNavMantenedor.Cursor = Cursors.Hand;
            iconNavMantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            iconNavMantenedor.IconColor = Color.White;
            iconNavMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavMantenedor.IconSize = 24;
            iconNavMantenedor.Location = new Point(22, 110);
            iconNavMantenedor.Name = "iconNavMantenedor";
            iconNavMantenedor.Size = new Size(24, 24);
            iconNavMantenedor.TabIndex = 4;
            iconNavMantenedor.TabStop = false;
            iconNavMantenedor.Click += menumantenedor_Click;
            // 
            // lblNavMantenedor
            // 
            lblNavMantenedor.Cursor = Cursors.Hand;
            lblNavMantenedor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavMantenedor.ForeColor = Color.White;
            lblNavMantenedor.Location = new Point(54, 108);
            lblNavMantenedor.Name = "lblNavMantenedor";
            lblNavMantenedor.Size = new Size(140, 28);
            lblNavMantenedor.TabIndex = 5;
            lblNavMantenedor.Text = "MANTENEDOR";
            lblNavMantenedor.Click += menumantenedor_Click;
            // 
            // iconNavVentas
            // 
            iconNavVentas.BackColor = Color.Transparent;
            iconNavVentas.Cursor = Cursors.Hand;
            iconNavVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconNavVentas.IconColor = Color.White;
            iconNavVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavVentas.IconSize = 24;
            iconNavVentas.Location = new Point(22, 160);
            iconNavVentas.Name = "iconNavVentas";
            iconNavVentas.Size = new Size(24, 24);
            iconNavVentas.TabIndex = 6;
            iconNavVentas.TabStop = false;
            iconNavVentas.Click += menuventas_Click;
            // 
            // lblNavVentas
            // 
            lblNavVentas.Cursor = Cursors.Hand;
            lblNavVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavVentas.ForeColor = Color.White;
            lblNavVentas.Location = new Point(54, 158);
            lblNavVentas.Name = "lblNavVentas";
            lblNavVentas.Size = new Size(140, 28);
            lblNavVentas.TabIndex = 7;
            lblNavVentas.Text = "VENTAS";
            lblNavVentas.Click += menuventas_Click;
            // 
            // iconNavProveedores
            // 
            iconNavProveedores.BackColor = Color.Transparent;
            iconNavProveedores.Cursor = Cursors.Hand;
            iconNavProveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            iconNavProveedores.IconColor = Color.White;
            iconNavProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavProveedores.IconSize = 24;
            iconNavProveedores.Location = new Point(22, 210);
            iconNavProveedores.Name = "iconNavProveedores";
            iconNavProveedores.Size = new Size(24, 24);
            iconNavProveedores.TabIndex = 8;
            iconNavProveedores.TabStop = false;
            iconNavProveedores.Click += menuprovedores_Click;
            // 
            // lblNavProveedores
            // 
            lblNavProveedores.Cursor = Cursors.Hand;
            lblNavProveedores.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavProveedores.ForeColor = Color.White;
            lblNavProveedores.Location = new Point(54, 208);
            lblNavProveedores.Name = "lblNavProveedores";
            lblNavProveedores.Size = new Size(140, 28);
            lblNavProveedores.TabIndex = 9;
            lblNavProveedores.Text = "PROVEEDORES";
            lblNavProveedores.Click += menuprovedores_Click;
            // 
            // iconNavReportes
            // 
            iconNavReportes.BackColor = Color.Transparent;
            iconNavReportes.Cursor = Cursors.Hand;
            iconNavReportes.IconChar = FontAwesome.Sharp.IconChar.ChartGantt;
            iconNavReportes.IconColor = Color.White;
            iconNavReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavReportes.IconSize = 24;
            iconNavReportes.Location = new Point(22, 260);
            iconNavReportes.Name = "iconNavReportes";
            iconNavReportes.Size = new Size(24, 24);
            iconNavReportes.TabIndex = 10;
            iconNavReportes.TabStop = false;
            iconNavReportes.Click += menureportes_Click;
            // 
            // lblNavReportes
            // 
            lblNavReportes.Cursor = Cursors.Hand;
            lblNavReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavReportes.ForeColor = Color.White;
            lblNavReportes.Location = new Point(54, 258);
            lblNavReportes.Name = "lblNavReportes";
            lblNavReportes.Size = new Size(140, 28);
            lblNavReportes.TabIndex = 11;
            lblNavReportes.Text = "REPORTES";
            lblNavReportes.Click += menureportes_Click;
            // 
            // iconNavCalculadora
            // 
            iconNavCalculadora.BackColor = Color.Transparent;
            iconNavCalculadora.Cursor = Cursors.Hand;
            iconNavCalculadora.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            iconNavCalculadora.IconColor = Color.White;
            iconNavCalculadora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconNavCalculadora.IconSize = 24;
            iconNavCalculadora.Location = new Point(22, 310);
            iconNavCalculadora.Name = "iconNavCalculadora";
            iconNavCalculadora.Size = new Size(24, 24);
            iconNavCalculadora.TabIndex = 12;
            iconNavCalculadora.TabStop = false;
            iconNavCalculadora.Click += calculadora_clik;
            // 
            // lblNavCalculadora
            // 
            lblNavCalculadora.Cursor = Cursors.Hand;
            lblNavCalculadora.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNavCalculadora.ForeColor = Color.White;
            lblNavCalculadora.Location = new Point(54, 308);
            lblNavCalculadora.Name = "lblNavCalculadora";
            lblNavCalculadora.Size = new Size(140, 28);
            lblNavCalculadora.TabIndex = 13;
            lblNavCalculadora.Text = "CALCULADORA";
            lblNavCalculadora.Click += calculadora_clik;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(67, 105, 142);
            panelLogo.Controls.Add(lblLogoIcon);
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 133);
            panelLogo.TabIndex = 1;
            // 
            // lblLogoIcon
            // 
            lblLogoIcon.BackColor = Color.Transparent;
            lblLogoIcon.Image = (Image)resources.GetObject("lblLogoIcon.Image");
            lblLogoIcon.InitialImage = (Image)resources.GetObject("lblLogoIcon.InitialImage");
            lblLogoIcon.Location = new Point(6, 3);
            lblLogoIcon.Name = "lblLogoIcon";
            lblLogoIcon.Size = new Size(188, 130);
            lblLogoIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lblLogoIcon.TabIndex = 0;
            lblLogoIcon.TabStop = false;
            lblLogoIcon.Click += lblLogoIcon_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(180, 50, 50);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(12, 768);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(180, 36);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(txtBuscar);
            panelHeader.Controls.Add(lblSistemaProtegido);
            panelHeader.Controls.Add(lblNombreUsuario);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(200, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1256, 65);
            panelHeader.TabIndex = 2;
            panelHeader.Paint += panelHeader_Paint;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(245, 247, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.ForeColor = Color.FromArgb(100, 115, 140);
            txtBuscar.Location = new Point(20, 14);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "🔍  Buscar...";
            txtBuscar.Size = new Size(650, 32);
            txtBuscar.TabIndex = 0;
            // 
            // lblSistemaProtegido
            // 
            lblSistemaProtegido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSistemaProtegido.AutoSize = true;
            lblSistemaProtegido.Font = new Font("Segoe UI", 8F);
            lblSistemaProtegido.ForeColor = Color.FromArgb(100, 120, 160);
            lblSistemaProtegido.Location = new Point(1956, 12);
            lblSistemaProtegido.Name = "lblSistemaProtegido";
            lblSistemaProtegido.Size = new Size(169, 19);
            lblSistemaProtegido.TabIndex = 1;
            lblSistemaProtegido.Text = "🔒  SISTEMA PROTEGIDO";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(33, 46, 68);
            lblNombreUsuario.Location = new Point(1956, 32);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(127, 23);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Administrador";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(240, 244, 250);
            panelMain.Controls.Add(btnNuevoExpediente);
            panelMain.Controls.Add(btnGenerarResumen);
            panelMain.Controls.Add(btnExportarDB);
            panelMain.Controls.Add(lblPacientesRecientes);
            panelMain.Controls.Add(panelLinea);
            panelMain.Controls.Add(dgvPacientes);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(200, 65);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(30, 25, 30, 20);
            panelMain.Size = new Size(1256, 751);
            panelMain.TabIndex = 0;
            // 
            // btnNuevoExpediente
            // 
            btnNuevoExpediente.BackColor = Color.FromArgb(67, 105, 142);
            btnNuevoExpediente.Cursor = Cursors.Hand;
            btnNuevoExpediente.FlatAppearance.BorderSize = 0;
            btnNuevoExpediente.FlatStyle = FlatStyle.Flat;
            btnNuevoExpediente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoExpediente.ForeColor = Color.White;
            btnNuevoExpediente.Location = new Point(30, 25);
            btnNuevoExpediente.Name = "btnNuevoExpediente";
            btnNuevoExpediente.Size = new Size(200, 60);
            btnNuevoExpediente.TabIndex = 0;
            btnNuevoExpediente.Text = "📋  NUEVO\nEXPEDIENTE";
            btnNuevoExpediente.UseVisualStyleBackColor = false;
            // 
            // btnGenerarResumen
            // 
            btnGenerarResumen.BackColor = Color.FromArgb(67, 105, 142);
            btnGenerarResumen.Cursor = Cursors.Hand;
            btnGenerarResumen.FlatAppearance.BorderSize = 0;
            btnGenerarResumen.FlatStyle = FlatStyle.Flat;
            btnGenerarResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerarResumen.ForeColor = Color.White;
            btnGenerarResumen.Location = new Point(250, 25);
            btnGenerarResumen.Name = "btnGenerarResumen";
            btnGenerarResumen.Size = new Size(200, 60);
            btnGenerarResumen.TabIndex = 1;
            btnGenerarResumen.Text = "📄  GENERAR\nRESUMEN CLÍNICO";
            btnGenerarResumen.UseVisualStyleBackColor = false;
            // 
            // btnExportarDB
            // 
            btnExportarDB.BackColor = Color.FromArgb(67, 105, 142);
            btnExportarDB.Cursor = Cursors.Hand;
            btnExportarDB.FlatAppearance.BorderSize = 0;
            btnExportarDB.FlatStyle = FlatStyle.Flat;
            btnExportarDB.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarDB.ForeColor = Color.White;
            btnExportarDB.Location = new Point(470, 25);
            btnExportarDB.Name = "btnExportarDB";
            btnExportarDB.Size = new Size(200, 60);
            btnExportarDB.TabIndex = 2;
            btnExportarDB.Text = "💾  EXPORTAR\nBASE DE DATOS";
            btnExportarDB.UseVisualStyleBackColor = false;
            // 
            // lblPacientesRecientes
            // 
            lblPacientesRecientes.AutoSize = true;
            lblPacientesRecientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPacientesRecientes.ForeColor = Color.FromArgb(33, 46, 68);
            lblPacientesRecientes.Location = new Point(30, 105);
            lblPacientesRecientes.Name = "lblPacientesRecientes";
            lblPacientesRecientes.Size = new Size(232, 28);
            lblPacientesRecientes.TabIndex = 3;
            lblPacientesRecientes.Text = "REGISTROS RECIENTES:";
            // 
            // panelLinea
            // 
            panelLinea.BackColor = Color.FromArgb(33, 46, 68);
            panelLinea.Location = new Point(30, 132);
            panelLinea.Name = "panelLinea";
            panelLinea.Size = new Size(220, 3);
            panelLinea.TabIndex = 4;
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPacientes.BackgroundColor = Color.White;
            dgvPacientes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(240, 244, 250);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(33, 46, 68);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(210, 225, 245);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(33, 46, 68);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvPacientes.DefaultCellStyle = dataGridViewCellStyle6;
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.Font = new Font("Segoe UI", 10F);
            dgvPacientes.GridColor = Color.FromArgb(230, 235, 245);
            dgvPacientes.Location = new Point(30, 145);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.RowHeadersWidth = 51;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.Size = new Size(1956, 300);
            dgvPacientes.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // contenedor
            // 
            contenedor.BackColor = Color.FromArgb(240, 244, 250);
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(200, 65);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1256, 751);
            contenedor.TabIndex = 1;
            contenedor.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menucompras, menumantenedor, menuventas, menuprovedores, menureportes, iconMenuItem5 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1456, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Visible = false;
            // 
            // menucompras
            // 
            menucompras.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            menucompras.IconColor = Color.Black;
            menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menucompras.Name = "menucompras";
            menucompras.Size = new Size(150, 24);
            menucompras.Text = "registrar usuario";
            menucompras.Click += menucompras_Click;
            // 
            // menumantenedor
            // 
            menumantenedor.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem2 });
            menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            menumantenedor.IconColor = Color.Black;
            menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menumantenedor.Name = "menumantenedor";
            menumantenedor.Size = new Size(124, 24);
            menumantenedor.Text = "mantenedor";
            menumantenedor.Click += menumantenedor_Click;
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(159, 26);
            iconMenuItem1.Text = "productos";
            iconMenuItem1.Click += iconMenuItem1_Click_1;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(159, 26);
            iconMenuItem2.Text = "categoria";
            iconMenuItem2.Click += iconMenuItem2_Click;
            // 
            // menuventas
            // 
            menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            menuventas.IconColor = Color.Black;
            menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuventas.Name = "menuventas";
            menuventas.Size = new Size(85, 24);
            menuventas.Text = "ventas";
            menuventas.Click += menuventas_Click;
            // 
            // menuprovedores
            // 
            menuprovedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            menuprovedores.IconColor = Color.Black;
            menuprovedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuprovedores.Name = "menuprovedores";
            menuprovedores.Size = new Size(118, 24);
            menuprovedores.Text = "provedores";
            menuprovedores.Click += menuprovedores_Click;
            // 
            // menureportes
            // 
            menureportes.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem4, iconMenuItem3 });
            menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartGantt;
            menureportes.IconColor = Color.Black;
            menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menureportes.Name = "menureportes";
            menureportes.Size = new Size(98, 24);
            menureportes.Text = "reportes";
            menureportes.Click += menureportes_Click;
            // 
            // iconMenuItem4
            // 
            iconMenuItem4.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem4.IconColor = Color.Black;
            iconMenuItem4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem4.Name = "iconMenuItem4";
            iconMenuItem4.Size = new Size(224, 26);
            iconMenuItem4.Text = "ventas";
            iconMenuItem4.Click += iconMenuItem4_Click;
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(149, 26);
            iconMenuItem3.Text = "compras";
            iconMenuItem3.Click += iconMenuItem3_Click;
            // 
            // iconMenuItem5
            // 
            iconMenuItem5.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem5.IconColor = Color.Black;
            iconMenuItem5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem5.Name = "iconMenuItem5";
            iconMenuItem5.Size = new Size(120, 24);
            iconMenuItem5.Text = "calculadora";
            iconMenuItem5.Click += calculadora_clik;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 5;
            label1.Text = "ferrebyt";
            label1.Visible = false;
            // 
            // inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 816);
            Controls.Add(panelMain);
            Controls.Add(contenedor);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(1000, 650);
            Name = "inicio";
            Text = "INICIO";
            WindowState = FormWindowState.Maximized;
            Load += inicio_Load;
            panelSidebar.ResumeLayout(false);
            panelNavItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconNavInicio).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavRegistrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavMantenedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavReportes).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconNavCalculadora).EndInit();
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lblLogoIcon).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(220, 228, 240), 1);
            e.Graphics.DrawLine(pen, 0, panelHeader.Height - 1, panelHeader.Width, panelHeader.Height - 1);
        }

        private void inicio_(object sender, EventArgs e)
        {
            AjustarHeader();
        }

        #endregion

        // ── Controles ─────────────────────────────────────────────────
        private Panel panelSidebar, panelLogo, panelNavItems, panelHeader;
        private Panel panelMain, panelLinea, contenedor;

        private PictureBox lblLogoIcon;
        private FontAwesome.Sharp.IconPictureBox iconNavInicio, iconNavRegistrar, iconNavMantenedor;
        private FontAwesome.Sharp.IconPictureBox iconNavVentas, iconNavProveedores, iconNavReportes, iconNavCalculadora;

        private Label lblNavInicio, lblNavRegistrar, lblNavMantenedor;
        private Label lblNavVentas, lblNavProveedores, lblNavReportes, lblNavCalculadora;
        private Label lblSistemaProtegido, lblNombreUsuario, lblPacientesRecientes;

        private TextBox txtBuscar;
        private Button btnCerrarSesion, btnNuevoExpediente, btnGenerarResumen, btnExportarDB;
        private DataGridView dgvPacientes;

        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menumantenedor, menuventas, menucompras;
        private FontAwesome.Sharp.IconMenuItem menuprovedores, menureportes;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1, iconMenuItem2, iconMenuItem3, iconMenuItem4, iconMenuItem5;
        private Label label1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}