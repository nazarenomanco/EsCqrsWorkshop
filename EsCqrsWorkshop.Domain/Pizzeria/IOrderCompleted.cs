using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Pizzeria
{
    public interface IOrderCompleted : IDomainEvent
    {
        string CustomerName { get; set; }
        Guid PizzeriaId { get; set; }
        string PizzaTaste { get; set; }
    }
}
