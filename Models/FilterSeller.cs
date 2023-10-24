using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class FilterSeller
    {
        public string Category { get; set; }
        public string SearchValue { get; set; }
        public List<Seller> Data { get; set; }   
    }
}