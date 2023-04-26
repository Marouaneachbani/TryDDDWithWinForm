using Domain.Products.ProductCommandStack;
using Domain.Products.ProductCommandStack.Commands;
using Domain.Products.ProductQueryStack.Dtos;
using Domain.Products.ProductQueryStack.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMediator _mediatr;

        public ProductServices(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task CreateProduct(string productName, string productCategory, Guid productCategoryId, string productBrand , Guid productBandId)
        {
            var id = Guid.NewGuid();
            var aggregate = new ProductAggregate(_mediatr);
            var command = new CreateProduct {Id = id , ProductName = productName 
               , ProductCategoryId = productCategoryId , 
                ProductBrandId = productBandId };
            var send = await _mediatr.Send(command);
            
            if(send == false)
            {
                throw new Exception(); 
            }
            aggregate.AddProduct(id, productName, productCategory, productBrand); 
        }

        public async Task<List<CategoriesList>> GetCategories()
        {
            var model = new CategoriesListQuery(); 
            var query = await model.GetCategoriesList();
            return query;

        }
        

        public async Task<List<BrandsList>> GetBrands()
        {
            var model = new BrandsListQuery();
            var query = await model.GetCategoriesList();
            return query;
        }
        public async Task<List<ProductsList>>GetProducts()
        {
            var model = new ProductListQuery();
            var query = await model.GetProducts();
            return query;
        }
    }
    public interface IProductServices
    {
        Task CreateProduct(string productName , string productCategory ,Guid productCategoryId , string productBrand , Guid productBandId);
        Task<List<CategoriesList>> GetCategories(); 
        Task<List<BrandsList>> GetBrands();
        Task<List<ProductsList>> GetProducts();
    }
}
