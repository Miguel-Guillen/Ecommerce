using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class FilterProduct
    {
        public string Category { get; set; }
        public bool EnvioGratis { get; set; }
        public bool EnvioInter { get; set; }
        public List<Product> Data { get; set; }
    }
}