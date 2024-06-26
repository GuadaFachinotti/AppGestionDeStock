using Gestion.Core.Business;
using Gestion.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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
