using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Entities
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }


        public int UsuarioId { get; set; } //clave foranea
        public int ProductoId { get; set; } // clave foranea
        public Usuario Usuario { get; set; } //Propiedad de navegacion, hace referencia al usuario
        public Producto Producto { get; set; } //Propiedad de navegacion, hace referencia al Producto


    }
}
