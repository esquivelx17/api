using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmVReportesAuditoria : Form
    {
        private readonly AuditoriaController _controller;

        public frmVReportesAuditoria()
        {
            InitializeComponent();

            _controller = new AuditoriaController();

            // Configuración inicial
            cmbMovimiento.SelectedIndex = 0;
            cmbTabla.Items.Clear();
            cmbTabla.Items.Add("Todos");
            cmbTabla.Items.Add("Usuarios");
            cmbTabla.Items.Add("Productos");
            cmbTabla.Items.Add("Roles");
            cmbTabla.Items.Add("Permisos");
            cmbTabla.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Now.Date.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now.Date;

            CargarAuditorias();
        }

        private void CargarAuditorias(DateTime? fechaInicio = null, DateTime? fechaFin = null, string? tipoMovimiento = null, string? tablaAfectada = null)
        {
            try
            {
                var auditorias = _controller.ObtenerAuditorias(fechaInicio, fechaFin, tipoMovimiento, tablaAfectada);

                dgvAuditorias.AutoGenerateColumns = false;  // Agrega esta línea

                dgvAuditorias.DataSource = null;
                dgvAuditorias.DataSource = auditorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar auditorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string? tipoMov = cmbMovimiento.SelectedItem?.ToString();
            if (tipoMov == "Todos") tipoMov = null;

            string? tabla = cmbTabla.SelectedItem?.ToString();
            if (tabla == "Todos") tabla = null;

            CargarAuditorias(dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date, tipoMov, tabla);
        }

        private void btnReiniciarF_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now.Date.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now.Date;
            cmbMovimiento.SelectedIndex = 0;
            cmbTabla.SelectedIndex = 0;

            CargarAuditorias();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función pendiente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
