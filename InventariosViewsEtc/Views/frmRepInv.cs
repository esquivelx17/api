using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventariosCore.Business;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmRepInv : Form
    {
        private readonly RepInvController _controller = new RepInvController();

        public frmRepInv()
        {
            InitializeComponent();

            dgvProductos.AutoGenerateColumns = false;

            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbi.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCat.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;

            ConfigurarColumnas();

            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;

            CargarDatos();

            btnApF.Click += btnApF_Click_1;
            btnReiniciarF.Click += btnReiniciarF_Click;
        }

        private void ConfigurarColumnas()
        {
            colNombre.DataPropertyName = "Nombre";
            colCategoria.DataPropertyName = "Categoria";
            colCosto.DataPropertyName = "Costo";
            colCostoLetra.DataPropertyName = "CostoEnTexto";
            colStock.DataPropertyName = "Stock";
            colUbicacion.DataPropertyName = "Ubicacion";
            colClave.DataPropertyName = "Clave";

            // colImpuesto y colEstatus se llenan en DataBindingComplete
        }

        private void CargarDatos(string? categoria = null, int? estatus = null, string? ubicacion = null)
        {
            var productos = _controller.ObtenerProductos(categoria, estatus, ubicacion);

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
        }

        private void dgvProductos_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            int existenciaMinima = ProductosNegocio.ObtenerExistenciaMinima();

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    row.Cells["colImpuesto"].Value = (p.AplicaImpuesto && p.Impuesto != null)
                        ? (p.Impuesto.TipoImpuesto ?? "N/A")
                        : "N/A";

                    row.Cells["colEstatus"].Value = p.Estatus == 1 ? "Activo" : "Inactivo";

                    // Resaltar si stock bajo
                    if (p.Stock.HasValue && p.Stock.Value < existenciaMinima)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnApF_Click_1(object sender, EventArgs e)
        {
            string? categoria = cmbCat.SelectedItem?.ToString();
            int? estatus = null;
            string? ubicacion = cmbUbi.SelectedItem?.ToString();

            if (cmbEstatus.SelectedItem != null)
                estatus = cmbEstatus.SelectedItem.ToString() == "Activo" ? 1 : 0;

            if (string.IsNullOrEmpty(categoria)) categoria = null;
            if (string.IsNullOrEmpty(ubicacion)) ubicacion = null;

            CargarDatos(categoria, estatus, ubicacion);
        }

        private void btnReiniciarF_Click(object sender, EventArgs e)
        {
            cmbCat.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;

            CargarDatos();
        }
    }
}
