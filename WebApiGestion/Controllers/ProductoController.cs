using Gestion.Core.Business;
using Gestion.Core.Entities;
using Gestion.Core.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApiGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBusiness _productoBusiness;
        private readonly OperacionesBusiness _operacionesBusiness;


        public ProductoController(ProductoBusiness productoBusiness,
                                    OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
        }

        [HttpGet("GetProductos")]
        //Al utilizar de retorno IActionResult, podemos devolver diferentes tipos de respuestas HTTP, como Ok, BadRequest, NotFound, StatusCode, etc.
        //ej 404 not found, 200 ok, 500 internal server error, 401 unauthorized
        public IActionResult GetProductos()
        {
            var productos = _productoBusiness.GetAll();

            return Ok(productos.Items);
        }

        [HttpGet("GetStockProductoPorId/{productoId}")]
        //Al utilizar de retorno IActionResult, podemos devolver diferentes tipos de respuestas HTTP, como Ok, BadRequest, NotFound, StatusCode, etc.
        //ej 404 not found, 200 ok, 500 internal server error, 401 unauthorized
        public IActionResult GetStockProductoPorId(int productoId)
        {
            try
            {
                var resultVM = _operacionesBusiness.GetStockProducto(productoId);

            return Ok(resultVM);
            }
            catch (Exception ex)
            {
                // Retorna un 500 Internal Server Error con el mensaje de la excepción
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
