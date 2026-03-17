namespace capaprecentacion
{
    partial class ventas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label10 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtfecha = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            txtidproducto = new TextBox();
            btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            txtcodproducto = new TextBox();
            label9 = new Label();
            txtproducto = new TextBox();
            txtcantidad = new NumericUpDown();
            label5 = new Label();
            txtstock = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtprecio = new TextBox();
            label6 = new Label();
            btnagregarproducto = new FontAwesome.Sharp.IconButton();
            dgvdata = new DataGridView();
            label16 = new Label();
            label13 = new Label();
            label1 = new Label();
            txtcambio = new TextBox();
            txtpagocon = new TextBox();
            txttotalpagar = new TextBox();
            btncrearventa = new FontAwesome.Sharp.IconButton();
            IdProducto = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            btneliminar = new DataGridViewButtonColumn();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.BackColor = Color.White;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(-3, 3);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Padding = new Padding(10, 0, 0, 0);
            label10.Size = new Size(1322, 821);
            label10.TabIndex = 96;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 4);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(222, 36);
            label2.TabIndex = 196;
            label2.Text = "Registrar Venta";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(txtfecha);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(6, 46);
            groupBox1.Margin = new Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 6, 5, 6);
            groupBox1.Size = new Size(244, 144);
            groupBox1.TabIndex = 197;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información Venta";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtfecha
            // 
            txtfecha.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtfecha.Location = new Point(15, 75);
            txtfecha.Margin = new Padding(5, 6, 5, 6);
            txtfecha.Name = "txtfecha";
            txtfecha.ReadOnly = true;
            txtfecha.Size = new Size(196, 28);
            txtfecha.TabIndex = 90;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 40);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 22);
            label3.TabIndex = 89;
            label3.Text = "Fecha:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(txtidproducto);
            groupBox3.Controls.Add(btnbuscarproducto);
            groupBox3.Controls.Add(txtcodproducto);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtproducto);
            groupBox3.Controls.Add(txtcantidad);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtstock);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(txtprecio);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(14, 202);
            groupBox3.Margin = new Padding(5, 6, 5, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 6, 5, 6);
            groupBox3.Size = new Size(1095, 152);
            groupBox3.TabIndex = 199;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacion de Producto";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(185, 37);
            txtidproducto.Margin = new Padding(5, 6, 5, 6);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.Size = new Size(51, 31);
            txtidproducto.TabIndex = 0;
            txtidproducto.Visible = false;
            // 
            // btnbuscarproducto
            // 
            btnbuscarproducto.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscarproducto.IconColor = Color.Black;
            btnbuscarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscarproducto.IconSize = 18;
            btnbuscarproducto.Location = new Point(248, 77);
            btnbuscarproducto.Margin = new Padding(5, 6, 5, 6);
            btnbuscarproducto.Name = "btnbuscarproducto";
            btnbuscarproducto.Padding = new Padding(0, 10, 0, 0);
            btnbuscarproducto.Size = new Size(62, 44);
            btnbuscarproducto.TabIndex = 2;
            btnbuscarproducto.UseVisualStyleBackColor = true;
            btnbuscarproducto.Click += btnbuscarproducto_Click;
            // 
            // txtcodproducto
            // 
            txtcodproducto.Location = new Point(15, 81);
            txtcodproducto.Margin = new Padding(5, 6, 5, 6);
            txtcodproducto.Name = "txtcodproducto";
            txtcodproducto.Size = new Size(219, 31);
            txtcodproducto.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 50);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(131, 25);
            label9.TabIndex = 96;
            label9.Text = "Cod. Producto:";
            // 
            // txtproducto
            // 
            txtproducto.Location = new Point(322, 81);
            txtproducto.Margin = new Padding(5, 6, 5, 6);
            txtproducto.Name = "txtproducto";
            txtproducto.ReadOnly = true;
            txtproducto.Size = new Size(322, 31);
            txtproducto.TabIndex = 3;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(950, 81);
            txtcantidad.Margin = new Padding(5, 6, 5, 6);
            txtcantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtcantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(130, 31);
            txtcantidad.TabIndex = 6;
            txtcantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(945, 50);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 98;
            label5.Text = "Cantidad:";
            // 
            // txtstock
            // 
            txtstock.Location = new Point(807, 81);
            txtstock.Margin = new Padding(5, 6, 5, 6);
            txtstock.Name = "txtstock";
            txtstock.ReadOnly = true;
            txtstock.Size = new Size(127, 31);
            txtstock.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(317, 50);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(89, 25);
            label8.TabIndex = 97;
            label8.Text = "Producto:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(802, 50);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 100;
            label7.Text = "Stock:";
            // 
            // txtprecio
            // 
            txtprecio.Location = new Point(662, 81);
            txtprecio.Margin = new Padding(5, 6, 5, 6);
            txtprecio.Name = "txtprecio";
            txtprecio.Size = new Size(127, 31);
            txtprecio.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(657, 50);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(64, 25);
            label6.TabIndex = 99;
            label6.Text = "Precio:";
            // 
            // btnagregarproducto
            // 
            btnagregarproducto.Cursor = Cursors.Hand;
            btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnagregarproducto.IconColor = Color.ForestGreen;
            btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnagregarproducto.IconSize = 30;
            btnagregarproducto.ImageAlign = ContentAlignment.BottomCenter;
            btnagregarproducto.Location = new Point(1124, 221);
            btnagregarproducto.Margin = new Padding(5, 6, 5, 6);
            btnagregarproducto.Name = "btnagregarproducto";
            btnagregarproducto.Size = new Size(158, 133);
            btnagregarproducto.TabIndex = 200;
            btnagregarproducto.Text = "Agregar";
            btnagregarproducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnagregarproducto.UseVisualStyleBackColor = true;
            btnagregarproducto.Click += btnagregarproducto_Click;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dgvdata.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { IdProducto, Producto, Precio, Cantidad, SubTotal, btneliminar });
            dgvdata.Location = new Point(14, 366);
            dgvdata.Margin = new Padding(5, 6, 5, 6);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 62;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.RowTemplate.Height = 28;
            dgvdata.Size = new Size(1095, 431);
            dgvdata.TabIndex = 201;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            dgvdata.CellPainting += dgvdata_CellPainting;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.White;
            label16.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(1126, 578);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(76, 22);
            label16.TabIndex = 202;
            label16.Text = "Cambio:";
            label16.Click += label16_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(1126, 489);
            label13.Margin = new Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new Size(91, 22);
            label13.TabIndex = 203;
            label13.Text = "Paga con:";
            label13.Click += label13_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1126, 402);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 22);
            label1.TabIndex = 204;
            label1.Text = "Total a Pagar:";
            // 
            // txtcambio
            // 
            txtcambio.BackColor = Color.WhiteSmoke;
            txtcambio.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcambio.Location = new Point(1126, 620);
            txtcambio.Margin = new Padding(5, 6, 5, 6);
            txtcambio.Name = "txtcambio";
            txtcambio.ReadOnly = true;
            txtcambio.Size = new Size(156, 28);
            txtcambio.TabIndex = 207;
            // 
            // txtpagocon
            // 
            txtpagocon.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpagocon.Location = new Point(1126, 528);
            txtpagocon.Margin = new Padding(5, 6, 5, 6);
            txtpagocon.Name = "txtpagocon";
            txtpagocon.Size = new Size(156, 28);
            txtpagocon.TabIndex = 206;
            txtpagocon.TextChanged += txtpagocon_TextChanged;
            txtpagocon.KeyPress += txtpagocon_KeyPress;
            txtpagocon.PreviewKeyDown += txtpagocon_PreviewKeyDown;
            // 
            // txttotalpagar
            // 
            txttotalpagar.BackColor = Color.WhiteSmoke;
            txttotalpagar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttotalpagar.Location = new Point(1126, 430);
            txttotalpagar.Margin = new Padding(5, 6, 5, 6);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.ReadOnly = true;
            txttotalpagar.Size = new Size(156, 28);
            txttotalpagar.TabIndex = 205;
            txttotalpagar.Text = "0";
            txttotalpagar.TextChanged += txttotalpagar_TextChanged;
            // 
            // btncrearventa
            // 
            btncrearventa.Cursor = Cursors.Hand;
            btncrearventa.IconChar = FontAwesome.Sharp.IconChar.Tag;
            btncrearventa.IconColor = Color.DodgerBlue;
            btncrearventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncrearventa.IconSize = 30;
            btncrearventa.ImageAlign = ContentAlignment.MiddleRight;
            btncrearventa.Location = new Point(1126, 689);
            btncrearventa.Margin = new Padding(5, 6, 5, 6);
            btncrearventa.Name = "btncrearventa";
            btncrearventa.Padding = new Padding(0, 4, 0, 0);
            btncrearventa.Size = new Size(163, 69);
            btncrearventa.TabIndex = 208;
            btncrearventa.Text = "Crear Venta";
            btncrearventa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btncrearventa.UseVisualStyleBackColor = true;
            btncrearventa.Click += btncrearventa_Click;
            // 
            // IdProducto
            // 
            IdProducto.HeaderText = "IdProducto";
            IdProducto.MinimumWidth = 8;
            IdProducto.Name = "IdProducto";
            IdProducto.ReadOnly = true;
            IdProducto.Visible = false;
            IdProducto.Width = 150;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 8;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 200;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 8;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 130;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 8;
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 150;
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "Sub Total";
            SubTotal.MinimumWidth = 8;
            SubTotal.Name = "SubTotal";
            SubTotal.ReadOnly = true;
            SubTotal.Resizable = DataGridViewTriState.True;
            SubTotal.Width = 150;
            // 
            // btneliminar
            // 
            btneliminar.HeaderText = "";
            btneliminar.MinimumWidth = 8;
            btneliminar.Name = "btneliminar";
            btneliminar.ReadOnly = true;
            btneliminar.Resizable = DataGridViewTriState.True;
            btneliminar.SortMode = DataGridViewColumnSortMode.Automatic;
            btneliminar.Width = 35;
            // 
            // ventas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 828);
            Controls.Add(btncrearventa);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(label1);
            Controls.Add(txtcambio);
            Controls.Add(txtpagocon);
            Controls.Add(txttotalpagar);
            Controls.Add(dgvdata);
            Controls.Add(btnagregarproducto);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label10);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ventas";
            Text = "frmVentas";
            FormClosing += ventas_FormClosing;
            Load += ventas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtidproducto;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
        private System.Windows.Forms.TextBox txtcodproducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.TextBox txtpagocon;
        private System.Windows.Forms.TextBox txttotalpagar;
        private FontAwesome.Sharp.IconButton btncrearventa;
        private DataGridViewTextBoxColumn IdProducto;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
        private DataGridViewButtonColumn btneliminar;
    }
}