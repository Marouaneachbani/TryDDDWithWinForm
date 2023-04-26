using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class BaseAggregate
    {
        public Guid Id { get; set; }
        private IMediator mediator;

        protected BaseAggregate(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected void PublishEvent(INotification @event)
        {
            mediator.Publish(@event);
        }
    }
}
