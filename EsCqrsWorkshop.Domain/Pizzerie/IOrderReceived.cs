using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Pizzerie
{
    public interface IOrderReceived : IDomainEvent
    {
        Guid OrderId { get; set; }
        string CustomerName { get; set; }
        string PizzaTaste { get; set; }
    }
}
