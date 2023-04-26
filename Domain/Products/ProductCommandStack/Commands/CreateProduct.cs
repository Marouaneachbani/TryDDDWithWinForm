using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.ProductCommandStack.Commands
{
    public class CreateProduct : BaseCommand
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid ProductBrandId { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
