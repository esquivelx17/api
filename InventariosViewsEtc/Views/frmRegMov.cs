using System;
using System.Windows.Forms;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmRegMov : Form
    {
        private MovimientosController movimientosController;
        private MovimientoProductoController movimientoProductoController;
        private ProductosController productosController;
        private int? idMovimientoActual = null;

        public frmRegMov()
        {
            InitializeComponent();

            movimientosController = new MovimientosController();
            movimientoProductoController = new MovimientoProductoController();
            productosController = new ProductosController();

            ConfigurarDgvRegMovProductos();
            ConfigurarDgvSeleccion();
            ConfigurarDgvOperadores();

            CargarProductos();
            CargarOperadores();
            CargarMovimientos();

            cmbTipoMov.SelectedIndex = 0;
            cmbEstatus.SelectedIndex = 0;
            dtpFecha.MaxDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            dgvSeleccion.SelectionChanged += dgvSeleccion_SelectionChanged;
        }

        private void ConfigurarDgvRegMovProductos()
        {
            dgvRegMov.AllowUserToAddRows = false;
            dgvRegMov.AllowUserToDeleteRows = false;
            dgvRegMov.ReadOnly = true;
            dgvRegMov.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegMov.MultiSelect = false;
            dgvRegMov.AutoGenerateColumns = false;
            dgvRegMov.Columns.Clear();

            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Width = 140 });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoría", Width = 140 });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Costo", HeaderText = "Costo Unitario", Width = 90, DefaultCellStyle = { Format = "C2" } });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Stock", Width = 60 });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ubicacion", HeaderText = "Ubicación", Width = 120 });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Impuesto", Width = 100, Name = "colImpuesto" });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Clave", HeaderText = "Clave", Width = 120 });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estatus", Width = 90, Name = "colEstatus" });
        }

        private void CargarProductos()
        {
            var productos = productosController.ObtenerProductosActivos();
            dgvRegMov.DataSource = null;
            dgvRegMov.DataSource = productos;

            foreach (DataGridViewRow row in dgvRegMov.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    row.Cells["colImpuesto"].Value = p.Impuesto?.TipoImpuesto ?? "No Aplica";
                    row.Cells["Estatus"].Value = p.Estatus == 1 ? "Activo" : "Inactivo";
                }
            }
        }

        private void ConfigurarDgvSeleccion()
        {
            dgvSeleccion.Columns.Clear();
            dgvSeleccion.Columns.Add("IdMovimiento", "ID");
            dgvSeleccion.Columns["IdMovimiento"].Visible = false;
            dgvSeleccion.Columns.Add("Tipo", "Tipo Movimiento");
            dgvSeleccion.Columns.Add("Fecha", "Fecha");
            dgvSeleccion.Columns.Add("Operador", "Operador");
            dgvSeleccion.Columns.Add("Estatus", "Estatus");

            dgvSeleccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeleccion.MultiSelect = false;
            dgvSeleccion.ReadOnly = true;
        }

        private void CargarMovimientos()
        {
            var movimientos = movimientosController.ObtenerTodosLosMovimientos();
            dgvSeleccion.Rows.Clear();
            foreach (var mov in movimientos)
            {
                dgvSeleccion.Rows.Add(mov.IdMovimiento, mov.Tipo, mov.Fecha.ToShortDateString(), mov.Operador, EstatusTexto(mov.Estatus));
            }
        }

        private string EstatusTexto(int estatus) => estatus switch
        {
            1 => "Pendiente",
            2 => "Aprobado",
            3 => "Revisado",
            4 => "Rechazado",
            _ => "Desconocido"
        };

        private void ConfigurarDgvOperadores()
        {
            dgvOperadores.Columns.Clear();
            dgvOperadores.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdUsuario", HeaderText = "ID", Visible = false });
            dgvOperadores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nickname", HeaderText = "Operador", Width = 150 });
            dgvOperadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperadores.MultiSelect = false;
            dgvOperadores.ReadOnly = true;
        }

        private void CargarOperadores()
        {
            var usuarios = new UsuariosController().ObtenerUsuariosOperadores();
            dgvOperadores.Rows.Clear();
            foreach (var u in usuarios)
            {
                dgvOperadores.Rows.Add(u.IdUsuario, u.Nickname);
            }
        }

        private void dgvSeleccion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeleccion.SelectedRows.Count == 0) return;
            var fila = dgvSeleccion.SelectedRows[0];
            idMovimientoActual = Convert.ToInt32(fila.Cells["IdMovimiento"].Value);

            var mov = movimientosController.ObtenerMovimientoPorId(idMovimientoActual.Value);
            if (mov == null) return;

            cmbTipoMov.SelectedItem = mov.Tipo;
            dtpFecha.Value = mov.Fecha;
            cmbEstatus.SelectedIndex = mov.Estatus - 1;

            foreach (DataGridViewRow row in dgvOperadores.Rows)
            {
                if ((int)row.Cells["IdUsuario"].Value == mov.IdOperador)
                {
                    row.Selected = true;
                    dgvOperadores.CurrentCell = row.Cells[1];
                    break;
                }
            }

            btnGuardar.Text = "Actualizar Movimiento";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvRegMov.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvOperadores.SelectedRows.Count == 0)
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

            if (idMovimientoActual == null)
            {
                GuardarMovimiento(cantidad);
            }
            else
            {
                ActualizarMovimiento(cantidad);
            }
        }

        private void GuardarMovimiento(int cantidad)
        {
            var producto = dgvRegMov.CurrentRow.DataBoundItem as Producto;
            int operadorId = (int)dgvOperadores.SelectedRows[0].Cells["IdUsuario"].Value;

            var movimiento = new Movimiento
            {
                Tipo = cmbTipoMov.SelectedItem?.ToString(),
                Estatus = cmbEstatus.SelectedIndex + 1,
                Fecha = dtpFecha.Value,
                IdOperador = operadorId
            };

            int idMov = movimientosController.InsertarMovimiento(movimiento);
            if (idMov <= 0)
            {
                MessageBox.Show("Error al guardar movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movProd = new MovimientoProducto
            {
                IdMovimiento = idMov,
                IdProducto = producto.IdProducto,
                Cantidad = cantidad,
                Fecha = movimiento.Fecha
            };

            int idMovProd = movimientoProductoController.InsertarMovimientoProducto(movProd);
            if (idMovProd <= 0)
            {
                MessageBox.Show("Error al guardar movimiento-producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            producto.Stock = (producto.Stock ?? 0) + cantidad;
            productosController.ActualizarProducto(producto);

            MessageBox.Show("Movimiento guardado y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProductos();
            CargarMovimientos();
            LimpiarFormulario();
        }

        private void ActualizarMovimiento(int cantidad)
        {
            var producto = dgvRegMov.CurrentRow.DataBoundItem as Producto;
            int operadorId = (int)dgvOperadores.SelectedRows[0].Cells["IdUsuario"].Value;

            var movimiento = new Movimiento
            {
                IdMovimiento = idMovimientoActual.Value,
                Tipo = cmbTipoMov.SelectedItem?.ToString(),
                Estatus = cmbEstatus.SelectedIndex + 1,
                Fecha = dtpFecha.Value,
                IdOperador = operadorId
            };

            if (!movimientosController.ActualizarMovimiento(movimiento))
            {
                MessageBox.Show("Error al actualizar movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movProd = new MovimientoProducto
            {
                IdMovimiento = movimiento.IdMovimiento,
                IdProducto = producto.IdProducto,
                Cantidad = cantidad,
                Fecha = movimiento.Fecha
            };

            if (!movimientoProductoController.ActualizarMovimientoProducto(movProd))
            {
                MessageBox.Show("Error al actualizar movimiento-producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            producto.Stock = (producto.Stock ?? 0) + cantidad;
            productosController.ActualizarProducto(producto);

            MessageBox.Show("Movimiento actualizado y stock ajustado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProductos();
            CargarMovimientos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbTipoMov.SelectedIndex = 0;
            cmbEstatus.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            nudCantidad.Value = 1;
            dgvRegMov.ClearSelection();
            dgvOperadores.ClearSelection();
            dgvSeleccion.ClearSelection();
            idMovimientoActual = null;
            btnGuardar.Text = "Guardar Movimiento";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
