using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Entities.Result
{
    public class BaseResult
    {
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
