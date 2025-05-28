using System.Windows.Forms;

namespace InvSis.Views
{
    partial class frmRegMov : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private ComboBox cmbTipoMov;
        private Label lblMovi;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private Label lblEstatus;
        private ComboBox cmbEstatus;
        private DataGridView dgvSeleccion;
        private NumericUpDown nudCantidad;
        private Label lblProd;
        private Label lblCan;
        private Button btnGuardar;
        private Button btnCancelar;
        private DataGridView dgvOperadores;

        /// <summary>
        /// Limpiar recursos usados.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método para inicializar componentes (generado por diseñador)
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
            cmbTipoMov = new ComboBox();
            lblMovi = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            lblEstatus = new Label();
            cmbEstatus = new ComboBox();
            dgvSeleccion = new DataGridView();
            nudCantidad = new NumericUpDown();
            lblProd = new Label();
            lblCan = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dgvOperadores = new DataGridView();
            lbSeleccioneOperador = new Label();
            dgvRegMov = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colCosto = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colUbicacion = new DataGridViewTextBoxColumn();
            colImpuesto = new DataGridViewTextBoxColumn();
            colClave = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSeleccion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOperadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegMov).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1193, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO MOVIMIENTOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbTipoMov
            // 
            cmbTipoMov.FormattingEnabled = true;
            cmbTipoMov.Items.AddRange(new object[] { "Alta de Productos", "Baja de Productos" });
            cmbTipoMov.Location = new Point(899, 401);
            cmbTipoMov.Name = "cmbTipoMov";
            cmbTipoMov.Size = new Size(122, 23);
            cmbTipoMov.TabIndex = 1;
            // 
            // lblMovi
            // 
            lblMovi.AutoSize = true;
            lblMovi.Location = new Point(899, 383);
            lblMovi.Name = "lblMovi";
            lblMovi.Size = new Size(119, 15);
            lblMovi.TabIndex = 2;
            lblMovi.Text = "Tipo de Movimiento";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(899, 445);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(899, 427);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(130, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha del Movimiento";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(899, 339);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(46, 15);
            lblEstatus.TabIndex = 5;
            lblEstatus.Text = "Estatus";
            // 
            // cmbEstatus
            // 
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Pendiente", "Aprobado", "Revisado", "Rechazado" });
            cmbEstatus.Location = new Point(899, 357);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(122, 23);
            cmbEstatus.TabIndex = 6;
            // 
            // dgvSeleccion
            // 
            dgvSeleccion.AllowUserToAddRows = false;
            dgvSeleccion.AllowUserToDeleteRows = false;
            dgvSeleccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeleccion.Location = new Point(22, 44);
            dgvSeleccion.Name = "dgvSeleccion";
            dgvSeleccion.ReadOnly = true;
            dgvSeleccion.RowHeadersWidth = 51;
            dgvSeleccion.Size = new Size(433, 574);
            dgvSeleccion.TabIndex = 7;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(899, 489);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(49, 23);
            nudCantidad.TabIndex = 8;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Location = new Point(503, 44);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(128, 15);
            lblProd.TabIndex = 9;
            lblProd.Text = "Seleccionar Producto:";
            // 
            // lblCan
            // 
            lblCan.AutoSize = true;
            lblCan.Location = new Point(899, 471);
            lblCan.Name = "lblCan";
            lblCan.Size = new Size(55, 15);
            lblCan.TabIndex = 10;
            lblCan.Text = "Cantidad";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1017, 543);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar Movimiento";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(899, 543);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvOperadores
            // 
            dgvOperadores.Location = new Point(503, 329);
            dgvOperadores.MultiSelect = false;
            dgvOperadores.Name = "dgvOperadores";
            dgvOperadores.ReadOnly = true;
            dgvOperadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperadores.Size = new Size(364, 275);
            dgvOperadores.TabIndex = 14;
            // 
            // lbSeleccioneOperador
            // 
            lbSeleccioneOperador.AutoSize = true;
            lbSeleccioneOperador.Location = new Point(503, 311);
            lbSeleccioneOperador.Name = "lbSeleccioneOperador";
            lbSeleccioneOperador.Size = new Size(121, 15);
            lbSeleccioneOperador.TabIndex = 15;
            lbSeleccioneOperador.Text = "Seleccione operador";
            // 
            // dgvRegMov
            // 
            dgvRegMov.AllowUserToAddRows = false;
            dgvRegMov.AllowUserToDeleteRows = false;
            dgvRegMov.AllowUserToResizeColumns = false;
            dgvRegMov.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvRegMov.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRegMov.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.MediumPurple;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRegMov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRegMov.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegMov.Columns.AddRange(new DataGridViewColumn[] { colNombre, colCategoria, colCosto, colStock, colUbicacion, colImpuesto, colClave, colEstatus });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.MediumPurple;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvRegMov.DefaultCellStyle = dataGridViewCellStyle8;
            dgvRegMov.GridColor = SystemColors.Info;
            dgvRegMov.ImeMode = ImeMode.Disable;
            dgvRegMov.Location = new Point(503, 62);
            dgvRegMov.Name = "dgvRegMov";
            dgvRegMov.ReadOnly = true;
            dgvRegMov.RowHeadersVisible = false;
            dgvRegMov.RowHeadersWidth = 62;
            dgvRegMov.Size = new Size(622, 234);
            dgvRegMov.TabIndex = 16;
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
            // frmRegMov
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1193, 630);
            Controls.Add(dgvRegMov);
            Controls.Add(lbSeleccioneOperador);
            Controls.Add(dgvOperadores);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblCan);
            Controls.Add(nudCantidad);
            Controls.Add(dgvSeleccion);
            Controls.Add(cmbEstatus);
            Controls.Add(lblEstatus);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblMovi);
            Controls.Add(cmbTipoMov);
            Controls.Add(lblProd);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(159, 122, 234);
            Name = "frmRegMov";
            Text = "Registro Movimientos";
            ((System.ComponentModel.ISupportInitialize)dgvSeleccion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOperadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegMov).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lbSeleccioneOperador;
        private DataGridView dgvRegMov;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCosto;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colUbicacion;
        private DataGridViewTextBoxColumn colImpuesto;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colEstatus;
    }
}
