using EsCqrsWorkshop.Domain.ValueObjects;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Aggregates
{
    public class Pizzeria : Aggregate<Pizzeria.PizzeriaStato>
    {
        public class PizzeriaStato : AggregateState
        {
            public string Nome { get; set; }
            public Ordine[] Ordini { get; set; }
        }

        public class Factory
        {
            public Pizzeria CreaNuova(string nome)
            {
                var stato = new PizzeriaStato()
                {
                    Nome = nome,
                    Ordini = new Ordine[0]
                };
                var aggregato = new Pizzeria(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private Pizzeria(Pizzeria.PizzeriaStato stato)
            :base(stato)
        {
        }
        private void SetupCompleted()
        {
            this.RaiseEvent<IPizzeriaCreata>(e =>
            {
                e.Nome = this.Data.Nome;
            });
        }
    }
}
