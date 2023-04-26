using Core;
using Core.EventSourcing;
using Domain.Products.ProductCommandStack.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Products.ProductCommandStack.Handlers
{
    public class ProductCreatedHandler : INotificationHandler<ProductCreated>
    {
        private readonly IEventSource eventSource;

        public ProductCreatedHandler(IEventSource eventSource)
        {
            this.eventSource = eventSource;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            var message = notification;
            var id = message.Id;

            await eventSource.Append(id, message);
        }
    }
}
