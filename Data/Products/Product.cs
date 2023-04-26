using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid ProductBrand { get; set; }
        public Guid ProductCategory { get; set; }
    }
}
