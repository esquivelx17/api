using InventariosCore.Controllers;
using InventariosCore.Model;
using InventariosCore.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvSis.Views
{
    public partial class frmRepAPI : Form
    {
        private readonly ApiService _apiService = new ApiService();
        private readonly ProductosController _productosController = new ProductosController();

        public frmRepAPI()
        {
            InitializeComponent();
            dgvResumenVentas.AutoGenerateColumns = false;
            AjustarColumnasDataPropertyNames();
        }

        private void AjustarColumnasDataPropertyNames()
        {
            colClaveProducto.DataPropertyName = nameof(Venta.CodigoArticulo); 
            colIdCompra.DataPropertyName = nameof(Venta.IdCompra);
            colCodigoCompra.DataPropertyName = nameof(Venta.CodigoCompra);
            colFecha.DataPropertyName = nameof(Venta.FechaCompra);
            colCliente.DataPropertyName = nameof(Venta.Cliente);
            colCantidad.DataPropertyName = nameof(Venta.Cantidad);
            colCosto.DataPropertyName = nameof(Venta.Costo);
            colEstatus.DataPropertyName = nameof(Venta.Estatus);
        }

        public async Task CargarResumenVentasAsync(string claveProducto)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ResumenVenta? resumen = await _apiService.GetResumenVentasPorProductoAsync(claveProducto);
                if (resumen == null || resumen.TotalVentas == 0)
                {
                    MessageBox.Show("No hay ventas para mostrar para este producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvResumenVentas.DataSource = null;
                }
                else
                {
                    foreach (var venta in resumen.Ventas)
                    {
                        venta.CodigoArticulo = resumen.CodigoArticulo;
                    }

                    dgvResumenVentas.DataSource = null;
                    dgvResumenVentas.DataSource = resumen.Ventas;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar resumen de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;  // Vuelve al cursor normal
            }
        }

        
    }
}
