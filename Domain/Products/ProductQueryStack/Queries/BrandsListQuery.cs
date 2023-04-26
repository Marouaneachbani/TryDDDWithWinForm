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
    public class BrandsListQuery
    {
        private const string _connectionString =
            "Server=(local);Database=SuperMarcher;" +
            "Trusted_Connection=true;MultipleActiveResultSets=true";

        public async Task<List<BrandsList>> GetCategoriesList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var categories = await connection.QueryAsync<BrandsList>("SELECT * FROM [dbo].[ProductBrands]");
                return categories.ToList();
            }


        }
    }
}
