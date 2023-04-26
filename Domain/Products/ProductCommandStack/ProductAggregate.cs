using Core;
using Domain.Products.ProductCommandStack.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.ProductCommandStack
{
    public class ProductAggregate : BaseAggregate
    {
        private string _productName;
        private string _productBrand;
        private string _productCategory;

        public ProductAggregate(IMediator mediator) : base(mediator)
        {
        }

        public string ProductName { get => _productName; set => _productName = value; }
        public string ProductBrand { get => _productBrand; set => _productBrand = value; }
        public string ProductCategory { get => _productCategory; set => _productCategory = value; }
        public void AddProduct(Guid id,string productName , string productCategory , string productBrand)

        {
            
            _productName = productName;
            _productBrand = productBrand;
            _productCategory = productCategory;
            var productCreated = new ProductCreated()
            {
                Id = id,
                ProductName = _productName,
                ProductBrand = _productBrand,
                ProductCategory = _productCategory
            };
            this.PublishEvent(productCreated);

        }
        
        
    }
}
