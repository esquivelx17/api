using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmRegMov : Form
    {
        private readonly MovimientoProductoController movimientoProductoController;
        private readonly ProductosController productosController;
        private readonly UsuariosController usuariosController;

        private int? idMovimientoProductoActual = null;  // IdMovimientoProducto que es PK en la tabla movimientos_productos

        public frmRegMov()
        {
            InitializeComponent();

            movimientoProductoController = new MovimientoProductoController();
            productosController = new ProductosController();
            usuariosController = new UsuariosController();

            ConfigurarDgvProductos();
            ConfigurarDgvOperadores();
            ConfigurarDgvMovimientos();

            CargarProductos();
            CargarOperadores();
            CargarMovimientos();

            cmbEstatus.SelectedIndex = 0; // Pendiente (índice 0) por defecto
            dtpFecha.MaxDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            dgvSeleccionUsuario.ClearSelection();
            dgvProductos.ClearSelection();
            dtgRegMov.ClearSelection();

            dtgRegMov.SelectionChanged += DtRegMov_SelectionChanged;
        }

        private void ConfigurarDgvProductos()
        {
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;

            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("Costo", "Costo Unitario");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Ubicacion", "Ubicación");
            dgvProductos.Columns.Add("Impuesto", "Impuesto");
            dgvProductos.Columns.Add("Clave", "Clave");
            dgvProductos.Columns.Add("Estatus", "Estatus");
        }

        private void ConfigurarDgvOperadores()
        {
            dgvSeleccionUsuario.AllowUserToAddRows = false;
            dgvSeleccionUsuario.AllowUserToDeleteRows = false;
            dgvSeleccionUsuario.ReadOnly = true;
            dgvSeleccionUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeleccionUsuario.MultiSelect = false;

            dgvSeleccionUsuario.Columns.Clear();
            dgvSeleccionUsuario.Columns.Add("IdUsuario", "ID");
            dgvSeleccionUsuario.Columns["IdUsuario"].Visible = false;
            dgvSeleccionUsuario.Columns.Add("Nickname", "Operador");
            dgvSeleccionUsuario.Columns.Add("Persona", "Persona");
        }

        private void ConfigurarDgvMovimientos()
        {
            dtgRegMov.AllowUserToAddRows = false;
            dtgRegMov.AllowUserToDeleteRows = false;
            dtgRegMov.ReadOnly = true;
            dtgRegMov.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgRegMov.MultiSelect = false;

            dtgRegMov.Columns.Clear();
            dtgRegMov.Columns.Add("Producto", "Producto");
            dtgRegMov.Columns.Add("Operador", "Operador");
            dtgRegMov.Columns.Add("Estatus", "Estatus");
            dtgRegMov.Columns.Add("Fecha", "Fecha");
            dtgRegMov.Columns.Add("Cantidad", "Cantidad");
        }

        private void CargarProductos()
        {
            var productos = productosController.ObtenerProductos();

            dgvProductos.Rows.Clear();
            foreach (var p in productos)
            {
                dgvProductos.Rows.Add(
                    p.Nombre,
                    p.Categoria,
                    p.Costo.ToString("C2"),
                    p.Stock?.ToString() ?? "0",
                    p.Ubicacion,
                    p.Impuesto?.TipoImpuesto ?? "No Aplica",
                    p.Clave,
                    p.Estatus == 1 ? "Activo" : "Inactivo"
                );
            }
        }

        private void CargarOperadores()
        {
            var operadores = usuariosController.ObtenerUsuariosOperadores();

            dgvSeleccionUsuario.Rows.Clear();
            foreach (var u in operadores)
            {
                string personaNombre = u.Persona?.NombreCompleto ?? "Desconocido";
                dgvSeleccionUsuario.Rows.Add(u.IdUsuario, u.Nickname, personaNombre);
            }
        }

        private void CargarMovimientos()
        {
            var movimientosProductos = movimientoProductoController.ObtenerTodosLosMovimientosProductos();

            dtgRegMov.Rows.Clear();
            foreach (var movProd in movimientosProductos)
            {
                string operadorNickname = movProd.Operador?.Nickname ?? "Desconocido";
                string estatusTexto = movProd.Estatus switch
                {
                    0 => "Rechazado",
                    1 => "Aprobado",
                    2 => "Pendiente",
                    _ => "Desconocido"
                };

                dtgRegMov.Rows.Add(
                    movProd.Producto?.Nombre ?? "Desconocido",
                    operadorNickname,
                    estatusTexto,
                    movProd.Fecha.ToShortDateString(),
                    movProd.Cantidad
                );
            }
        }

        private void DtRegMov_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgRegMov.SelectedRows.Count == 0)
            {
                LimpiarFormulario();
                return;
            }

            var fila = dtgRegMov.SelectedRows[0];

            string productoNombre = fila.Cells["Producto"].Value?.ToString() ?? "";
            string operadorNickname = fila.Cells["Operador"].Value?.ToString() ?? "";
            string estatusTexto = fila.Cells["Estatus"].Value?.ToString() ?? "";
            string fechaStr = fila.Cells["Fecha"].Value?.ToString() ?? "";
            string cantidadStr = fila.Cells["Cantidad"].Value?.ToString() ?? "";

            var movimientosProductos = movimientoProductoController.ObtenerTodosLosMovimientosProductos();

            var seleccionado = movimientosProductos.FirstOrDefault(mp =>
                mp.Producto?.Nombre == productoNombre &&
                mp.Operador?.Nickname == operadorNickname &&
                mp.Fecha.ToShortDateString() == fechaStr &&
                mp.Cantidad.ToString() == cantidadStr
            );

            if (seleccionado == null)
            {
                LimpiarFormulario();
                return;
            }

            idMovimientoProductoActual = seleccionado.IdMovimientoProducto;

            SeleccionarProductoEnGrid(productoNombre);
            SeleccionarOperadorEnGrid(operadorNickname);

            cmbEstatus.SelectedIndex = seleccionado.Estatus switch
            {
                2 => 0, // Pendiente
                1 => 1, // Aprobado
                0 => 2, // Rechazado
                _ => 0
            };

            if (DateTime.TryParse(fechaStr, out var fecha))
                dtpFecha.Value = fecha;

            nudCantidad.Value = seleccionado.Cantidad;

            btnGuardar.Text = "Actualizar Movimiento";
        }

        private void SeleccionarProductoEnGrid(string nombre)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Nombre"].Value?.ToString() == nombre)
                {
                    row.Selected = true;
                    dgvProductos.CurrentCell = row.Cells[0];
                    return;
                }
            }
            dgvProductos.ClearSelection();
        }

        private void SeleccionarOperadorEnGrid(string nickname)
        {
            foreach (DataGridViewRow row in dgvSeleccionUsuario.Rows)
            {
                if (row.Cells["Nickname"].Value?.ToString() == nickname)
                {
                    row.Selected = true;
                    dgvSeleccionUsuario.CurrentCell = row.Cells[1];
                    return;
                }
            }
            dgvSeleccionUsuario.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSeleccionUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un operador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoClave = dgvProductos.CurrentRow.Cells["Clave"].Value?.ToString() ?? string.Empty;
            var producto = productosController.ObtenerProductoPorClave(productoClave);

            if (producto == null)
            {
                MessageBox.Show("Producto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int operadorId = (int)dgvSeleccionUsuario.SelectedRows[0].Cells["IdUsuario"].Value;

            short estatus = cmbEstatus.SelectedIndex switch
            {
                0 => 2, // Pendiente
                1 => 1, // Aprobado
                2 => 0, // Rechazado
                _ => 2
            };

            var movimientoProducto = new MovimientoProducto
            {
                IdProducto = producto.IdProducto,
                IdOperador = operadorId,
                Cantidad = cantidad,
                Fecha = dtpFecha.Value.Date,
                Estatus = estatus,
                Producto = producto,
                Operador = usuariosController.ObtenerUsuarioPorId(operadorId) ?? new Usuario()
            };

            if (idMovimientoProductoActual == null)
            {
                int idNuevo = movimientoProductoController.InsertarMovimientoProducto(movimientoProducto);
                if (idNuevo <= 0)
                {
                    MessageBox.Show("Error al guardar movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                idMovimientoProductoActual = idNuevo;

                if (estatus == 1) // Solo si está aprobado actualiza stock
                {
                    producto.Stock = (producto.Stock ?? 0) + cantidad;
                    productosController.ActualizarProducto(producto);
                }

                MessageBox.Show("Movimiento guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                movimientoProducto.IdMovimientoProducto = idMovimientoProductoActual.Value;

                if (!movimientoProductoController.ActualizarMovimientoProducto(movimientoProducto))
                {
                    MessageBox.Show("Error al actualizar movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (estatus == 1)
                {
                    producto.Stock = (producto.Stock ?? 0) + cantidad;
                    productosController.ActualizarProducto(producto);
                }

                MessageBox.Show("Movimiento actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarProductos();
            CargarMovimientos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idMovimientoProductoActual = null;
            cmbEstatus.SelectedIndex = 0; // Pendiente
            dtpFecha.Value = DateTime.Today;
            nudCantidad.Value = 1;
            dgvProductos.ClearSelection();
            dgvSeleccionUsuario.ClearSelection();
            dtgRegMov.ClearSelection();
            btnGuardar.Text = "Guardar Movimiento";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            btnCancelar_Click(sender, e);
        }
    }
}
