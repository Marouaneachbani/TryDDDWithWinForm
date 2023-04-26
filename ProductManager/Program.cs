using Core;
using Core.EventSourcing;
using Data.Products;
using Data.Products.Interfaces;
using Domain.Products.ProductCommandStack.Commands;
using Domain.Products.ProductCommandStack.Events;
using Domain.Products.ProductCommandStack.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManager
{
    internal static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }
        private static void ConfigureServices(IServiceCollection services)
        {

            //services.AddTransient<INotificationHandler<ProductCreated>,ProductCreatedHandler>();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).GetTypeInfo().Assembly));
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateProduct).Assembly,
                typeof(CreateProductHandler).Assembly ));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IEventSourcingServices, EventSourcingServices>(); 
            services.AddTransient<IProductServices,ProductServices>();
            services.AddTransient<IEventSource,EventSource>();
            services.AddScoped<Form1>();
        }
    }
}
