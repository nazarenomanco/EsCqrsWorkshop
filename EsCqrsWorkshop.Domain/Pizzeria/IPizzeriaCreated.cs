using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Pizzeria
{
    public interface IPizzeriaCreated : IDomainEvent
    {
        string Name { get; set; }
    }
}
