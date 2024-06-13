using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public Usuario Usuario { get; set; } //Propiedad de navegacion, hace referencia al usuario
        public Producto Producto { get; set; } //propiedad que hace referencia al Producto

    }
}
