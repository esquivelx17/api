using System.Windows.Forms;

namespace InvSis.Views
{
    partial class frmVReportesAuditoria
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
        // En el archivo AuditoriasForm.Designer.cs (dentro del InitializeComponent)
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();

            pnlTitulo = new Panel();
            lblTitulo = new Label();
            gbFiltros = new GroupBox();
            cmbTabla = new ComboBox();
            lblTabla = new Label();
            btnReiniciarF = new Button();
            btnExportar = new Button();
            btnAplicarF = new Button();
            cmbMovimiento = new ComboBox();
            lblMovimiento = new Label();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            dgvAuditorias = new DataGridView();
            toolTip = new ToolTip(components);
            colIdMovimiento = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colTipoMovimiento = new DataGridViewTextBoxColumn();
            colTabla = new DataGridViewTextBoxColumn();
            colIdUsuario = new DataGridViewTextBoxColumn();
            colIpEquipo = new DataGridViewTextBoxColumn();
            colNombreEquipo = new DataGridViewTextBoxColumn();

            pnlTitulo.SuspendLayout();
            gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditorias).BeginInit();
            SuspendLayout();

            // pnlTitulo
            pnlTitulo.BackColor = Color.FromArgb(159, 122, 234);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1468, 60);
            pnlTitulo.TabIndex = 0;

            // lblTitulo
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(0, 10, 0, 0);
            lblTitulo.Size = new Size(1468, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTE DE AUDITORÍAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // gbFiltros
            gbFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFiltros.BackColor = Color.FromArgb(230, 242, 248);
            gbFiltros.Controls.Add(cmbTabla);
            gbFiltros.Controls.Add(lblTabla);
            gbFiltros.Controls.Add(btnReiniciarF);
            gbFiltros.Controls.Add(btnExportar);
            gbFiltros.Controls.Add(btnAplicarF);
            gbFiltros.Controls.Add(cmbMovimiento);
            gbFiltros.Controls.Add(lblMovimiento);
            gbFiltros.Controls.Add(dtpFechaFin);
            gbFiltros.Controls.Add(dtpFechaInicio);
            gbFiltros.Controls.Add(label2);
            gbFiltros.Controls.Add(label1);
            gbFiltros.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gbFiltros.ForeColor = Color.FromArgb(159, 122, 234);
            gbFiltros.Location = new Point(12, 77);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(1444, 157);
            gbFiltros.TabIndex = 1;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros de Auditoría";

            // cmbTabla
            cmbTabla.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTabla.FormattingEnabled = true;
            cmbTabla.Items.AddRange(new object[] { "Todos", "Creación", "Modificación", "Eliminación", "Login", "Acceso" });
            cmbTabla.Location = new Point(469, 100);
            cmbTabla.Name = "cmbTabla";
            cmbTabla.Size = new Size(150, 25);
            cmbTabla.TabIndex = 14;

            // lblTabla
            lblTabla.AutoSize = true;
            lblTabla.Location = new Point(362, 100);
            lblTabla.Name = "lblTabla";
            lblTabla.Size = new Size(101, 17);
            lblTabla.TabIndex = 13;
            lblTabla.Text = "Tabla afectada:";

            // btnReiniciarF
            btnReiniciarF.AutoSize = true;
            btnReiniciarF.BackColor = Color.FromArgb(159, 122, 234);
            btnReiniciarF.FlatStyle = FlatStyle.Flat;
            btnReiniciarF.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReiniciarF.ForeColor = Color.White;
            btnReiniciarF.Location = new Point(692, 100);
            btnReiniciarF.Name = "btnReiniciarF";
            btnReiniciarF.Size = new Size(110, 35);
            btnReiniciarF.TabIndex = 12;
            btnReiniciarF.Text = "Reiniciar Filtro";
            btnReiniciarF.UseVisualStyleBackColor = false;
            btnReiniciarF.Click += btnReiniciarF_Click;

            // btnExportar
            btnExportar.AutoSize = true;
            btnExportar.BackColor = Color.FromArgb(76, 175, 80);
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(872, 43);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(118, 35);
            btnExportar.TabIndex = 11;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;

            // btnAplicarF
            btnAplicarF.AutoSize = true;
            btnAplicarF.BackColor = Color.FromArgb(159, 122, 234);
            btnAplicarF.FlatStyle = FlatStyle.Flat;
            btnAplicarF.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAplicarF.ForeColor = Color.White;
            btnAplicarF.Location = new Point(692, 43);
            btnAplicarF.Name = "btnAplicarF";
            btnAplicarF.Size = new Size(100, 35);
            btnAplicarF.TabIndex = 10;
            btnAplicarF.Text = "Aplicar Filtro";
            btnAplicarF.UseVisualStyleBackColor = false;
            btnAplicarF.Click += btnGenerar_Click;

            // cmbMovimiento
            cmbMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovimiento.FormattingEnabled = true;
            cmbMovimiento.Items.AddRange(new object[] { "Todos", "Creación", "Modificación", "Eliminación", "Login", "Acceso" });
            cmbMovimiento.Location = new Point(469, 43);
            cmbMovimiento.Name = "cmbMovimiento";
            cmbMovimiento.Size = new Size(150, 25);
            cmbMovimiento.TabIndex = 7;

            // lblMovimiento
            lblMovimiento.AutoSize = true;
            lblMovimiento.Location = new Point(362, 40);
            lblMovimiento.Name = "lblMovimiento";
            lblMovimiento.Size = new Size(87, 17);
            lblMovimiento.TabIndex = 6;
            lblMovimiento.Text = "Movimiento:";

            // dtpFechaFin
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(171, 100);
            dtpFechaFin.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(120, 25);
            dtpFechaFin.TabIndex = 3;

            // dtpFechaInicio
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(171, 43);
            dtpFechaInicio.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(120, 25);
            dtpFechaInicio.TabIndex = 2;

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(62, 100);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 1;
            label2.Text = "Fecha Fin:";

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(62, 43);
            label1.Name = "label1";
            label1.Size = new Size(85, 17);
            label1.TabIndex = 0;
            label1.Text = "Fecha Inicio:";

            // dgvAuditorias
            dgvAuditorias.AllowUserToAddRows = false;
            dgvAuditorias.AllowUserToDeleteRows = false;
            dgvAuditorias.AllowUserToResizeColumns = false;
            dgvAuditorias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvAuditorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditorias.Anchor = AnchorStyles.None;
            dgvAuditorias.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAuditorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditorias.Columns.AddRange(new DataGridViewColumn[] {
                                                                    colIdMovimiento,
                                                                    colFecha,
                                                                    colTipoMovimiento,
                                                                    colTabla,
                                                                    colIdUsuario,
                                                                    colIpEquipo,
                                                                    colNombreEquipo});
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvAuditorias.DefaultCellStyle = dataGridViewCellStyle8;
            dgvAuditorias.GridColor = SystemColors.Info;
            dgvAuditorias.ImeMode = ImeMode.Disable;
            dgvAuditorias.Location = new Point(13, 242);
            dgvAuditorias.Margin = new Padding(4, 5, 4, 5);
            dgvAuditorias.Name = "dgvAuditorias";
            dgvAuditorias.ReadOnly = true;
            dgvAuditorias.RowHeadersVisible = false;
            dgvAuditorias.RowHeadersWidth = 62;
            dgvAuditorias.Size = new Size(1442, 474);
            dgvAuditorias.TabIndex = 0;

            // colIdMovimiento
            colIdMovimiento.DataPropertyName = "IdAuditoria";
            colIdMovimiento.HeaderText = "ID MOVIMIENTO";
            colIdMovimiento.MinimumWidth = 8;
            colIdMovimiento.Name = "colIdMovimiento";
            colIdMovimiento.ReadOnly = true;
            colIdMovimiento.Width = 150;

            // colFecha
            colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle3.ForeColor = Color.White;
            colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            colFecha.HeaderText = "FECHA";
            colFecha.MinimumWidth = 8;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 150;

            // colTipoMovimiento
            colTipoMovimiento.DataPropertyName = "TipoMovimiento";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle4.ForeColor = Color.White;
            colTipoMovimiento.DefaultCellStyle = dataGridViewCellStyle4;
            colTipoMovimiento.HeaderText = "TIPO DE MOVIMIENTO";
            colTipoMovimiento.MinimumWidth = 8;
            colTipoMovimiento.Name = "colTipoMovimiento";
            colTipoMovimiento.ReadOnly = true;
            colTipoMovimiento.Width = 180;

            // colTabla
            colTabla.DataPropertyName = "TablaAfectada";
            colTabla.HeaderText = "TABLA AFECTADA";
            colTabla.Name = "colTabla";
            colTabla.ReadOnly = true;
            colTabla.Width = 150;

            // colIdUsuario
            colIdUsuario.DataPropertyName = "IdUsuario";
            dataGridViewCellStyle5.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle5.ForeColor = Color.White;
            colIdUsuario.DefaultCellStyle = dataGridViewCellStyle5;
            colIdUsuario.HeaderText = "ID USUARIO";
            colIdUsuario.MinimumWidth = 8;
            colIdUsuario.Name = "colIdUsuario";
            colIdUsuario.ReadOnly = true;
            colIdUsuario.Width = 180;

            // colIpEquipo
            colIpEquipo.DataPropertyName = "IpEquipo";
            dataGridViewCellStyle6.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle6.ForeColor = Color.White;
            colIpEquipo.DefaultCellStyle = dataGridViewCellStyle6;
            colIpEquipo.HeaderText = "IP EQUIPO";
            colIpEquipo.MinimumWidth = 8;
            colIpEquipo.Name = "colIpEquipo";
            colIpEquipo.ReadOnly = true;
            colIpEquipo.Width = 150;

            // colNombreEquipo
            colNombreEquipo.DataPropertyName = "NombreEquipo";
            dataGridViewCellStyle7.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle7.ForeColor = Color.White;
            colNombreEquipo.DefaultCellStyle = dataGridViewCellStyle7;
            colNombreEquipo.HeaderText = "NOMBRE DE EQUIPO";
            colNombreEquipo.MinimumWidth = 250;
            colNombreEquipo.Name = "colNombreEquipo";
            colNombreEquipo.ReadOnly = true;
            colNombreEquipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // 
            // frmVReportesAuditoria
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1468, 730);
            Controls.Add(dgvAuditorias);
            Controls.Add(gbFiltros);
            Controls.Add(pnlTitulo);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmVReportesAuditoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Auditorías";

            pnlTitulo.ResumeLayout(false);
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditorias).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblMovimiento;
        private System.Windows.Forms.ComboBox cmbMovimiento;
        private System.Windows.Forms.Button btnAplicarF;
        private DataGridView dgvAuditorias;
        private System.Windows.Forms.ToolTip toolTip;
        private Button btnExportar;
        private ComboBox cmbTabla;
        private Label lblTabla;
        private Button btnReiniciarF;
        private TextBox txtUsuario;
        private DataGridViewTextBoxColumn colIdMovimiento;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTipoMovimiento;
        private DataGridViewTextBoxColumn colTabla;
        private DataGridViewTextBoxColumn colIdUsuario;
        private DataGridViewTextBoxColumn colIpEquipo;
        private DataGridViewTextBoxColumn colNombreEquipo;
    }
}