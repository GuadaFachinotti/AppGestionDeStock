using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Entities.Result
{
    public class CompraResult :BaseResult 
    {
        public List<Compra> Items { get; set; }

        public CompraResult()
        {
            Items = new List<Compra>();
        }
    }
}
