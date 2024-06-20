using Gestion.Core.Data;
using Gestion.Core.Entities;
using Gestion.Core.Entities.Result;
using Gestion.Core.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Business
{
    public class OperacionesBusiness
    {
        private readonly OperacionesRepository _operacionesRepository;
        private readonly ProductoRepository _productoRepository;

        public OperacionesBusiness(OperacionesRepository operacionesRepository, ProductoRepository productoRepository)
        {
            _operacionesRepository = operacionesRepository;
            _productoRepository = productoRepository;
        }

        //--------------Compra-----------------------
        public CompraResult GetAllCompras()
        {
            return _operacionesRepository.GetAllCompras();
        }
        public CompraResult GetAllComprasPaginado(int numeroPagina, int tamanoPagina)
        {
            return _operacionesRepository.GetAllComprasPaginado(numeroPagina, tamanoPagina);
        }

        public void AltaCompra(Compra compra)
        {
            _operacionesRepository.AltaCompra(compra);
        }

        public void BajaCompra(int compraId)
        {
            _operacionesRepository.BajaCompra(compraId);
        }

        //--------------Venta-----------------------
        public VentaResult GetAllVentas()
        {
            return _operacionesRepository.GetAllVentas();
        }
        public VentaResult GetAllVentasPaginado(int numeroPagina, int tamanoPagina)
        {
            return _operacionesRepository.GetAllVentasPaginado(numeroPagina, tamanoPagina);
        }

        public void AltaVenta(Venta venta)
        {
            _operacionesRepository.AltaVenta(venta);
        }

        public void BajaVenta(int ventaId)
        {
            _operacionesRepository.BajaCompra(ventaId);
        }

        public StockProductoVM GetStockProducto(int ProductoId)
        {
            StockProductoVM stockProductoVM = new StockProductoVM();

            //todas las compras del producto
            var compras = GetAllCompras();
            var comprasFiltradas = compras.Items.FindAll(x => x.ProductoId == ProductoId);

            int cantidadCompras = comprasFiltradas.Sum(x => x.Cantidad);

            //todas las ventas del producto
            var ventas = GetAllVentas();
            var ventasFiltradas = ventas.Items.FindAll(x => x.ProductoId == ProductoId);

            int cantidadVentas = ventasFiltradas.Sum(x => x.Cantidad);

            stockProductoVM.Stock = cantidadCompras - cantidadVentas;            
            stockProductoVM.Producto = _productoRepository.GetProductoById(ProductoId).Items.FirstOrDefault();

            return stockProductoVM;
        }

    }
}
