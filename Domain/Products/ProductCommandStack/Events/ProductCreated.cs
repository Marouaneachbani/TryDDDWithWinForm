using Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Products.ProductCommandStack.Events
{
    
    public class ProductCreated : INotification
    {
        public Guid Id { get; set; }


        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductBrand { get; set; }
    }
}
