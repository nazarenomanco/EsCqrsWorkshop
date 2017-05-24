using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Pizzerie
{
    public interface IPizzeriaCreated : IDomainEvent
    {
        string Name { get; set; }
    }
}
