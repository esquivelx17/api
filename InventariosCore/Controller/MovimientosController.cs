using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class MovimientosController
    {
        private readonly MovimientosDataAccess _movimientosDA;

        public MovimientosController()
        {
            _movimientosDA = new MovimientosDataAccess();
        }

        public int InsertarMovimiento(Movimiento movimiento)
        {
            return _movimientosDA.InsertarMovimiento(movimiento);
        }

        public bool ActualizarMovimiento(Movimiento movimiento)
        {
            return _movimientosDA.ActualizarMovimiento(movimiento);
        }

        public bool EliminarMovimiento(int idMovimiento)
        {
            return _movimientosDA.EliminarMovimiento(idMovimiento);
        }

        public Movimiento? ObtenerMovimientoPorId(int idMovimiento)
        {
            return _movimientosDA.ObtenerMovimientoPorId(idMovimiento);
        }

        public List<Movimiento> ObtenerTodosLosMovimientos()
        {
            return _movimientosDA.ObtenerTodosLosMovimientos();
        }

        public List<Movimiento> ObtenerMovimientosPorEstatus(int estatus)
        {
            return _movimientosDA.ObtenerMovimientosPorEstatus(estatus);
        }

        public List<Movimiento> ObtenerMovimientosPorTipo(string tipo)
        {
            return _movimientosDA.ObtenerMovimientosPorTipo(tipo);
        }

        public List<Movimiento> ObtenerMovimientosPorOperador(int idOperador)
        {
            return _movimientosDA.ObtenerMovimientosPorOperador(idOperador);
        }

        public List<Movimiento> ObtenerMovimientosPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _movimientosDA.ObtenerMovimientosPorRangoFechas(fechaInicio, fechaFin);
        }

        public bool CambiarEstatusMovimiento(int idMovimiento, int nuevoEstatus)
        {
            return _movimientosDA.CambiarEstatusMovimiento(idMovimiento, nuevoEstatus);
        }
    }
}
