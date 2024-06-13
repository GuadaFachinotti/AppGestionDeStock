using Gestion.Core.Business;
using Gestion.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBusiness _productoBusiness;
        private readonly OperacionesBusiness _operacionesBusiness;

        private readonly ILogger<ProductoBusiness> _logger;

        public ProductoController(ProductoBusiness productoBusiness,
                                    OperacionesBusiness operacionesBusiness,
                                    ILogger<ProductoBusiness> logger)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
            _logger = logger;
        }

        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> GetProductos()
        {
            var productos = _productoBusiness.GetAll();

            return productos.Items;
        }

        [HttpGet(Name = "GetStockProductosPorId")]
        public int GetStockProductosPorId(int productoId)
        {
            var stock = _operacionesBusiness.GetStockProducto(productoId);

            return stock;
        }
    }
}
