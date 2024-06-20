using Gestion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PaginadoVM
    {
        public int NumeroPagina { get; set; }
        public int TamanoPagina { get; set; }
        public int TotalElementos { get; set; }
        public int TotalPaginas
        {
            get
            {
                return (int)Math.Ceiling((double)TotalElementos / TamanoPagina);
            }
        }
    }

    public class CompraPaginadoVM : PaginadoVM
    {
        public List<Compra> Items { get; set; }

    }
    public class VentaPaginadoVM : PaginadoVM
    {
        public List<Venta> Items { get; set; }

    }
}
