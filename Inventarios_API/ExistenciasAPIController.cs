using InventariosCore.Controllers;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("list_existencias")]
        public IActionResult GetExistencias([FromQuery] string clave = null)
        {
            try
            {
                var existencias = _productosController.ObtenerProductosParaAPI(clave);

                return Ok(existencias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener existencias");
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

    }
}
