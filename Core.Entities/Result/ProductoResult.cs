using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Entities.Result
{
    public class ProductoResult : BaseResult 
    {
        public List<Producto> Items { get; set; } 

        public ProductoResult() 
        {
            Items = new List<Producto>();
        }


    }
}
