using Dapper;
using Domain.Products.ProductQueryStack.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Products.ProductQueryStack.Queries
{
    public class CategoriesListQuery 
    {
        private const string _connectionString =
            "Server=(local);Database=TryDDDWithWinForm;" +
            "Trusted_Connection=true;MultipleActiveResultSets=true";
        
        public   async Task<List<CategoriesList>> GetCategoriesList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var categories = await  connection.QueryAsync<CategoriesList>("SELECT [Id],[ProductCategoryName] FROM [dbo].[ProductCategories]");
                return categories.ToList();
            }
                
            
        }
    }
}
