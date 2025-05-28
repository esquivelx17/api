using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class MovimientoProductoController
    {
        private readonly MovimientoProductoDataAccess _movProdDA;
        private readonly AuditoriaService _auditoriaService;

        public MovimientoProductoController()
        {
            _movProdDA = new MovimientoProductoDataAccess();
            _auditoriaService = new AuditoriaService();
        }

        public int InsertarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            int id = _movProdDA.InsertarMovimientoProducto(movimientoProducto);
            if (id > 0)
            {
                _auditoriaService.RegistrarAccion("Inserción", "Movimientos_Productos");
            }
            return id;
        }

        public bool ActualizarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            bool exito = _movProdDA.ActualizarMovimientoProducto(movimientoProducto);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Actualización", "Movimientos_Productos");
            }
            return exito;
        }

        public bool EliminarMovimientoProducto(int idMovimientoProducto)
        {
            bool exito = _movProdDA.EliminarMovimientoProducto(idMovimientoProducto);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Eliminación", "Movimientos_Productos");
            }
            return exito;
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
            bool exito = _movProdDA.ActualizarCantidadMovimientoProducto(idMovimientoProducto, nuevaCantidad);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Actualización cantidad", "Movimientos_Productos");
            }
            return exito;
        }

        public int ObtenerTotalCantidadPorProducto(int idProducto)
        {
            return _movProdDA.ObtenerTotalCantidadPorProducto(idProducto);
        }
    }
}
