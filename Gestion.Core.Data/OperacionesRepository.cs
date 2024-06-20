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
    // Se define una clase pública llamada OperacionesRepository que maneja las operaciones de la base de datos.
    public class OperacionesRepository
    {
        // Se declara una variable de solo lectura de tipo Config para almacenar la configuración. (DI)
        private readonly Config _config;

        public OperacionesRepository(Config config)
        {
            _config = config;
        }

        // Método que obtiene todas las compras de la base de datos.
        public CompraResult GetAllCompras()
        {
            var result = new CompraResult();

            // Usando un contexto de base de datos (GestionContext) con la configuración proporcionada.
            using (var db = new GestionContext(_config))
            {
                // Incluye las entidades relacionadas Usuario y Producto, y convierte el resultado a una lista.
                result.Items = db.Compra
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)

                    .ToList();
                result.HasError = false; // Indica que no hubo errores.
            }

            return result;
        }

        // Método que obtiene todas las compras de la base de datos de manera paginada.
        public CompraResult GetAllComprasPaginado(int numeroPagina, int tamanoPagina)
        {
            var result = new CompraResult();

            using (var db = new GestionContext(_config))
            {
                result.TotalElementos = db.Compra.Count(); // Cuenta el número total de elementos en la tabla Compra.
                result.Items = db.Compra
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)
                    .Skip((numeroPagina - 1) * tamanoPagina) // Omitir los registros de páginas anteriores
                    .Take(tamanoPagina)                      // Tomar solo el número de registros del tamaño de página
                    .ToList();                               // Convertir el resultado en una lista
                    
                result.HasError = false;
            }


            return result; // Devuelve el resultado de la consulta.

            // Fórmula de Paginación
            //Para determinar cuántos registros debes omitir(Skip), usas la fórmula:

            //Skip = (pageNumber−1)×pageSize

            //Ejemplos
            //Primera Página(pageNumber = 1):

            //Skip = (1 - 1) * 10 = 0
            //No se omiten registros, se toman los primeros 10 registros.
            //Segunda Página(pageNumber = 2):

            //Skip = (2 - 1) * 10 = 10
            //Se omiten los primeros 10 registros, se toman los siguientes 10 registros.
        }

        // Método que obtiene todos los usuarios de la base de datos.
        public List<Usuario> GetAllUsuarios()
        {
            var result = new List<Usuario>();

            using (var db = new GestionContext(_config))
            {
                result = db.Usuario.ToList(); // Convierte todos los registros de la tabla Usuario a una lista.
            }

            return result;
        }

        // Método que obtiene todas las ventas de la base de datos.
        public VentaResult GetAllVentas()
        {
            var result = new VentaResult();

            using (var db = new GestionContext(_config))
            {
                // Incluye las entidades relacionadas Usuario y Producto, y convierte el resultado a una lista.
                result.Items = db.Venta
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)

                    .ToList();
                result.HasError = false;
            }

            return result;
        }

        // Método que obtiene todas las ventas de la base de datos de manera paginada.
        public VentaResult GetAllVentasPaginado(int numeroPagina, int tamanoPagina)
        {
            var result = new VentaResult();

            using (var db = new GestionContext(_config))
            {
                result.TotalElementos = db.Venta.Count(); // Cuenta el número total de elementos en la tabla Venta.
                result.Items = db.Venta
                    .Include(c => c.Usuario)
                    .Include(c => c.Producto)
                    .Skip((numeroPagina - 1) * tamanoPagina) // Omitir los registros de páginas anteriores
                    .Take(tamanoPagina)                      // Tomar solo el número de registros del tamaño de página
                    .ToList();                               // Convertir el resultado en una lista

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
                db.Venta.Add(venta); // Agrega el nuevo objeto Venta a la base de datos.
                db.SaveChanges();  // Guarda los cambios en la base de datos.
            }
        }

        // Método para dar de baja (eliminar) una venta de la base de datos.
        public void BajaVenta(int ventaId)
        {
            using (var db = new GestionContext(_config))
            {
                // Buscar el producto por su ID
                var venta = db.Venta.Find(ventaId);

                // Se Verifica si la venta existe
                if (ventaId != null)
                {
                    db.Venta.Remove(venta); // Elimina la venta de la base de datos.

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
                }
            }
        }


    }
}

