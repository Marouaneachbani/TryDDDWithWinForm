using Data.Products.Interfaces;
using Domain.Products.ProductCommandStack.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Products.ProductCommandStack.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct,bool>
    {

        private readonly IProductRepository _productRepo;

        public CreateProductHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        async Task<bool> IRequestHandler<CreateProduct, bool>.Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            await _productRepo.AddProduct(new Data.Product { ProductName = request.ProductName, Id = request.Id, ProductBrand = request.ProductBrandId, ProductCategory = request.ProductCategoryId   });
            return true;
        }
    }
}
