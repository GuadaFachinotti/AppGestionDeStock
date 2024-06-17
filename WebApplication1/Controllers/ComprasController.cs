using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion.Core.Entities;
using WebApplication1.Data;
using Gestion.Core.Business;

namespace WebApplication1.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var listaCompras = _operacionesBusiness.GetAllCompras();
            return View(listaCompras.Items);
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
                compra.UsuarioId = 3;
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
