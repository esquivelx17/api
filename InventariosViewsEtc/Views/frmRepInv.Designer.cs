namespace InvSis.Views
{
    partial class frmRepInv
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
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblFecIni = new Label();
            lblFecFin = new Label();
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
            lblFilUbi = new Label();
            cmbUbi = new ComboBox();
            lblFilCat = new Label();
            lblFilStatus = new Label();
            cmbCat = new ComboBox();
            btnApF = new Button();
            cmbEstatus = new ComboBox();
            btnReiniciarF = new Button();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(159, 122, 234);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Margin = new Padding(2);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1194, 36);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(2, 0, 2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1194, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTE DE INVENTARIO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFecIni
            // 
            lblFecIni.AutoSize = true;
            lblFecIni.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFecIni.ForeColor = Color.FromArgb(64, 64, 64);
            lblFecIni.Location = new Point(173, 15);
            lblFecIni.Name = "lblFecIni";
            lblFecIni.Size = new Size(87, 19);
            lblFecIni.TabIndex = 5;
            lblFecIni.Text = "Fecha Inicial";
            // 
            // lblFecFin
            // 
            lblFecFin.AutoSize = true;
            lblFecFin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFecFin.ForeColor = Color.FromArgb(64, 64, 64);
            lblFecFin.Location = new Point(718, 15);
            lblFecFin.Name = "lblFecFin";
            lblFecFin.Size = new Size(79, 19);
            lblFecFin.TabIndex = 6;
            lblFecFin.Text = "Fecha Final";
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
            dgvProductos.Location = new Point(33, 222);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(1123, 316);
            dgvProductos.TabIndex = 16;
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
            // lblFilUbi
            // 
            lblFilUbi.AutoSize = true;
            lblFilUbi.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilUbi.ForeColor = Color.MediumPurple;
            lblFilUbi.Location = new Point(934, 60);
            lblFilUbi.Name = "lblFilUbi";
            lblFilUbi.Size = new Size(222, 30);
            lblFilUbi.TabIndex = 33;
            lblFilUbi.Text = "Filtrar por ubicación";
            // 
            // cmbUbi
            // 
            cmbUbi.BackColor = Color.Lavender;
            cmbUbi.ForeColor = Color.Black;
            cmbUbi.FormattingEnabled = true;
            cmbUbi.Items.AddRange(new object[] { "Tijuana", "CDMX", "Toluca", "Durango", "SLP", "Cancún" });
            cmbUbi.Location = new Point(934, 97);
            cmbUbi.Name = "cmbUbi";
            cmbUbi.Size = new Size(223, 23);
            cmbUbi.TabIndex = 32;
            // 
            // lblFilCat
            // 
            lblFilCat.AutoSize = true;
            lblFilCat.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilCat.ForeColor = Color.MediumPurple;
            lblFilCat.Location = new Point(447, 60);
            lblFilCat.Name = "lblFilCat";
            lblFilCat.Size = new Size(221, 30);
            lblFilCat.TabIndex = 31;
            lblFilCat.Text = "Filtrar por categoría";
            // 
            // lblFilStatus
            // 
            lblFilStatus.AutoSize = true;
            lblFilStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilStatus.ForeColor = Color.MediumPurple;
            lblFilStatus.Location = new Point(33, 64);
            lblFilStatus.Name = "lblFilStatus";
            lblFilStatus.Size = new Size(198, 30);
            lblFilStatus.TabIndex = 30;
            lblFilStatus.Text = "Filtrar por estatus";
            // 
            // cmbCat
            // 
            cmbCat.BackColor = Color.Lavender;
            cmbCat.ForeColor = Color.Black;
            cmbCat.FormattingEnabled = true;
            cmbCat.Items.AddRange(new object[] { "Cat X", "Cat Y", "Cat Z" });
            cmbCat.Location = new Point(447, 97);
            cmbCat.Name = "cmbCat";
            cmbCat.Size = new Size(223, 23);
            cmbCat.Sorted = true;
            cmbCat.TabIndex = 29;
            // 
            // btnApF
            // 
            btnApF.AutoSize = true;
            btnApF.BackColor = Color.MediumPurple;
            btnApF.FlatStyle = FlatStyle.Flat;
            btnApF.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnApF.ForeColor = Color.White;
            btnApF.Location = new Point(821, 155);
            btnApF.Name = "btnApF";
            btnApF.Size = new Size(144, 37);
            btnApF.TabIndex = 28;
            btnApF.Text = "Aplicar Filtro";
            btnApF.UseVisualStyleBackColor = false;
            btnApF.Click += btnApF_Click_1;
            // 
            // cmbEstatus
            // 
            cmbEstatus.BackColor = Color.Lavender;
            cmbEstatus.ForeColor = Color.Black;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Inactivo", "Activo" });
            cmbEstatus.Location = new Point(33, 97);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(197, 23);
            cmbEstatus.TabIndex = 27;
            // 
            // btnReiniciarF
            // 
            btnReiniciarF.AutoSize = true;
            btnReiniciarF.BackColor = Color.MediumPurple;
            btnReiniciarF.FlatStyle = FlatStyle.Flat;
            btnReiniciarF.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnReiniciarF.ForeColor = Color.White;
            btnReiniciarF.Location = new Point(1005, 155);
            btnReiniciarF.Name = "btnReiniciarF";
            btnReiniciarF.Size = new Size(152, 37);
            btnReiniciarF.TabIndex = 34;
            btnReiniciarF.Text = "Reiniciar Filtro";
            btnReiniciarF.UseVisualStyleBackColor = false;
            btnReiniciarF.Click += btnReiniciarF_Click;
            // 
            // frmRepInv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1194, 566);
            Controls.Add(btnReiniciarF);
            Controls.Add(lblFilUbi);
            Controls.Add(cmbUbi);
            Controls.Add(lblFilCat);
            Controls.Add(lblFilStatus);
            Controls.Add(cmbCat);
            Controls.Add(btnApF);
            Controls.Add(cmbEstatus);
            Controls.Add(dgvProductos);
            Controls.Add(pnlTitulo);
            Controls.Add(lblFecFin);
            Controls.Add(lblFecIni);
            Name = "frmRepInv";
            Text = "frmRepInv";
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private Label lblFecIni;
        private Label lblFecFin;
        private DataGridView dgvProductos;
        private Label lblFilUbi;
        private ComboBox cmbUbi;
        private Label lblFilCat;
        private Label lblFilStatus;
        private ComboBox cmbCat;
        private Button btnApF;
        private ComboBox cmbEstatus;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCosto;
        private DataGridViewTextBoxColumn colCostoLetra;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colUbicacion;
        private DataGridViewTextBoxColumn colImpuesto;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colEstatus;
        private Button btnReiniciarF;
    }
}