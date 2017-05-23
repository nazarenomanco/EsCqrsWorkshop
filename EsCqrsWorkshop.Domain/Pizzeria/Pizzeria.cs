using System;
using EsCqrsWorkshop.Domain.ValueObjects;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Pizzeria
{
    public class Pizzeria : Aggregate<Pizzeria.PizzeriaState>
    {
        public class PizzeriaState : AggregateState
        {
            public string Name { get; set; }
            public Order[] Orders { get; set; }
        }

        public class Factory
        {
            public Pizzeria CreateNew(string nome)
            {
                var state = new PizzeriaState()
                {
                    Name = nome,
                    Orders = new Order[0]
                };
                var aggregate = new Pizzeria(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private Pizzeria(Pizzeria.PizzeriaState state)
            :base(state)
        {
        }
        private void SetupCompleted()
        {
            this.RaiseEvent<IPizzeriaCreated>(e =>
            {
                e.Name = this.Data.Name;
            });
        }

        public void AddOrder(string customerName, string pizzaTaste)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (pizzaTaste == null) throw new ArgumentNullException(nameof(pizzaTaste));

            this.RaiseEvent<IOrderReceived>(e =>
            {
                e.CustomerName = customerName;
                e.PizzaTaste = pizzaTaste;
                e.PizzeriaId = this.Id;
            });
        }

        public void CompleteOrder(string customerName, string pizzaTaste, DateTime orderCreatedAt)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (pizzaTaste == null) throw new ArgumentNullException(nameof(pizzaTaste));

            // TODO: Aggiungere filtro sul ViewModel

        }


    }
}
