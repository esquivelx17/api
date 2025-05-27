using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InventariosCore.Model;
using InventariosCore.Utilities;

namespace InventariosCore.Data
{
    public class BitacoraDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.BitacoraDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public BitacoraDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _logger.Info("BitacoraDataAccess inicializado correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar BitacoraDataAccess");
                throw;
            }
        }

        public int InsertarRegistroBitacora(Bitacora bitacora)
        {
            try
            {
                if (bitacora == null)
                {
                    _logger.Error("El objeto bitácora no puede ser nulo");
                    return -1;
                }

                if (string.IsNullOrEmpty(bitacora.IpEquipo))
                {
                    _logger.Error("El IP del equipo no puede estar vacío");
                    return -1;
                }

                if (string.IsNullOrEmpty(bitacora.TipoMovimiento))
                {
                    _logger.Error("El tipo de movimiento no puede estar vacío");
                    return -1;
                }

                if (string.IsNullOrEmpty(bitacora.TablaAfectada))
                {
                    _logger.Error("La tabla afectada no puede estar vacía");
                    return -1;
                }

                string query = @"
                    INSERT INTO bitacora (id_usuario, ip_equipo, nombre_equipo, fecha, tipo_movimiento, tabla_afectada)
                    VALUES (@IdUsuario, @IpEquipo, @NombreEquipo, @Fecha, @TipoMovimiento, @TablaAfectada)
                    RETURNING id_auditoria";

                var parameters = new List<NpgsqlParameter>
                {
                    _dbAccess.CreateParameter("@IdUsuario", bitacora.IdUsuario),
                    _dbAccess.CreateParameter("@IpEquipo", bitacora.IpEquipo),
                    _dbAccess.CreateParameter("@NombreEquipo", bitacora.NombreEquipo ?? string.Empty),
                    _dbAccess.CreateParameter("@Fecha", bitacora.Fecha),
                    _dbAccess.CreateParameter("@TipoMovimiento", bitacora.TipoMovimiento),
                    _dbAccess.CreateParameter("@TablaAfectada", bitacora.TablaAfectada)
                };

                _dbAccess.Connect();
                object? result = _dbAccess.ExecuteScalar(query, parameters.ToArray());
                int idGenerado = Convert.ToInt32(result);
                _logger.Info($"Registro de bitácora insertado con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar registro en la bitácora");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public Bitacora? ObtenerRegistroBitacoraPorId(int idAuditoria)
        {
            try
            {
                string query = @"
                    SELECT id_auditoria, id_usuario, ip_equipo, nombre_equipo, fecha, tipo_movimiento, tabla_afectada
                    FROM bitacora
                    WHERE id_auditoria = @IdAuditoria";

                var paramId = _dbAccess.CreateParameter("@IdAuditoria", idAuditoria);

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró registro de bitácora con ID {idAuditoria}");
                    return null;
                }

                return CrearBitacoraDesdeDataRow(resultado.Rows[0]);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener bitácora con ID {idAuditoria}");
                return null;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public List<Bitacora> ObtenerTodosLosRegistrosBitacora()
        {
            List<Bitacora> registros = new List<Bitacora>();
            try
            {
                string query = @"
                    SELECT id_auditoria, id_usuario, ip_equipo, nombre_equipo, fecha, tipo_movimiento, tabla_afectada
                    FROM bitacora
                    ORDER BY fecha DESC";

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    registros.Add(CrearBitacoraDesdeDataRow(row));
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros de bitácora");

                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener registros de bitácora");
                return registros;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene registros filtrados por fechas, tipo de movimiento y tabla afectada
        /// </summary>
        public List<Bitacora> ObtenerRegistrosPorFiltros(DateTime? fechaInicio, DateTime? fechaFin, string? tipoMovimiento, string? tablaAfectada)
        {
            List<Bitacora> registros = new List<Bitacora>();

            try
            {
                var sqlBuilder = new System.Text.StringBuilder();
                sqlBuilder.Append("SELECT id_auditoria, id_usuario, ip_equipo, nombre_equipo, fecha, tipo_movimiento, tabla_afectada FROM bitacora WHERE 1=1 ");

                var parameters = new List<NpgsqlParameter>();

                if (fechaInicio.HasValue)
                {
                    sqlBuilder.Append("AND fecha >= @FechaInicio ");
                    parameters.Add(_dbAccess.CreateParameter("@FechaInicio", fechaInicio.Value));
                }
                if (fechaFin.HasValue)
                {
                    sqlBuilder.Append("AND fecha <= @FechaFin ");
                    parameters.Add(_dbAccess.CreateParameter("@FechaFin", fechaFin.Value));
                }
                if (!string.IsNullOrEmpty(tipoMovimiento) && tipoMovimiento != "Todos")
                {
                    sqlBuilder.Append("AND tipo_movimiento = @TipoMovimiento ");
                    parameters.Add(_dbAccess.CreateParameter("@TipoMovimiento", tipoMovimiento));
                }
                if (!string.IsNullOrEmpty(tablaAfectada) && tablaAfectada != "Todos")
                {
                    sqlBuilder.Append("AND tabla_afectada = @TablaAfectada ");
                    parameters.Add(_dbAccess.CreateParameter("@TablaAfectada", tablaAfectada));
                }

                sqlBuilder.Append("ORDER BY fecha DESC");

                _dbAccess.Connect();

                DataTable resultado = parameters.Count == 0
                    ? _dbAccess.ExecuteQuery_Reader(sqlBuilder.ToString())
                    : _dbAccess.ExecuteQuery_Reader(sqlBuilder.ToString(), parameters.ToArray());

                foreach (DataRow row in resultado.Rows)
                {
                    registros.Add(CrearBitacoraDesdeDataRow(row));
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros filtrados de bitácora");

                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener registros filtrados de bitácora");
                return registros;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        private Bitacora CrearBitacoraDesdeDataRow(DataRow row)
        {
            return new Bitacora
            {
                IdAuditoria = Convert.ToInt32(row["id_auditoria"]),
                IdUsuario = Convert.ToInt32(row["id_usuario"]),
                IpEquipo = row["ip_equipo"]?.ToString() ?? string.Empty,
                NombreEquipo = row["nombre_equipo"]?.ToString() ?? string.Empty,
                Fecha = Convert.ToDateTime(row["fecha"]),
                TipoMovimiento = row["tipo_movimiento"]?.ToString() ?? string.Empty,
                TablaAfectada = row["tabla_afectada"]?.ToString() ?? string.Empty,
            };
        }
    }
}
