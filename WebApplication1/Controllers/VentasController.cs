using Gestion.Core.Business;
using Gestion.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class VentasController : Controller
    {
        private readonly ProductoBusiness _productoBusiness;
        private readonly OperacionesBusiness _operacionesBusiness;

        public VentasController(ProductoBusiness productoBusiness,
                                    OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
        }

        //Get:Ventas
        public IActionResult Index()
        {
            var listaVentas = _operacionesBusiness.GetAllVentas().Items;
            return View(listaVentas);
        }

        public IActionResult AgregarVenta()
        {
            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items, "ProductoId", "Nombre");
            return View();
        }

        // POST: Compras/GuardarVenta
        [HttpPost]
        public async Task<IActionResult> GuardarVenta([Bind("Cantidad,ProductoId")] Venta venta)
        {
            //Validaciones
            var stock = _operacionesBusiness.GetStockProducto(venta.ProductoId).Stock;

            if (venta.Cantidad <= stock)
            {
                venta.UsuarioId = 3;
                venta.Fecha = DateTime.Now;
                _operacionesBusiness.AltaVenta(venta);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = $"No hay suficiente stock para esta venta. Stock disponible {stock}";
            }

            if (ViewBag.Error == null) { ViewBag.Error = "Ha ocurrido un error inesperado, favor de intentar nuevamente más tarde."; };

            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items, "ProductoId", "Nombre", venta.ProductoId);
            return View("AgregarVenta", venta);
        }
    }
}
