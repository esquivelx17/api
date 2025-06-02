namespace InvSis.Views
{
    partial class frmApiInicio
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            btnReiniciarF = new Button();
            lblFilUbi = new Label();
            cmbUbi = new ComboBox();
            lblFilCat = new Label();
            lblFilStatus = new Label();
            cmbCat = new ComboBox();
            btnApF = new Button();
            cmbEstatus = new ComboBox();
            dgvProductos = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colCosto = new DataGridViewTextBoxColumn();
            colCostoLetra = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colUbicacion = new DataGridViewTextBoxColumn();
            colImpuesto = new DataGridViewTextBoxColumn();
            colClave = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            gbProducto = new GroupBox();
            txtClave = new TextBox();
            lblFilClave = new Label();
            btResVentas = new Button();
            lblSeleccionProducto = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            gbProducto.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1169, 42);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "API";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReiniciarF
            // 
            btnReiniciarF.AutoSize = true;
            btnReiniciarF.BackColor = Color.MediumPurple;
            btnReiniciarF.FlatStyle = FlatStyle.Flat;
            btnReiniciarF.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnReiniciarF.ForeColor = Color.White;
            btnReiniciarF.Location = new Point(988, 167);
            btnReiniciarF.Name = "btnReiniciarF";
            btnReiniciarF.Size = new Size(152, 37);
            btnReiniciarF.TabIndex = 43;
            btnReiniciarF.Text = "Reiniciar Filtro";
            btnReiniciarF.UseVisualStyleBackColor = false;
            btnReiniciarF.Click += btnReiniciarF_Click;
            // 
            // lblFilUbi
            // 
            lblFilUbi.AutoSize = true;
            lblFilUbi.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilUbi.ForeColor = Color.MediumPurple;
            lblFilUbi.Location = new Point(917, 76);
            lblFilUbi.Name = "lblFilUbi";
            lblFilUbi.Size = new Size(222, 30);
            lblFilUbi.TabIndex = 42;
            lblFilUbi.Text = "Filtrar por ubicación";
            // 
            // cmbUbi
            // 
            cmbUbi.BackColor = Color.Lavender;
            cmbUbi.ForeColor = Color.Black;
            cmbUbi.FormattingEnabled = true;
            cmbUbi.Items.AddRange(new object[] { "Tijuana", "CDMX", "Toluca", "Durango", "SLP", "Cancún" });
            cmbUbi.Location = new Point(917, 109);
            cmbUbi.Name = "cmbUbi";
            cmbUbi.Size = new Size(223, 23);
            cmbUbi.TabIndex = 41;
            // 
            // lblFilCat
            // 
            lblFilCat.AutoSize = true;
            lblFilCat.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilCat.ForeColor = Color.MediumPurple;
            lblFilCat.Location = new Point(601, 76);
            lblFilCat.Name = "lblFilCat";
            lblFilCat.Size = new Size(221, 30);
            lblFilCat.TabIndex = 40;
            lblFilCat.Text = "Filtrar por categoría";
            // 
            // lblFilStatus
            // 
            lblFilStatus.AutoSize = true;
            lblFilStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilStatus.ForeColor = Color.MediumPurple;
            lblFilStatus.Location = new Point(296, 76);
            lblFilStatus.Name = "lblFilStatus";
            lblFilStatus.Size = new Size(198, 30);
            lblFilStatus.TabIndex = 39;
            lblFilStatus.Text = "Filtrar por estatus";
            // 
            // cmbCat
            // 
            cmbCat.BackColor = Color.Lavender;
            cmbCat.ForeColor = Color.Black;
            cmbCat.FormattingEnabled = true;
            cmbCat.Items.AddRange(new object[] { "Cat X", "Cat Y", "Cat Z" });
            cmbCat.Location = new Point(601, 109);
            cmbCat.Name = "cmbCat";
            cmbCat.Size = new Size(223, 23);
            cmbCat.Sorted = true;
            cmbCat.TabIndex = 38;
            // 
            // btnApF
            // 
            btnApF.AutoSize = true;
            btnApF.BackColor = Color.MediumPurple;
            btnApF.FlatStyle = FlatStyle.Flat;
            btnApF.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnApF.ForeColor = Color.White;
            btnApF.Location = new Point(804, 167);
            btnApF.Name = "btnApF";
            btnApF.Size = new Size(144, 37);
            btnApF.TabIndex = 37;
            btnApF.Text = "Aplicar Filtro";
            btnApF.UseVisualStyleBackColor = false;
            btnApF.Click += btnApF_Click;
            // 
            // cmbEstatus
            // 
            cmbEstatus.BackColor = Color.Lavender;
            cmbEstatus.ForeColor = Color.Black;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Inactivo", "Activo" });
            cmbEstatus.Location = new Point(296, 109);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(197, 23);
            cmbEstatus.TabIndex = 36;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.Anchor = AnchorStyles.None;
            dgvProductos.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.MediumPurple;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colNombre, colCategoria, colCosto, colCostoLetra, colStock, colUbicacion, colImpuesto, colClave, colEstatus });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.MediumPurple;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            dgvProductos.GridColor = SystemColors.Info;
            dgvProductos.ImeMode = ImeMode.Disable;
            dgvProductos.Location = new Point(23, 290);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(1123, 349);
            dgvProductos.TabIndex = 35;
            // 
            // colNombre
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle3.ForeColor = Color.White;
            colNombre.DefaultCellStyle = dataGridViewCellStyle3;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 140;
            // 
            // colCategoria
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle4.ForeColor = Color.White;
            colCategoria.DefaultCellStyle = dataGridViewCellStyle4;
            colCategoria.HeaderText = "Categoria";
            colCategoria.MinimumWidth = 8;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            colCategoria.Width = 140;
            // 
            // colCosto
            // 
            colCosto.HeaderText = "Costo unitario";
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            // 
            // colCostoLetra
            // 
            colCostoLetra.HeaderText = "Costo unitario";
            colCostoLetra.Name = "colCostoLetra";
            colCostoLetra.ReadOnly = true;
            colCostoLetra.Width = 150;
            // 
            // colStock
            // 
            dataGridViewCellStyle5.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle5.ForeColor = Color.White;
            colStock.DefaultCellStyle = dataGridViewCellStyle5;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 8;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colUbicacion
            // 
            colUbicacion.HeaderText = "Ubicación";
            colUbicacion.Name = "colUbicacion";
            colUbicacion.ReadOnly = true;
            colUbicacion.Width = 140;
            // 
            // colImpuesto
            // 
            colImpuesto.HeaderText = "Impuesto";
            colImpuesto.Name = "colImpuesto";
            colImpuesto.ReadOnly = true;
            // 
            // colClave
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle6.ForeColor = Color.White;
            colClave.DefaultCellStyle = dataGridViewCellStyle6;
            colClave.HeaderText = "Clave";
            colClave.MinimumWidth = 8;
            colClave.Name = "colClave";
            colClave.ReadOnly = true;
            colClave.Width = 120;
            // 
            // colEstatus
            // 
            dataGridViewCellStyle7.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle7.ForeColor = Color.White;
            colEstatus.DefaultCellStyle = dataGridViewCellStyle7;
            colEstatus.HeaderText = "Estatus";
            colEstatus.MinimumWidth = 8;
            colEstatus.Name = "colEstatus";
            colEstatus.ReadOnly = true;
            colEstatus.Width = 130;
            // 
            // gbProducto
            // 
            gbProducto.Controls.Add(txtClave);
            gbProducto.Controls.Add(lblFilClave);
            gbProducto.Controls.Add(btResVentas);
            gbProducto.Controls.Add(lblSeleccionProducto);
            gbProducto.Controls.Add(cmbEstatus);
            gbProducto.Controls.Add(btnReiniciarF);
            gbProducto.Controls.Add(btnApF);
            gbProducto.Controls.Add(lblFilUbi);
            gbProducto.Controls.Add(cmbCat);
            gbProducto.Controls.Add(cmbUbi);
            gbProducto.Controls.Add(lblFilStatus);
            gbProducto.Controls.Add(lblFilCat);
            gbProducto.Location = new Point(6, 45);
            gbProducto.Name = "gbProducto";
            gbProducto.Size = new Size(1157, 224);
            gbProducto.TabIndex = 44;
            gbProducto.TabStop = false;
            // 
            // txtClave
            // 
            txtClave.CharacterCasing = CharacterCasing.Upper;
            txtClave.Location = new Point(17, 109);
            txtClave.MaxLength = 15;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(176, 23);
            txtClave.TabIndex = 47;
            // 
            // lblFilClave
            // 
            lblFilClave.AutoSize = true;
            lblFilClave.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilClave.ForeColor = Color.MediumPurple;
            lblFilClave.Location = new Point(17, 76);
            lblFilClave.Name = "lblFilClave";
            lblFilClave.Size = new Size(176, 30);
            lblFilClave.TabIndex = 46;
            lblFilClave.Text = "Filtrar por clave";
            // 
            // btResVentas
            // 
            btResVentas.AutoSize = true;
            btResVentas.BackColor = Color.MediumTurquoise;
            btResVentas.FlatStyle = FlatStyle.Flat;
            btResVentas.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btResVentas.ForeColor = Color.White;
            btResVentas.Location = new Point(16, 167);
            btResVentas.Name = "btResVentas";
            btResVentas.Size = new Size(194, 37);
            btResVentas.TabIndex = 45;
            btResVentas.Text = "Resumen de ventas";
            btResVentas.UseVisualStyleBackColor = false;
            btResVentas.Click += btResVentas_Click;
            // 
            // lblSeleccionProducto
            // 
            lblSeleccionProducto.AutoSize = true;
            lblSeleccionProducto.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSeleccionProducto.ForeColor = Color.MediumPurple;
            lblSeleccionProducto.Location = new Point(6, 19);
            lblSeleccionProducto.Name = "lblSeleccionProducto";
            lblSeleccionProducto.Size = new Size(229, 30);
            lblSeleccionProducto.TabIndex = 44;
            lblSeleccionProducto.Text = "Seleccione producto:";
            // 
            // frmApiInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 660);
            Controls.Add(gbProducto);
            Controls.Add(dgvProductos);
            Controls.Add(lblTitulo);
            Name = "frmApiInicio";
            Text = "frmApiInicio";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            gbProducto.ResumeLayout(false);
            gbProducto.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Button btnReiniciarF;
        private Label lblFilUbi;
        private ComboBox cmbUbi;
        private Label lblFilCat;
        private Label lblFilStatus;
        private ComboBox cmbCat;
        private Button btnApF;
        private ComboBox cmbEstatus;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCosto;
        private DataGridViewTextBoxColumn colCostoLetra;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colUbicacion;
        private DataGridViewTextBoxColumn colImpuesto;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colEstatus;
        private GroupBox gbProducto;
        private Button btResVentas;
        private Label lblSeleccionProducto;
        private TextBox txtClave;
        private Label lblFilClave;
    }
}