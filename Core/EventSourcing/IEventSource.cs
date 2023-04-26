using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Core.EventSourcing
{
    public interface IEventSource
    {
        Task Append(Guid aggregateId,INotification @event);  
    }
    public class EventSource : IEventSource
    {
        private const string _connectionString =
            "Server=(local);Database=SuperMarcher;" +
            "Trusted_Connection=true;MultipleActiveResultSets=true";
        private readonly IEventSourcingServices eventSourcingServices;

        public EventSource(IEventSourcingServices eventSourcingServices)
        {
            this.eventSourcingServices = eventSourcingServices;
        }

        public async Task Append(Guid aggregateId,INotification @event)
        {
            var id = Guid.NewGuid();
            var aggId = aggregateId;
            var data = eventSourcingServices.SerializeData(@event).ToString();
            var eventName = @event.GetType().Name;

            using (var connection = new SqlConnection(_connectionString))
            {
                 connection.Open();


                await connection.ExecuteAsync("insert into EventHistories values(@id,@aggId,@eventName,@data)",
                    new { id, aggId, eventName,data }) ;
            }
        }
    }
}
