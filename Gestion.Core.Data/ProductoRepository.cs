using Gestion.Core.Configuration;
using Gestion.Core.Entities;
using Gestion.Core.Entities.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Data
{
    public class ProductoRepository
    {
        private readonly Config _config;

        public ProductoRepository(Config config)
        {
            _config = config;
        }


        public ProductoResult GetAll()
        {
            var result = new ProductoResult();

            using (var db = new GestionContext(_config))
            {
                result.Items = db.Producto
                    .Include(p => p.Categoria)
                    .ToList();
                result.HasError = false;
            }

            return result;
        }

        //Método Obtener los productos por Id
        public ProductoResult GetProductoById(int id)
        {
            var result = new ProductoResult();

            using (var db = new GestionContext(_config))
            {
                var producto = db.Producto.FirstOrDefault(p => p.ProductoId == id);
            }

            return result;
        }


        //Método Obtener las Categorías por Id
        public ProductoResult GetAllCategoria(int id)
        {
            var result = new ProductoResult();

            using (var db = new GestionContext(_config))
            {
                var categoria = db.Categoria.FirstOrDefault(p => p.CategoriaId == id);
            }

            return result;

        }

        public void AltaProducto(Producto producto)
        {
            using (var db = new GestionContext(_config))
            {
                db.Producto.Add(producto);
                db.SaveChanges();
            }
        }
        public void BajaProducto(int productoId)
        {
            using (var db = new GestionContext(_config))
            {
                // Buscar el producto por su ID
                var producto = db.Producto.Find(productoId);

                // Se Verifica si el producto existe
                if (producto != null)
                {
                    producto.Habilitado = false;

                    // Marcar la entidad como modificada
                    //la entidad producto ha sido modificada y debe ser actualizada en la base de datos.
                    db.Entry(producto).State = EntityState.Modified;

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
                }
            }
        }

        public void ModificarProducto(Producto productoActualizado)
        {
            using (var db = new GestionContext(_config))
            {
                // Buscar el producto original por su ID
                var producto = db.Producto.Find(productoActualizado.ProductoId);

                // Verificar si el producto existe
                if (producto != null)
                {
                    // Actualizar las propiedades del producto con los nuevos valores
                    producto.Nombre = productoActualizado.Nombre;
                    producto.CategoriaId = productoActualizado.CategoriaId;

                    // Marcar la entidad como modificada
                    db.Entry(producto).State = EntityState.Modified;

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
                }
            }
        }
    }
}
