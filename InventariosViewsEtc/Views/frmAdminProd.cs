using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InventariosCore.Model;
using InventariosCore.Controllers;
using InventariosCore.Business;
using ClosedXML.Excel;
using InvSis.Views.UtilitiesForms;

namespace InvSis
{
    public partial class frmAdminProd : Form
    {
        private readonly ProductosController _controller = new ProductosController();
        private List<Producto> _productosCache = new List<Producto>();
        private Producto? _productoSeleccionado = null;
        private bool _modoEdicion = false;

        public frmAdminProd()
        {
            InitializeComponent();

            spcProductos.Panel2Collapsed = true;

            cmbxCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxUbi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxImpuesto.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;

            ConfigurarColumnasDGV();

            CargarFiltros();
            CargarProductosEnGrid();

            dgvProductos.ClearSelection();

            spcProductos.Panel2Collapsed = true;
            spcProductos.Panel1.Enabled = true;

            SeguridadUI.BloquearBotonesSiEsLector(btnGuardar, btnEdittemp, btnExportar);
        }

        private void ConfigurarColumnasDGV()
        {
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 140,
                Name = "colNombre"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Width = 140,
                Name = "colCategoria"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Costo",
                HeaderText = "Costo unitario",
                Width = 90,
                Name = "colCosto",
                DefaultCellStyle = { Format = "C2" }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 60,
                Name = "colStock"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ubicacion",
                HeaderText = "Ubicación",
                Width = 120,
                Name = "colUbicacion"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                Width = 100,
                Name = "colImpuesto"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Clave",
                HeaderText = "Clave",
                Width = 120,
                Name = "colClave"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estatus",
                Width = 90,
                Name = "colEstatus"
            });
        }

        private void CargarFiltros()
        {
            cmbCat.Items.Clear();
            cmbUbi.Items.Clear();
            cmbEstatus.Items.Clear();

            var productos = _controller.ObtenerProductos(null, null);
            var categorias = new HashSet<string>();
            var ubicaciones = new HashSet<string>();
            foreach (var p in productos)
            {
                if (!string.IsNullOrEmpty(p.Categoria))
                    categorias.Add(p.Categoria);
                if (!string.IsNullOrEmpty(p.Ubicacion))
                    ubicaciones.Add(p.Ubicacion);
            }

            cmbCat.Items.AddRange(categorias.ToArray());
            cmbUbi.Items.AddRange(ubicaciones.ToArray());

            cmbEstatus.Items.Add("Activo");
            cmbEstatus.Items.Add("Inactivo");

            cmbCat.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;
        }

        private void CargarProductosEnGrid(string? categoria = null, int? estatus = null, string? ubicacion = null)
        {
            var productos = _controller.ObtenerProductos(categoria, estatus);

            if (!string.IsNullOrEmpty(ubicacion))
                productos = productos.FindAll(p => p.Ubicacion == ubicacion);

            _productosCache = productos;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;

            var productosStockBajo = _controller.ObtenerProductosConStockBajo();
            var idsStockBajo = new HashSet<int>(productosStockBajo.ConvertAll(p => p.IdProducto));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    // Aquí asignamos el nombre del impuesto o "No Aplica"
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
            _modoEdicion = false;
            spcProductos.Panel2Collapsed = true;
            spcProductos.Panel1.Enabled = true;

            if (productosStockBajo.Count > 0)
            {
                MessageBox.Show(
                    $"Hay {productosStockBajo.Count} producto(s) con menos de la existencia mínima.",
                    "Alerta de Stock Bajo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
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

        private void btnApF_Click_1(object sender, EventArgs e)
        {
            string? categoria = cmbCat.SelectedItem?.ToString();
            int? estatus = null;
            string? ubicacion = cmbUbi.SelectedItem?.ToString();

            if (cmbEstatus.SelectedItem != null)
                estatus = cmbEstatus.SelectedItem.ToString() == "Activo" ? 1 : 0;

            if (string.IsNullOrEmpty(categoria)) categoria = null;
            if (string.IsNullOrEmpty(ubicacion)) ubicacion = null;

            CargarProductosEnGrid(categoria, estatus, ubicacion);
        }

        private void btnReiniciarF_Click(object sender, EventArgs e)
        {
            cmbCat.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;

            CargarProductosEnGrid(null, null, null);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _productoSeleccionado = null;
            ReiniciarCampos();
            spcProductos.Panel2Collapsed = false;
            spcProductos.Panel1.Enabled = false;
            txtClave.ReadOnly = false;
        }

        private void btnEdittemp_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un producto para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarProductoEnFormulario(_productoSeleccionado);
            _modoEdicion = true;
            spcProductos.Panel2Collapsed = false;
            spcProductos.Panel1.Enabled = false;
            txtClave.ReadOnly = true;
        }

        private void CargarProductoEnFormulario(Producto p)
        {
            txtNombre.Text = p.Nombre;
            txtClave.Text = p.Clave;
            txtCosto.Text = p.Costo.ToString("F2");
            nmupdnStock.Value = p.Stock ?? 0;
            cmbxCat.SelectedItem = p.Categoria;
            cmbxUbi.SelectedItem = p.Ubicacion;
            cmbxStatus.SelectedItem = p.Estatus == 1 ? "Activo" : "Inactivo";
            cmbxImpuesto.SelectedItem = p.Impuesto?.TipoImpuesto ?? "No Aplica";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ClaveProducto.ValidarCodigoProducto(txtClave.Text))
                {
                    MessageBox.Show("La clave no es válida.", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El campo de nombre no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCosto.Text) || !decimal.TryParse(txtCosto.Text.Replace("$", ""), out decimal costo))
                {
                    MessageBox.Show("El campo de costo no es válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prod = new Producto
                {
                    IdProducto = _productoSeleccionado?.IdProducto ?? 0,
                    Nombre = txtNombre.Text,
                    Clave = txtClave.Text,
                    Costo = costo,
                    Stock = (int)nmupdnStock.Value,
                    Categoria = cmbxCat.SelectedItem?.ToString() ?? "",
                    Ubicacion = cmbxUbi.SelectedItem?.ToString() ?? "",
                    Estatus = cmbxStatus.SelectedItem?.ToString() == "Activo" ? 1 : 0,
                    AplicaImpuesto = cmbxImpuesto.SelectedItem?.ToString() != "No Aplica",
                    IdImpuesto = null // Debes asignar el IdImpuesto correcto según tu lógica
                };

                if (_modoEdicion)
                {
                    bool actualizado = _controller.ActualizarProducto(prod);
                    if (actualizado)
                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int nuevoId = _controller.InsertarProducto(prod);
                    MessageBox.Show($"Producto agregado con ID {nuevoId}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                spcProductos.Panel2Collapsed = true;
                spcProductos.Panel1.Enabled = true;
                ReiniciarCampos();
                CargarProductosEnGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            spcProductos.Panel2Collapsed = true;
            spcProductos.Panel1.Enabled = true;
            ReiniciarCampos();
        }

        private void ReiniciarCampos()
        {
            txtClave.Text = "";
            txtNombre.Text = "";
            txtCosto.Text = "";
            nmupdnStock.Value = 0;
            cmbxCat.SelectedIndex = -1;
            cmbxUbi.SelectedIndex = -1;
            cmbxStatus.SelectedIndex = -1;
            cmbxImpuesto.SelectedIndex = -1;
            _productoSeleccionado = null;
            _modoEdicion = false;
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función pendiente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApF_Click(object sender, EventArgs e)
        {
            // Aplica el filtro usando los valores seleccionados
            string? categoria = cmbCat.SelectedItem?.ToString();
            int? estatus = null;
            string? ubicacion = cmbUbi.SelectedItem?.ToString();

            if (cmbEstatus.SelectedItem != null)
                estatus = cmbEstatus.SelectedItem.ToString() == "Activo" ? 1 : 0;

            if (string.IsNullOrEmpty(categoria)) categoria = null;
            if (string.IsNullOrEmpty(ubicacion)) ubicacion = null;

            CargarProductosEnGrid(categoria, estatus, ubicacion);
        }

        private void btnReiniciarF_Click_1(object sender, EventArgs e)
        {
            // Limpia los filtros y recarga todos los productos
            cmbCat.SelectedIndex = -1;
            cmbUbi.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;

            CargarProductosEnGrid(null, null, null);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _productoSeleccionado = null;
            ReiniciarCampos();
            spcProductos.Panel2Collapsed = false;
            spcProductos.Panel1.Enabled = false;
            txtClave.ReadOnly = false;
        }

        private void btnCarga_Click_1(object sender, EventArgs e)
        {
            // Función pendiente de implementación para carga desde Excel
            MessageBox.Show("Función pendiente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Llama al btnGuardar_Click_1 que ya tiene la lógica implementada para guardar
            btnGuardar_Click_1(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            spcProductos.Panel2Collapsed = true;
            spcProductos.Panel1.Enabled = true;
            ReiniciarCampos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarExel.ExportarDataGridViewToExcel(dgvProductos);
        }

        
    }
}
