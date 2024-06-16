using Gestion.Core.Business;
using Gestion.Core.Entities;
using Gestion.Core.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApiGestion.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Producto> GetProductos()
        {
            var productos = _productoBusiness.GetAll();

            return productos.Items;
        }

        [HttpGet("GetStockProductoPorId/{productoId}")]
        public StockProductoVM GetStockProductoPorId(int productoId)
        {
            var resultVM = _operacionesBusiness.GetStockProducto(productoId);

            return resultVM;
        }
    }
}
