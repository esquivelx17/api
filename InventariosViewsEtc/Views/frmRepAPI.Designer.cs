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
            pnlTitulo.UseWaitCursor = true;
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
            lblTitulo.UseWaitCursor = true;
            // 
            // dgvResumenVentas
            // 
            dgvResumenVentas.AllowUserToAddRows = false;
            dgvResumenVentas.AllowUserToDeleteRows = false;
            dgvResumenVentas.AllowUserToResizeColumns = false;
            dgvResumenVentas.AllowUserToResizeRows = false;
            dgvResumenVentas.Anchor = AnchorStyles.None;
            dgvResumenVentas.BackgroundColor = Color.FromArgb(42, 34, 58);
            dgvResumenVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResumenVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumenVentas.Columns.AddRange(new DataGridViewColumn[] { colClaveProducto, colIdCompra, colCodigoCompra, colFecha, colCliente, colCantidad, colCosto, colEstatus });
            dgvResumenVentas.GridColor = SystemColors.Info;
            dgvResumenVentas.ImeMode = ImeMode.Disable;
            dgvResumenVentas.Location = new Point(27, 58);
            dgvResumenVentas.Name = "dgvResumenVentas";
            dgvResumenVentas.ReadOnly = true;
            dgvResumenVentas.RowHeadersVisible = false;
            dgvResumenVentas.Size = new Size(993, 399);
            dgvResumenVentas.TabIndex = 16;
            dgvResumenVentas.UseWaitCursor = true;
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
            colIdCompra.DataPropertyName = "IdCompra";
            colIdCompra.HeaderText = "ID Compra";
            colIdCompra.Name = "colIdCompra";
            colIdCompra.ReadOnly = true;
            colIdCompra.Width = 120;
            // 
            // colCodigoCompra
            // 
            colCodigoCompra.DataPropertyName = "CodigoCompra";
            colCodigoCompra.HeaderText = "Codigo de compra";
            colCodigoCompra.Name = "colCodigoCompra";
            colCodigoCompra.ReadOnly = true;
            colCodigoCompra.Width = 140;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaCompra";
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 140;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            colCliente.Width = 150;
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colCosto
            // 
            colCosto.DataPropertyName = "Costo";
            colCosto.HeaderText = "Costo";
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            // 
            // colEstatus
            // 
            colEstatus.DataPropertyName = "Estatus";
            colEstatus.HeaderText = "Estatus";
            colEstatus.Name = "colEstatus";
            colEstatus.ReadOnly = true;
            // 
            // frmRepAPI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1047, 479);
            Controls.Add(dgvResumenVentas);
            Controls.Add(pnlTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(159, 122, 234);
            MinimumSize = new Size(1063, 518);
            Name = "frmRepAPI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRepAPI";
            UseWaitCursor = true;
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumenVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private DataGridView dgvResumenVentas;
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