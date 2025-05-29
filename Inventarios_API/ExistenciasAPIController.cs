using InventariosCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API_Inv
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExistenciasAPIController : ControllerBase
    {
        private readonly ProductosController _productosController;
        private readonly ILogger<ExistenciasAPIController> _logger;

        public ExistenciasAPIController(ProductosController productosController, ILogger<ExistenciasAPIController> logger)
        {
            _productosController = productosController;
            _logger = logger;
        }

        [HttpGet("existencia")]
        public IActionResult GetExistencia([FromQuery] string clave)
        {
            try
            {
                var producto = _productosController.ObtenerProductoPorClave(clave);
                if (producto == null)
                    return NotFound($"Producto con clave '{clave}' no encontrado.");

                return Ok(producto.Stock ?? 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener existencia");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("restar_existencia")]
        public IActionResult RestarExistencia([FromQuery] string clave, [FromQuery] int cantidad)
        {
            try
            {
                var producto = _productosController.ObtenerProductoPorClave(clave);
                if (producto == null)
                    return NotFound($"Producto con clave '{clave}' no encontrado.");

                if (producto.Stock == null || producto.Stock < cantidad)
                    return BadRequest("Stock insuficiente.");

                // Usamos el nuevo método para restar stock por clave
                bool actualizado = _productosController.ModificarStockPorClave(clave, cantidad);

                if (!actualizado)
                    return StatusCode(500, "No se pudo actualizar el stock.");

                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al restar existencia");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("estatus")]
        public IActionResult GetEstatus([FromQuery] string clave)
        {
            try
            {
                var producto = _productosController.ObtenerProductoPorClave(clave);
                if (producto == null)
                    return NotFound($"Producto con clave '{clave}' no encontrado.");

                return Ok(producto.Estatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estatus");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
