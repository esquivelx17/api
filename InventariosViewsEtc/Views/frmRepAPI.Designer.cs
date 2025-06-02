namespace InvSis.Views
{
    partial class frmRepAPI
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            dgvResumenVentas = new DataGridView();
            colClaveProducto = new DataGridViewTextBoxColumn();
            colIdCompra = new DataGridViewTextBoxColumn();
            colCodigoCompra = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colCosto = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            btnRegresar = new Button();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumenVentas).BeginInit();
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
            pnlTitulo.Size = new Size(1047, 36);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(2, 0, 2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(0, 6, 0, 0);
            lblTitulo.Size = new Size(1047, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "RESUMEN DE VENTAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvResumenVentas
            // 
            dgvResumenVentas.AllowUserToAddRows = false;
            dgvResumenVentas.AllowUserToDeleteRows = false;
            dgvResumenVentas.AllowUserToResizeColumns = false;
            dgvResumenVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvResumenVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResumenVentas.Anchor = AnchorStyles.None;
            dgvResumenVentas.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.MediumPurple;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvResumenVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResumenVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumenVentas.Columns.AddRange(new DataGridViewColumn[] { colClaveProducto, colIdCompra, colCodigoCompra, colFecha, colCliente, colCantidad, colCosto, colEstatus });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.MediumPurple;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvResumenVentas.DefaultCellStyle = dataGridViewCellStyle7;
            dgvResumenVentas.GridColor = SystemColors.Info;
            dgvResumenVentas.ImeMode = ImeMode.Disable;
            dgvResumenVentas.Location = new Point(26, 59);
            dgvResumenVentas.Name = "dgvResumenVentas";
            dgvResumenVentas.ReadOnly = true;
            dgvResumenVentas.RowHeadersVisible = false;
            dgvResumenVentas.RowHeadersWidth = 62;
            dgvResumenVentas.Size = new Size(993, 399);
            dgvResumenVentas.TabIndex = 16;
            // 
            // colClaveProducto
            // 
            colClaveProducto.HeaderText = "Clave de producto";
            colClaveProducto.Name = "colClaveProducto";
            colClaveProducto.ReadOnly = true;
            colClaveProducto.Width = 120;
            // 
            // colIdCompra
            // 
            colIdCompra.DataPropertyName = "Clave";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle3.ForeColor = Color.White;
            colIdCompra.DefaultCellStyle = dataGridViewCellStyle3;
            colIdCompra.HeaderText = "ID Compra";
            colIdCompra.MinimumWidth = 8;
            colIdCompra.Name = "colIdCompra";
            colIdCompra.ReadOnly = true;
            colIdCompra.Width = 120;
            // 
            // colCodigoCompra
            // 
            colCodigoCompra.DataPropertyName = "Nombre";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle4.ForeColor = Color.White;
            colCodigoCompra.DefaultCellStyle = dataGridViewCellStyle4;
            colCodigoCompra.HeaderText = "Codigo de compra";
            colCodigoCompra.MinimumWidth = 8;
            colCodigoCompra.Name = "colCodigoCompra";
            colCodigoCompra.ReadOnly = true;
            colCodigoCompra.Width = 140;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "CostoUnitario";
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 140;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "Stock";
            dataGridViewCellStyle5.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle5.ForeColor = Color.White;
            colCliente.DefaultCellStyle = dataGridViewCellStyle5;
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 8;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            colCliente.Width = 150;
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Impuesto";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colCosto
            // 
            colCosto.DataPropertyName = "EstatusTexto";
            dataGridViewCellStyle6.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle6.ForeColor = Color.White;
            colCosto.DefaultCellStyle = dataGridViewCellStyle6;
            colCosto.HeaderText = "Costo";
            colCosto.MinimumWidth = 8;
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            // 
            // colEstatus
            // 
            colEstatus.HeaderText = "Estatus";
            colEstatus.Name = "colEstatus";
            colEstatus.ReadOnly = true;
            colEstatus.Width = 120;
            // 
            // btnRegresar
            // 
            btnRegresar.AutoSize = true;
            btnRegresar.BackColor = Color.MediumPurple;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(917, 483);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(102, 37);
            btnRegresar.TabIndex = 38;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // frmRepAPI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1047, 542);
            Controls.Add(btnRegresar);
            Controls.Add(dgvResumenVentas);
            Controls.Add(pnlTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(159, 122, 234);
            Name = "frmRepAPI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRepAPI";
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumenVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private DataGridView dgvResumenVentas;
        private Button btnRegresar;
        private DataGridViewTextBoxColumn colClaveProducto;
        private DataGridViewTextBoxColumn colIdCompra;
        private DataGridViewTextBoxColumn colCodigoCompra;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colCosto;
        private DataGridViewTextBoxColumn colEstatus;
    }
}