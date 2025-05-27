using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class AuditoriaController
    {
        private readonly BitacoraDataAccess _bitacoraDA;

        public AuditoriaController()
        {
            _bitacoraDA = new BitacoraDataAccess();
        }

        /// <summary>
        /// Obtiene auditorías con filtros opcionales
        /// </summary>
        public List<Bitacora> ObtenerAuditorias(DateTime? fechaInicio = null, DateTime? fechaFin = null, string? tipoMovimiento = null, string? tablaAfectada = null)
        {
            return _bitacoraDA.ObtenerRegistrosPorFiltros(fechaInicio, fechaFin, tipoMovimiento, tablaAfectada);
        }

        /// <summary>
        /// Obtiene todas las auditorías sin filtro
        /// </summary>
        public List<Bitacora> ObtenerTodasLasAuditorias()
        {
            return _bitacoraDA.ObtenerTodosLosRegistrosBitacora();
        }

        /// <summary>
        /// Obtiene una auditoría por su ID
        /// </summary>
        public Bitacora? ObtenerAuditoriaPorId(int idAuditoria)
        {
            return _bitacoraDA.ObtenerRegistroBitacoraPorId(idAuditoria);
        }

        /// <summary>
        /// Registra una nueva auditoría
        /// </summary>
        public int RegistrarAuditoria(Bitacora bitacora)
        {
            if (bitacora == null)
                throw new ArgumentNullException(nameof(bitacora));

            return _bitacoraDA.InsertarRegistroBitacora(bitacora);
        }
    }
}
