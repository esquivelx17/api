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

        public bool EliminarMovimientoProducto(int idMovimientoProducto)
        {
            return _movProdDA.EliminarMovimientoProducto(idMovimientoProducto);
        }

        public MovimientoProducto? ObtenerMovimientoProductoPorId(int idMovimientoProducto)
        {
            return _movProdDA.ObtenerMovimientoProductoPorId(idMovimientoProducto);
        }

        public List<MovimientoProducto> ObtenerTodosLosMovimientosProductos()
        {
            return _movProdDA.ObtenerTodosLosMovimientosProductos();
        }

        public List<MovimientoProducto> ObtenerMovimientosProductosPorProducto(int idProducto)
        {
            return _movProdDA.ObtenerMovimientosProductosPorProducto(idProducto);
        }

        public List<MovimientoProducto> ObtenerMovimientosProductosPorMovimiento(int idMovimiento)
        {
            return _movProdDA.ObtenerMovimientosProductosPorMovimiento(idMovimiento);
        }

        public List<MovimientoProducto> ObtenerMovimientosProductosPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _movProdDA.ObtenerMovimientosProductosPorRangoFechas(fechaInicio, fechaFin);
        }

        public bool ActualizarCantidadMovimientoProducto(int idMovimientoProducto, int nuevaCantidad)
        {
            return _movProdDA.ActualizarCantidadMovimientoProducto(idMovimientoProducto, nuevaCantidad);
        }

        public int ObtenerTotalCantidadPorProducto(int idProducto)
        {
            return _movProdDA.ObtenerTotalCantidadPorProducto(idProducto);
        }
    }
}
