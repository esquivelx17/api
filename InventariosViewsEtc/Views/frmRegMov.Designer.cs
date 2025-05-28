using System.Windows.Forms;

namespace InvSis.Views
{
    partial class frmRegMov : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private Label lblEstatus;
        private ComboBox cmbEstatus;
        private NumericUpDown nudCantidad;
        private Label lblProd;
        private Label lblCan;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lbSeleccioneOperador;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCosto;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colUbicacion;
        private DataGridViewTextBoxColumn colImpuesto;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colEstatus;
        private DataGridView dgvSeleccionUsuario;
        private DataGridViewTextBoxColumn colRol;
        private DataGridViewTextBoxColumn colNickname;
        private DataGridViewTextBoxColumn colPersona;
        private DataGridView dtgRegMov;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colOperador;
        private DataGridViewTextBoxColumn colEstatuss;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCantidad;

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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            lblEstatus = new Label();
            cmbEstatus = new ComboBox();
            nudCantidad = new NumericUpDown();
            lblProd = new Label();
            lblCan = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lbSeleccioneOperador = new Label();
            dgvProductos = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colCosto = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colUbicacion = new DataGridViewTextBoxColumn();
            colImpuesto = new DataGridViewTextBoxColumn();
            colClave = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            dgvSeleccionUsuario = new DataGridView();
            colRol = new DataGridViewTextBoxColumn();
            colNickname = new DataGridViewTextBoxColumn();
            colPersona = new DataGridViewTextBoxColumn();
            dtgRegMov = new DataGridView();
            colProducto = new DataGridViewTextBoxColumn();
            colOperador = new DataGridViewTextBoxColumn();
            colEstatuss = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSeleccionUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgRegMov).BeginInit();
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
            lblTitulo.Size = new Size(1431, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO MOVIMIENTOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(1184, 399);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(122, 23);
            dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(1184, 381);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(130, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha del Movimiento";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(1184, 331);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(46, 15);
            lblEstatus.TabIndex = 5;
            lblEstatus.Text = "Estatus";
            // 
            // cmbEstatus
            // 
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Pendiente", "Aprobado", "Revisado", "Rechazado" });
            cmbEstatus.Location = new Point(1184, 349);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(122, 23);
            cmbEstatus.TabIndex = 6;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(1184, 443);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(76, 23);
            nudCantidad.TabIndex = 8;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Location = new Point(606, 42);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(128, 15);
            lblProd.TabIndex = 9;
            lblProd.Text = "Seleccionar Producto:";
            // 
            // lblCan
            // 
            lblCan.AutoSize = true;
            lblCan.Location = new Point(1184, 425);
            lblCan.Name = "lblCan";
            lblCan.Size = new Size(55, 15);
            lblCan.TabIndex = 10;
            lblCan.Text = "Cantidad";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1184, 562);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 25);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar Movimiento";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(1184, 593);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 25);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // lbSeleccioneOperador
            // 
            lbSeleccioneOperador.AutoSize = true;
            lbSeleccioneOperador.Location = new Point(606, 313);
            lbSeleccioneOperador.Name = "lbSeleccioneOperador";
            lbSeleccioneOperador.Size = new Size(121, 15);
            lbSeleccioneOperador.TabIndex = 15;
            lbSeleccioneOperador.Text = "Seleccione operador";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.MediumPurple;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colNombre, colCategoria, colCosto, colStock, colUbicacion, colImpuesto, colClave, colEstatus });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.MediumPurple;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            dgvProductos.GridColor = SystemColors.Info;
            dgvProductos.ImeMode = ImeMode.Disable;
            dgvProductos.Location = new Point(606, 60);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(813, 235);
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
            // dgvSeleccionUsuario
            // 
            dgvSeleccionUsuario.AllowUserToAddRows = false;
            dgvSeleccionUsuario.AllowUserToDeleteRows = false;
            dgvSeleccionUsuario.AllowUserToResizeColumns = false;
            dgvSeleccionUsuario.AllowUserToResizeRows = false;
            dgvSeleccionUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeleccionUsuario.Columns.AddRange(new DataGridViewColumn[] { colRol, colNickname, colPersona });
            dgvSeleccionUsuario.Location = new Point(606, 331);
            dgvSeleccionUsuario.Name = "dgvSeleccionUsuario";
            dgvSeleccionUsuario.Size = new Size(554, 287);
            dgvSeleccionUsuario.TabIndex = 26;
            // 
            // colRol
            // 
            colRol.HeaderText = "Rol";
            colRol.MinimumWidth = 150;
            colRol.Name = "colRol";
            colRol.Width = 150;
            // 
            // colNickname
            // 
            colNickname.HeaderText = "Nickname";
            colNickname.MinimumWidth = 150;
            colNickname.Name = "colNickname";
            colNickname.Width = 150;
            // 
            // colPersona
            // 
            colPersona.HeaderText = "Persona";
            colPersona.MinimumWidth = 210;
            colPersona.Name = "colPersona";
            colPersona.Width = 210;
            // 
            // dtgRegMov
            // 
            dtgRegMov.AllowUserToAddRows = false;
            dtgRegMov.AllowUserToDeleteRows = false;
            dtgRegMov.AllowUserToResizeColumns = false;
            dtgRegMov.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(250, 250, 250);
            dtgRegMov.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dtgRegMov.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = Color.MediumPurple;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dtgRegMov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dtgRegMov.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgRegMov.Columns.AddRange(new DataGridViewColumn[] { colProducto, colOperador, colEstatuss, colFecha, colCantidad });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle15.SelectionForeColor = Color.MediumPurple;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            dtgRegMov.DefaultCellStyle = dataGridViewCellStyle15;
            dtgRegMov.GridColor = SystemColors.Info;
            dtgRegMov.ImeMode = ImeMode.Disable;
            dtgRegMov.Location = new Point(12, 60);
            dtgRegMov.Name = "dtgRegMov";
            dtgRegMov.ReadOnly = true;
            dtgRegMov.RowHeadersVisible = false;
            dtgRegMov.RowHeadersWidth = 62;
            dtgRegMov.Size = new Size(564, 556);
            dtgRegMov.TabIndex = 27;
            // 
            // colProducto
            // 
            dataGridViewCellStyle11.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle11.ForeColor = Color.White;
            colProducto.DefaultCellStyle = dataGridViewCellStyle11;
            colProducto.HeaderText = "Producto";
            colProducto.MinimumWidth = 8;
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            colProducto.Width = 120;
            // 
            // colOperador
            // 
            dataGridViewCellStyle12.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle12.ForeColor = Color.White;
            colOperador.DefaultCellStyle = dataGridViewCellStyle12;
            colOperador.HeaderText = "Operador";
            colOperador.MinimumWidth = 8;
            colOperador.Name = "colOperador";
            colOperador.ReadOnly = true;
            colOperador.Width = 120;
            // 
            // colEstatuss
            // 
            dataGridViewCellStyle13.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle13.ForeColor = Color.White;
            colEstatuss.DefaultCellStyle = dataGridViewCellStyle13;
            colEstatuss.HeaderText = "Estatus";
            colEstatuss.MinimumWidth = 8;
            colEstatuss.Name = "colEstatuss";
            colEstatuss.ReadOnly = true;
            colEstatuss.Width = 120;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle14.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle14.ForeColor = Color.White;
            colCantidad.DefaultCellStyle = dataGridViewCellStyle14;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 8;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // frmRegMov
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1431, 642);
            Controls.Add(dtgRegMov);
            Controls.Add(dgvSeleccionUsuario);
            Controls.Add(dgvProductos);
            Controls.Add(lbSeleccioneOperador);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblCan);
            Controls.Add(nudCantidad);
            Controls.Add(cmbEstatus);
            Controls.Add(lblEstatus);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblProd);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(159, 122, 234);
            Name = "frmRegMov";
            Text = "Registro Movimientos";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSeleccionUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgRegMov).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
