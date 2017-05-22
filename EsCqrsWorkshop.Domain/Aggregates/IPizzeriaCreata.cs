using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Aggregates
{
    public interface IPizzeriaCreata:IDomainEvent
    {
        string Nome { get; set; }
    }
}
