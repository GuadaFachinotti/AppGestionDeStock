using Gestion.Core.Configuration;
using Gestion.Core.Entities.Result;
using Gestion.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Data
{
    public class OperacionesRepository
    {
        private readonly Config _config;

        public OperacionesRepository(Config config)
        {
            _config = config;
        }


        public CompraResult GetAllCompras()
        {
            var result = new CompraResult();

            using (var db = new GestionContext(_config))
            {
                result.Items = db.Compra
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)

                    .ToList();
                result.HasError = false;
            }

            return result;
        }

        public VentaResult GetAllVentas()
        {
            var result = new VentaResult();

            using (var db = new GestionContext(_config))
            {
                result.Items = db.Venta
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)

                    .ToList();
                result.HasError = false;
            }

            return result;
        }

        //Metodos Alta y Baja de Compra

        public void AltaCompra(Compra compra)
        {
            using (var db = new GestionContext(_config))
            {
                db.Compra.Add(compra);
                db.SaveChanges();
            }
        }
        public void BajaCompra(int compraId)
        {
            using (var db = new GestionContext(_config))
            {
                // Buscar el producto por su ID
                var compra = db.Compra.Find(compraId);

                // Se Verifica si el producto existe
                if (compraId != null)
                {
                   db.Compra.Remove(compra);

                   // Guardar los cambios en la base de datos
                   db.SaveChanges();
                }
            }
        }

        //Metodos Alta y Baja de venta

        public void AltaVenta(Venta venta)
        {
            using (var db = new GestionContext(_config))
            {
                db.Venta.Add(venta);
                db.SaveChanges();
            }
        }
        public void BajaVenta(int ventaId)
        {
            using (var db = new GestionContext(_config))
            {
                // Buscar el producto por su ID
                var venta = db.Venta.Find(ventaId);

                // Se Verifica si el producto existe
                if (ventaId != null)
                {
                    db.Venta.Remove(venta);

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
                }
            }
        }


    }
}

