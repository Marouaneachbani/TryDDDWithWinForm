using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product); 
    }
}
