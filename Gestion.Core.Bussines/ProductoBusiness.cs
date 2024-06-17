using Gestion.Core.Data;
using Gestion.Core.Entities;
using Gestion.Core.Entities.Result;

namespace Gestion.Core.Business
{
    public class ProductoBusiness
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoBusiness (ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public ProductoResult GetAll()
        {
            return _productoRepository.GetAll();
        }

        public ProductoResult GetProductoById(int productoId)
        {
            return _productoRepository.GetProductoById(productoId);
        }

        public void AltaProducto(Producto producto)
        {
           _productoRepository.AltaProducto(producto);
        }

        public void BajaProducto(int productoId)
        {
            _productoRepository.BajaProducto(productoId);
        }

        public void ModificarProducto(Producto productoActualizado)
        {
            _productoRepository.ModificarProducto(productoActualizado);
        }

        public List<Categoria> GetAllCategoria()
        {
           return _productoRepository.GetAllCategoria();
        }

        public List<Categoria> CategoriaCBox() 
        {
            var list = GetAllCategoria();
            var CategoriaTodos = new Categoria();
            CategoriaTodos.CategoriaId = 0;
            CategoriaTodos.Nombre = "Todos";

            list.Add(CategoriaTodos);

            return list.OrderBy(x=>x.CategoriaId).ToList();

        }

        public void EliminarProducto(int productoId) 
        {
            _productoRepository.EliminarProducto(productoId);
        }

    }

}
