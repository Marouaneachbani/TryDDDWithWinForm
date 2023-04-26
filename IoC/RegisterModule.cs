using Autofac;
using Core;
using Data.Products;
using Data.Products.Interfaces;
using MediatR;
using MediatR.Extensions;
using MediatR.Extensions.Autofac.DependencyInjection;
using ProductManager.Services;

namespace IoC
{
    public class AutoModule : Autofac.Module
    {
        private MediatorBuilder mediatorBuilder;
        private MediatRConfiguration configuration;
         
        protected override void Load(ContainerBuilder builder)
        {
            mediatorBuilder.WithRequestHandler(typeof(IRequestHandler<IRequest>));
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<ProductServices>().As<IProductServices>().SingleInstance();
            builder.RegisterMediatR(configuration); 
            base.Load(builder);
        }
    }
}
