using Gestion.Core.Business;
using Gestion.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
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
        public IActionResult Index(int numeroPagina = 1, int tamanoPagina = 10)
        {
            var listaVentas = _operacionesBusiness.GetAllVentasPaginado(numeroPagina, tamanoPagina);
            var ventaViewModel = new VentaPaginadoVM();
            ventaViewModel.Items = listaVentas.Items;
            ventaViewModel.TotalElementos = listaVentas.TotalElementos;
            ventaViewModel.NumeroPagina = numeroPagina;
            ventaViewModel.TamanoPagina = tamanoPagina;
            return View(ventaViewModel);
        }

        public IActionResult AgregarVenta()
        {
            //El primer parametro es una coleccion (lista de productos), el segundo es el value de la lista (ProductoId) y el tercero es el Texto a mostar
            //El listado se envia hacia la vista para utilizarlo en el selector de productos
            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items.FindAll(x=> x.Habilitado), "ProductoId", "Nombre");
            return View();
        }

        // POST: Ventas/GuardarVenta
        [HttpPost]
        public async Task<IActionResult> GuardarVenta([Bind("Cantidad,ProductoId")] Venta venta)
        {
            //Validaciones
            var stock = _operacionesBusiness.GetStockProducto(venta.ProductoId).Stock;

            if (venta.Cantidad <= stock)
            {
                venta.UsuarioId = Int32.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                venta.Fecha = DateTime.Now;
                _operacionesBusiness.AltaVenta(venta);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = $"No hay suficiente stock para esta venta. Stock disponible {stock}";
            }

            if (ViewBag.Error == null) { ViewBag.Error = "Ha ocurrido un error inesperado, favor de intentar nuevamente más tarde."; };

            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items.FindAll(x => x.Habilitado), "ProductoId", "Nombre", venta.ProductoId);
            return View("AgregarVenta", venta);
        }
    }
}
