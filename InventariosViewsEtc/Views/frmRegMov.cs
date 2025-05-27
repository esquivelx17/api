using InventariosCore.Business;
using InventariosCore.Controllers;
using InventariosCore.Model;
using System.Text;

namespace InvSis.Views
{
    public partial class frmRegMov : Form
    {
        private MovimientosController movimientosController;
        private MovimientoProductoController movimientoProductoController;
        private ProductosController productosController;
        private readonly ProductosController _controller = new ProductosController();
        private List<Producto> _productosCache = new List<Producto>();



        public frmRegMov()
        {
            InitializeComponent();

            movimientosController = new MovimientosController();
            movimientoProductoController = new MovimientoProductoController();
            productosController = new ProductosController();

            ConfigurarColumnasProductos();
            CargarProductos();
            PoblarComboOperador();
            ConfigurarDgvRegMovProductos();

            CargarProductosEnGridRegMov();

            cmbEstatus.SelectedIndex = 0;
            dtpFecha.MaxDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
        }

        private void frmRegMov_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasProductos();
            CargarProductos();
            PoblarComboOperador();
            var controller = new ProductosController();
            var productos = controller.ObtenerProductosActivos();
            /*
            var productosBajoStock = productos
                .Where(p => p.Stock.HasValue && p.Stock.Value < ProductosNegocio.UmbralStockBajo)
                .ToList(); 

            if (productosBajoStock.Any())
            {
                StringBuilder sb = new();
                sb.AppendLine("Atención: Los siguientes productos tienen un stock bajo:");

                foreach (var p in productosBajoStock)
                {
                    sb.AppendLine($"• {p.Nombre} (Stock actual: {p.Stock})");
                }

                MessageBox.Show(sb.ToString(), "Stock bajo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }



        // ... Métodos anteriores ...
        private void ConfigurarDgvRegMovProductos()
        {
            // Configuración básica
            dgvRegMov.AllowUserToAddRows = false;
            dgvRegMov.AllowUserToDeleteRows = false;
            dgvRegMov.AllowUserToResizeColumns = false;
            dgvRegMov.AllowUserToResizeRows = false;

            dgvRegMov.ReadOnly = true;
            dgvRegMov.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegMov.MultiSelect = false;
            dgvRegMov.RowHeadersVisible = false;
            dgvRegMov.AutoGenerateColumns = false;

            dgvRegMov.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvRegMov.Location = new System.Drawing.Point(470, 76);

            dgvRegMov.Size = new System.Drawing.Size(800, 300); // Ajusta el tamaño según te convenga


            // Estilos colores y fuentes
            dgvRegMov.BackgroundColor = System.Drawing.Color.FromArgb(42, 34, 58);

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = System.Drawing.Color.FromArgb(159, 122, 234),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.MediumPurple,
                SelectionBackColor = System.Drawing.SystemColors.Highlight,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };
            dgvRegMov.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvRegMov.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegMov.GridColor = System.Drawing.SystemColors.Info;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(250, 250, 250),
                SelectionBackColor = System.Drawing.Color.FromArgb(232, 218, 255),
                SelectionForeColor = System.Drawing.Color.MediumPurple,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };
            dgvRegMov.AlternatingRowsDefaultCellStyle = rowStyle;
            dgvRegMov.DefaultCellStyle = rowStyle;

            // Agregar columnas manualmente 
            dgvRegMov.Columns.Clear();

            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 140,
                Name = "colNombre"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Width = 140,
                Name = "colCategoria"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Costo",
                HeaderText = "Costo unitario",
                Width = 90,
                Name = "colCosto",
                DefaultCellStyle = { Format = "C2" }
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 60,
                Name = "colStock"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ubicacion",
                HeaderText = "Ubicación",
                Width = 120,
                Name = "colUbicacion"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                Width = 100,
                Name = "colImpuesto"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Clave",
                HeaderText = "Clave",
                Width = 120,
                Name = "colClave"
            });
            dgvRegMov.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estatus",
                Width = 90,
                Name = "colEstatus"
            });

            //this.Controls.Add(dgvRegMovProductos);
        }
        private void CargarProductosEnGridRegMov()
        {
            var productos = _controller.ObtenerProductos(null, null); // sin filtro

            _productosCache = productos;

            dgvRegMov.DataSource = null;
            dgvRegMov.DataSource = productos;

            foreach (DataGridViewRow row in dgvRegMov.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    row.Cells["colImpuesto"].Value = p.Impuesto?.TipoImpuesto ?? "No Aplica";
                    row.Cells["colEstatus"].Value = p.Estatus == 1 ? "Activo" : "Inactivo";
                }
            }
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            if (dgvRegMov.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para agregar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener producto seleccionado
            var productoSeleccionado = dgvRegMov.CurrentRow.DataBoundItem as Producto;
            if (productoSeleccionado == null)
                return;

            // Verificar si producto ya está en dgvSeleccion
            foreach (DataGridViewRow row in dgvSeleccion.Rows)
            {
                if (row.Cells["producto"].Value?.ToString() == productoSeleccionado.Nombre)
                {
                    MessageBox.Show("El producto ya está agregado en la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Agregar producto a dgvSeleccion
            dgvSeleccion.Rows.Add(productoSeleccionado.Nombre, cantidad, "Eliminar");
        }

        private void dgvSeleccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSeleccion.Columns["eliminar"].Index && e.RowIndex >= 0)
            {
                dgvSeleccion.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cmbTipoMov.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoMov.Focus();
                return;
            }
            if (cmbOpe.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un operador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOpe.Focus();
                return;
            }
            if (cmbEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estatus.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstatus.Focus();
                return;
            }
            if (dgvSeleccion.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear objeto movimiento
                var movimiento = new Movimiento
                {
                    Tipo = cmbTipoMov.SelectedItem.ToString(),
                    Estatus = cmbEstatus.SelectedIndex + 1, // Ajustar según cómo guardes el estatus
                    Fecha = dtpFecha.Value,
                    IdOperador = (int)cmbOpe.SelectedValue
                };

                int idMovimiento = movimientosController.InsertarMovimiento(movimiento);
                if (idMovimiento <= 0)
                {
                    MessageBox.Show("Error al guardar el movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar productos relacionados
                foreach (DataGridViewRow fila in dgvSeleccion.Rows)
                {
                    string nombreProducto = fila.Cells["producto"].Value.ToString();
                    int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);

                    string claveProducto = fila.Cells["clave"].Value.ToString(); // columna que contenga la clave
                    var producto = productosController.ObtenerProductoPorClave(claveProducto);

                    var movProd = new MovimientoProducto
                    {
                        IdMovimiento = idMovimiento,
                        IdProducto = producto.IdProducto,
                        Cantidad = cantidad,
                        Fecha = movimiento.Fecha
                    };

                    int idMovProd = movimientoProductoController.InsertarMovimientoProducto(movProd);
                    if (idMovProd <= 0)
                    {
                        MessageBox.Show($"Error al guardar producto '{nombreProducto}' en el movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Movimiento guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbTipoMov.SelectedIndex = 0;
            cmbOpe.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            dgvSeleccion.Rows.Clear();
        }

        private void ConfigurarColumnasProductos()
        {
            dgvRegMov.Columns.Clear();

            dgvRegMov.Columns.Add("Nombre", "Nombre");
            dgvRegMov.Columns.Add("Categoria", "Categoría");
            dgvRegMov.Columns.Add("Costo", "Costo Unitario");
            dgvRegMov.Columns.Add("Stock", "Stock");
            dgvRegMov.Columns.Add("Ubicacion", "Ubicación");
            dgvRegMov.Columns.Add("AplicaImpuesto", "Aplica Impuesto");
            dgvRegMov.Columns.Add("Clave", "Clave");
            dgvRegMov.Columns.Add("Estatus", "Estatus");
        }

        private void CargarProductos()
        {
            var listaProductos = productosController.ObtenerProductosActivos();
            /*
            // Verifica productos con stock bajo
            var productosConStockBajo = listaProductos
                .Where(p => (p.Stock ?? 0) < ProductosNegocio.UmbralStockBajo)
                .ToList();

            if (productosConStockBajo.Count > 0)
            {
                string mensaje = "⚠ Los siguientes productos tienen stock bajo:\n\n";
                mensaje += string.Join("\n", productosConStockBajo.Select(p =>
                    $"• {p.Nombre} (Stock: {p.Stock ?? 0})"));

                MessageBox.Show(mensaje, "Advertencia de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
            // Limpia columnas y datos
            dgvRegMov.Columns.Clear();
            dgvRegMov.Rows.Clear();

            // Crear columnas básicas
            dgvRegMov.Columns.Add("Nombre", "Nombre");
            dgvRegMov.Columns.Add("Categoria", "Categoría");
            dgvRegMov.Columns.Add("Costo", "Costo Unitario");
            dgvRegMov.Columns.Add("Stock", "Stock");
            dgvRegMov.Columns.Add("Ubicacion", "Ubicación");
            dgvRegMov.Columns.Add("Clave", "Clave");

            // Agrega filas con los datos de los productos
            foreach (var producto in listaProductos)
            {
                dgvRegMov.Rows.Add(
                    producto.Nombre,
                    producto.Categoria,
                    producto.Costo.ToString("C"),
                    producto.Stock.HasValue ? producto.Stock.Value.ToString() : "0",
                    producto.Ubicacion,
                    producto.Clave
                );
            }
        }


        private void PoblarComboOperador()
        {
            var usuariosController = new UsuariosController();
            var listaOperadores = usuariosController.ObtenerUsuariosOperadores();

            var listaParaCombo = listaOperadores.Select(u => new
            {
                u.IdUsuario,
                Display = $"Operador - {u.Nickname}"
            }).ToList();

            cmbOpe.DataSource = listaParaCombo;
            cmbOpe.DisplayMember = "Display";
            cmbOpe.ValueMember = "IdUsuario";
            cmbOpe.SelectedIndex = -1;
        }

        public Producto ObtenerProductoPorNombre(string nombre)
        {
            var productos = ObtenerProductosActivos();
            return productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        private List<Producto> ObtenerProductosActivos()
        {
            return productosController.ObtenerProductosActivos();
        }

        private void frmRegMov_Load_1(object sender, EventArgs e)
        {

        }
    }
}