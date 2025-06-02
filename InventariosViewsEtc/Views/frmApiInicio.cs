using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmApiInicio : Form
    {
        private readonly ProductosController _productosController = new ProductosController();
        private List<Producto> _productosCache = new List<Producto>();
        private Producto? _productoSeleccionado = null;

        // Flag para evitar abrir varias instancias simultáneas
        private bool _resumenAbierto = false;

        public frmApiInicio()
        {
            InitializeComponent();
            ConfigurarControles();
            ConfigurarColumnasDGV();
            CargarFiltros();
            CargarProductosEnGrid();
        }

        private void ConfigurarControles()
        {
            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;
            txtClave.CharacterCasing = CharacterCasing.Upper;  // Mayúsculas automáticas
        }

        private void ConfigurarColumnasDGV()
        {
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 140,
                Name = "colNombre",
                DefaultCellStyle = { ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Width = 140,
                Name = "colCategoria",
                DefaultCellStyle = { ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Costo",
                HeaderText = "Costo unitario",
                Width = 90,
                Name = "colCosto",
                DefaultCellStyle = { Format = "C2", ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 60,
                Name = "colStock",
                DefaultCellStyle = { ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ubicacion",
                HeaderText = "Ubicación",
                Width = 120,
                Name = "colUbicacion",
                DefaultCellStyle = { ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                Width = 100,
                Name = "colImpuesto",
                DefaultCellStyle = { ForeColor = Color.Black }
                // Sin DataPropertyName, se asigna manualmente en el grid
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Clave",
                HeaderText = "Clave",
                Width = 120,
                Name = "colClave",
                DefaultCellStyle = { ForeColor = Color.Black }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estatus",
                Width = 90,
                Name = "colEstatus",
                DefaultCellStyle = { ForeColor = Color.Black }
                // Sin DataPropertyName, asignado manualmente
            });
        }

        private void CargarFiltros()
        {
            cmbCat.Items.Clear();
            cmbUbi.Items.Clear();
            cmbEstatus.Items.Clear();

            var productos = _productosController.ObtenerProductos(null, null);
            var categorias = new HashSet<string>();
            var ubicaciones = new HashSet<string>();

            foreach (var p in productos)
            {
                if (!string.IsNullOrEmpty(p.Categoria))
                    categorias.Add(p.Categoria);
                if (!string.IsNullOrEmpty(p.Ubicacion))
                    ubicaciones.Add(p.Ubicacion);
            }

            cmbCat.Items.AddRange(categorias.OrderBy(c => c).ToArray());
            cmbUbi.Items.AddRange(ubicaciones.OrderBy(u => u).ToArray());

            cmbEstatus.Items.Add("Inactivo");
            cmbEstatus.Items.Add("Activo");

            cmbCat.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;
        }

        private void CargarProductosEnGrid(string? categoria = null, int? estatus = null, string? ubicacion = null, string? clave = null)
        {
            var productos = _productosController.ObtenerProductos(categoria, estatus);

            if (!string.IsNullOrEmpty(ubicacion))
                productos = productos.FindAll(p => p.Ubicacion == ubicacion);

            if (!string.IsNullOrEmpty(clave))
                productos = productos.FindAll(p => p.Clave.StartsWith(clave, StringComparison.OrdinalIgnoreCase));

            _productosCache = productos;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;

            var productosStockBajo = _productosController.ObtenerProductosConStockBajo();
            var idsStockBajo = new HashSet<int>(productosStockBajo.ConvertAll(p => p.IdProducto));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    row.Cells["colImpuesto"].Value = p.Impuesto?.TipoImpuesto ?? "No Aplica";
                    row.Cells["colEstatus"].Value = p.Estatus == 1 ? "Activo" : "Inactivo";

                    if (idsStockBajo.Contains(p.IdProducto))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }

            dgvProductos.ClearSelection();
            _productoSeleccionado = null;
        }

        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                _productoSeleccionado = null;
                return;
            }

            _productoSeleccionado = dgvProductos.CurrentRow.DataBoundItem as Producto;
        }

        private void btnApF_Click(object sender, EventArgs e)
        {
            string? categoria = cmbCat.SelectedItem?.ToString();
            int? estatus = null;
            string? ubicacion = cmbUbi.SelectedItem?.ToString();
            string claveFiltro = txtClave.Text.Trim();

            if (cmbEstatus.SelectedItem != null)
                estatus = cmbEstatus.SelectedItem.ToString() == "Activo" ? 1 : 0;

            if (string.IsNullOrEmpty(categoria)) categoria = null;
            if (string.IsNullOrEmpty(ubicacion)) ubicacion = null;
            if (string.IsNullOrEmpty(claveFiltro)) claveFiltro = null;

            CargarProductosEnGrid(categoria, estatus, ubicacion, claveFiltro);
        }

        private void btnReiniciarF_Click(object sender, EventArgs e)
        {
            cmbCat.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;
            txtClave.Clear();

            CargarProductosEnGrid(null, null, null, null);
        }

        private async void btResVentas_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_resumenAbierto)
            {
                MessageBox.Show("La ventana de resumen ya está abierta o en proceso de abrirse.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _resumenAbierto = true;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var frmResumen = new frmRepAPI();
                await frmResumen.CargarResumenVentasAsync(_productoSeleccionado.Clave);

                Cursor.Current = Cursors.Default;

                // Mostrar el formulario fuera del try para que el cursor vuelva a default inmediatamente
                frmResumen.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el resumen de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _resumenAbierto = false;
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
