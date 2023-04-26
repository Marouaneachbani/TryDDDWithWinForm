using MediatR;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using ServiceStack;

using System.Threading.Tasks;
using ServiceStack.Text;

namespace Core.EventSourcing
{
    public interface  IEventSourcingServices
    {
        string SerializeData<T>(T theEvent) where T : INotification;
    }
    public class EventSourcingServices : IEventSourcingServices
    {
        
        public  string SerializeData<T>(T theEvent) where T : INotification
        {
            var data = JsonSerializer.SerializeToString(theEvent,typeof(INotification));
            
            return data;
        }
    }
}
