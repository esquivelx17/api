using System;

namespace InventariosCore.Model
{
    public class Bitacora
    {
        public int IdAuditoria { get; set; }

        public int IdUsuario { get; set; }

        public string IpEquipo { get; set; }

        public string NombreEquipo { get; set; }

        public DateTime Fecha { get; set; }

        public string TipoMovimiento { get; set; }

        public string TablaAfectada { get; set; }

        public Bitacora()
        {
            IpEquipo = string.Empty;
            NombreEquipo = string.Empty;
            Fecha = DateTime.Now;
            TipoMovimiento = string.Empty;
            TablaAfectada = string.Empty;
        }

        public Bitacora(int idUsuario, string ipEquipo, string nombreEquipo, string tipoMovimiento, string tablaAfectada)
        {
            IdUsuario = idUsuario;
            IpEquipo = ipEquipo;
            NombreEquipo = nombreEquipo;
            Fecha = DateTime.Now;
            TipoMovimiento = tipoMovimiento;
            TablaAfectada = tablaAfectada;
        }

        public Bitacora(int idAuditoria, int idUsuario, string ipEquipo, string nombreEquipo, DateTime fecha, string tipoMovimiento, string tablaAfectada)
        {
            IdAuditoria = idAuditoria;
            IdUsuario = idUsuario;
            IpEquipo = ipEquipo;
            NombreEquipo = nombreEquipo;
            Fecha = fecha;
            TipoMovimiento = tipoMovimiento;
            TablaAfectada = tablaAfectada;
        }
    }
}
