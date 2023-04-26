using Dapper;
using Domain.Products.ProductQueryStack.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.ProductQueryStack.Queries
{
    public class ProductListQuery
    {
        private const string _connectionString =
            "Server=(local);Database=SuperMarcher;" +
            "Trusted_Connection=true;MultipleActiveResultSets=true";
        public async Task<List<ProductsList>>GetProducts()
        {
            using( var connection = new SqlConnection(_connectionString) )
            {
                await connection.OpenAsync();
                var product = await  connection.QueryAsync<ProductsList>("SELECT  Products.ProductName as Name   ,ProductCategories.ProductCategoryName as Category   ,ProductBrands.ProductBrandName as Brand FROM[SuperMarcher].[dbo].[Products]  join ProductBrands on ProductBrands.Id = Products.ProductBrandId join ProductCategories on ProductCategories.Id = Products.ProductCategoryId");
                return product.ToList();
            }
        }
    }
}
