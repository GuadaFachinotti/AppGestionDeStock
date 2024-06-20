using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion.Core.Entities;
using Gestion.Core.Business;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly ProductoBusiness _productoBusiness;
        private readonly OperacionesBusiness _operacionesBusiness;

        public ComprasController(ProductoBusiness productoBusiness,
                                    OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
        }

        // GET: Compras
        public async Task<IActionResult> Index(int numeroPagina=1, int tamanoPagina=10)
        {
            //en listaCompras se guarda Items(todas las compras de la pagina actual) y TotalElementos (Todas las compras en la base)
            var listaCompras = _operacionesBusiness.GetAllComprasPaginado(numeroPagina, tamanoPagina);

            var compraViewModel = new CompraPaginadoVM();
            compraViewModel.Items = listaCompras.Items;
            compraViewModel.TotalElementos = listaCompras.TotalElementos;
            compraViewModel.NumeroPagina = numeroPagina;
            compraViewModel.TamanoPagina = tamanoPagina;
           
           

            return View(compraViewModel);
        }

        // GET: Compras/AgregarCompra
        public IActionResult AgregarCompra()
        {
            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items, "ProductoId", "Nombre");
            return View();
        }

        // POST: Compras/GuardarCompra
        [HttpPost]
        public async Task<IActionResult> GuardarCompra([Bind("Fecha,Cantidad,ProductoId")] Compra compra)
        {
            //Validaciones
            var Fechas7DiasAtras = (DateTime.Now).AddDays(-7);

            if (compra.Fecha > Fechas7DiasAtras && compra.Fecha <= DateTime.Now)
            {               

                compra.UsuarioId = Int32.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                _operacionesBusiness.AltaCompra(compra);
                return RedirectToAction(nameof(Index));
            }
            else {
                ViewBag.Error = $"La fecha debe estar entre : {Fechas7DiasAtras.ToString("dd/MM/yyyy")} y {DateTime.Now.ToString("dd/MM/yyyy")}";
            }

            if (ViewBag.Error == null) { ViewBag.Error = "Ha ocurrido un error inesperado, favor de intentar nuevamente más tarde."; };

            ViewData["ListaProductos"] = new SelectList(_productoBusiness.GetAll().Items, "ProductoId", "Nombre",compra.ProductoId);
            return View("AgregarCompra",compra);
        }
    }
}
