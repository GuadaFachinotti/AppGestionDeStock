using Gestion.Core.Data;
using Gestion.Core.Entities;
using Gestion.Core.Entities.Result;
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

        public OperacionesBusiness(OperacionesRepository operacionesRepository)
        {
            _operacionesRepository = operacionesRepository;
        }

        //--------------Compra-----------------------
        public CompraResult GetAllCompras()
        {
            return _operacionesRepository.GetAllCompras();
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

        public void AltaVenta(Venta venta)
        {
            _operacionesRepository.AltaVenta(venta);
        }

        public void BajaVenta(int ventaId)
        {
            _operacionesRepository.BajaCompra(ventaId);
        }

        public int GetStockProducto(int ProductoId)
        {
            //todas las compras del producto
            var compras = GetAllCompras();
            var comprasFiltradas = compras.Items.FindAll(x => x.ProductoId == ProductoId);

            int cantidadCompras = comprasFiltradas.Sum(x => x.Cantidad);

            //todas las ventas del producto
            var ventas = GetAllVentas();
            var ventasFiltradas = ventas.Items.FindAll(x => x.ProductoId == ProductoId);

            int cantidadVentas = ventasFiltradas.Sum(x => x.Cantidad);

            int resultado = cantidadCompras - cantidadVentas;



            return resultado;
        }

    }
}
