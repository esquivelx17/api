using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InventariosCore.Model;
using InventariosCore.Utilities;

namespace InventariosCore.Data
{
    public class MovimientoProductoDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.MovimientoProductoDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly ProductosDataAccess _productosDataAccess;
        private readonly UsuariosDataAccess _usuariosDataAccess;

        public MovimientoProductoDataAccess()
        {
            _dbAccess = PostgreSQLDataAccess.GetInstance();
            _productosDataAccess = new ProductosDataAccess();
            _usuariosDataAccess = new UsuariosDataAccess();
        }

        // Insertar nuevo movimiento (sin actualizar existencias aquí)
        public int InsertarMovimientoProducto(MovimientoProducto movimiento)
        {
            try
            {
                var producto = _productosDataAccess.ObtenerProductoPorId(movimiento.IdProducto);
                if (producto == null)
                {
                    _logger.Error($"Producto con ID {movimiento.IdProducto} no existe.");
                    return -1;
                }

                var operador = _usuariosDataAccess.ObtenerUsuarioPorId(movimiento.IdOperador);
                if (operador == null)
                {
                    _logger.Error($"Operador con ID {movimiento.IdOperador} no existe.");
                    return -1;
                }

                if (movimiento.Cantidad <= 0)
                {
                    _logger.Error("Cantidad debe ser mayor que cero.");
                    return -1;
                }

                if (movimiento.Estatus < 0 || movimiento.Estatus > 2)
                {
                    _logger.Error("Estatus inválido.");
                    return -1;
                }

                string sql = @"INSERT INTO movimientos_productos
                               (id_producto, id_operador, cantidad, fecha, estatus)
                               VALUES (@IdProducto, @IdOperador, @Cantidad, @Fecha, @Estatus)
                               RETURNING id_movimiento_producto";

                var parametros = new[]
                {
                    _dbAccess.CreateParameter("@IdProducto", movimiento.IdProducto),
                    _dbAccess.CreateParameter("@IdOperador", movimiento.IdOperador),
                    _dbAccess.CreateParameter("@Cantidad", movimiento.Cantidad),
                    _dbAccess.CreateParameter("@Fecha", movimiento.Fecha),
                    _dbAccess.CreateParameter("@Estatus", movimiento.Estatus)
                };

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(sql, parametros);
                int idGenerado = Convert.ToInt32(result);
                _logger.Info($"Movimiento insertado con ID {idGenerado}.");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar movimiento de producto");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Actualizar solo movimientos con estatus pendiente (2)
        public bool ActualizarMovimientoProducto(MovimientoProducto movimiento)
        {
            try
            {
                var actual = ObtenerMovimientoProductoPorId(movimiento.IdMovimientoProducto);
                if (actual == null)
                {
                    _logger.Warn($"Movimiento con ID {movimiento.IdMovimientoProducto} no encontrado.");
                    return false;
                }

                if (actual.Estatus != 2)
                {
                    _logger.Warn("Solo se pueden editar movimientos con estatus pendiente.");
                    return false;
                }

                string sql = @"UPDATE movimientos_productos
                               SET id_producto = @IdProducto,
                                   id_operador = @IdOperador,
                                   cantidad = @Cantidad,
                                   fecha = @Fecha,
                                   estatus = @Estatus
                               WHERE id_movimiento_producto = @IdMovimientoProducto";

                var parametros = new[]
                {
                    _dbAccess.CreateParameter("@IdMovimientoProducto", movimiento.IdMovimientoProducto),
                    _dbAccess.CreateParameter("@IdProducto", movimiento.IdProducto),
                    _dbAccess.CreateParameter("@IdOperador", movimiento.IdOperador),
                    _dbAccess.CreateParameter("@Cantidad", movimiento.Cantidad),
                    _dbAccess.CreateParameter("@Fecha", movimiento.Fecha),
                    _dbAccess.CreateParameter("@Estatus", movimiento.Estatus)
                };

                _dbAccess.Connect();
                int filas = _dbAccess.ExecuteNonQuery(sql, parametros);

                if (filas > 0)
                {
                    _logger.Info($"Movimiento con ID {movimiento.IdMovimientoProducto} actualizado.");
                    return true;
                }
                else
                {
                    _logger.Warn($"No se actualizó el movimiento con ID {movimiento.IdMovimientoProducto}.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al actualizar movimiento");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Obtener movimiento por id, con datos de producto y operador cargados
        public MovimientoProducto? ObtenerMovimientoProductoPorId(int id)
        {
            try
            {
                string sql = @"SELECT id_movimiento_producto, id_producto, id_operador, cantidad, fecha, estatus
                               FROM movimientos_productos
                               WHERE id_movimiento_producto = @Id";

                var param = _dbAccess.CreateParameter("@Id", id);

                _dbAccess.Connect();
                DataTable dt = _dbAccess.ExecuteQuery_Reader(sql, param);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                var movimiento = new MovimientoProducto
                {
                    IdMovimientoProducto = Convert.ToInt32(row["id_movimiento_producto"]),
                    IdProducto = Convert.ToInt32(row["id_producto"]),
                    IdOperador = Convert.ToInt32(row["id_operador"]),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Estatus = Convert.ToInt16(row["estatus"])
                };

                movimiento.Producto = _productosDataAccess.ObtenerProductoPorId(movimiento.IdProducto) ?? new Producto();
                movimiento.Operador = _usuariosDataAccess.ObtenerUsuarioPorId(movimiento.IdOperador) ?? new Usuario();

                return movimiento;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimiento con ID {id}");
                return null;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Obtener todos los movimientos (sin filtros, tú filtras en el controller o UI)
        public List<MovimientoProducto> ObtenerTodos()
        {
            var lista = new List<MovimientoProducto>();

            try
            {
                string sql = @"SELECT id_movimiento_producto, id_producto, id_operador, cantidad, fecha, estatus
                               FROM movimientos_productos";

                _dbAccess.Connect();
                DataTable dt = _dbAccess.ExecuteQuery_Reader(sql);

                foreach (DataRow row in dt.Rows)
                {
                    var movimiento = new MovimientoProducto
                    {
                        IdMovimientoProducto = Convert.ToInt32(row["id_movimiento_producto"]),
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        IdOperador = Convert.ToInt32(row["id_operador"]),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Estatus = Convert.ToInt16(row["estatus"])
                    };

                    movimiento.Producto = _productosDataAccess.ObtenerProductoPorId(movimiento.IdProducto) ?? new Producto();
                    movimiento.Operador = _usuariosDataAccess.ObtenerUsuarioPorId(movimiento.IdOperador) ?? new Usuario();

                    lista.Add(movimiento);
                }

                return lista;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener movimientos");
                return lista;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
