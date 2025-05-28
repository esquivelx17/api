using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;
using InventariosCore.Controllers;

namespace InventariosCore.Controllers
{
    public class MovimientoProductoController
    {
        private readonly MovimientoProductoDataAccess _movProdDA;
        private readonly ProductosController _productosController;  // nuevo

        public MovimientoProductoController()
        {
            _movProdDA = new MovimientoProductoDataAccess();
            _productosController = new ProductosController();  // inicializa
        }

        public int InsertarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            return _movProdDA.InsertarMovimientoProducto(movimientoProducto);
        }

        public bool ActualizarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            return _movProdDA.ActualizarMovimientoProducto(movimientoProducto);
        }

        public List<Producto> ObtenerProductosConStockBajo()
        {
            return _productosController.ObtenerProductosConStockBajo();
        }

        public List<MovimientoProducto> ObtenerTodosLosMovimientosProductos()
        {
            return _movProdDA.ObtenerTodos();
        }
    }
}
