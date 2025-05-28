using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class MovimientoProductoController
    {
        private readonly MovimientoProductoDataAccess _movProdDA;

        public MovimientoProductoController()
        {
            _movProdDA = new MovimientoProductoDataAccess();
        }

        public int InsertarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            return _movProdDA.InsertarMovimientoProducto(movimientoProducto);
        }

        public bool ActualizarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            return _movProdDA.ActualizarMovimientoProducto(movimientoProducto);
        }

        public List<MovimientoProducto> ObtenerTodosLosMovimientosProductos()
        {
            return _movProdDA.ObtenerTodos();
        }
    }
}
