using EsCqrsWorkshop.Domain.Pizzerie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsCqrsWorkshop.Messages.Commands;
using Jason.Client.ComponentModel;

namespace EsCqrsWorkshop.Domain.Handlers.EventHandlers
{
    class OrderCompletedHandler : ComponentModel.IHandleEvent<IOrderCompleted>
    {
        readonly IWorkerServiceClientFactory clientFactory;

        public OrderCompletedHandler(IWorkerServiceClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public void Handle(IOrderCompleted orderCompletedEvent)
        {
            using (var client = this.clientFactory.CreateClient())
            {
                client.Execute(new NotifyDeliveryBoy(orderCompletedEvent.PizzeriaId, orderCompletedEvent.OrderId, orderCompletedEvent.CustomerName, orderCompletedEvent.PizzaTaste));
            }

        }
    }
}
