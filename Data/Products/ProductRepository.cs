using Dapper;
using Data.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private const string _connectionString = 
            "Server=(local);Database=SuperMarcher;" +
            "Trusted_Connection=true;MultipleActiveResultSets=true";
        public async Task AddProduct(Product product)
        {
            var id = product.Id;
            var productName = product.ProductName;
            var productCategory = product.ProductCategory;
            var productBrand = product.ProductBrand;
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO [dbo].[Products]([Id],[ProductName],[ProductCategoryId],[ProductBrandId]) Values (@id,@productName,@productCategory,@productBrand) " 
                    , new {id,productName,productCategory,productBrand});
            }
            
        }
    }
}
