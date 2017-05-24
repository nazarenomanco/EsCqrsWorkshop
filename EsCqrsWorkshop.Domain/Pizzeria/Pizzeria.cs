using System;
using System.Collections.Generic;
using System.Linq;
using EsCqrsWorkshop.Domain.ValueObjects;
using Radical.CQRS;
using Topics.Radical.Linq;

namespace EsCqrsWorkshop.Domain.Pizzeria
{
    public class Pizzeria : Aggregate<Pizzeria.PizzeriaState>
    {
        public class PizzeriaState : AggregateState
        {
            public string Name { get; set; }
            public List<Order> Orders { get; set; }
        }

        public class Factory
        {
            public Pizzeria CreateNew(string nome)
            {
                var state = new PizzeriaState()
                {
                    Name = nome,
                    Orders = new List<Order>()
                };
                var aggregate = new Pizzeria(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private Pizzeria(Pizzeria.PizzeriaState state)
            : base(state)
        {
        }
        private void SetupCompleted()
        {
            this.RaiseEvent<IPizzeriaCreated>(e =>
            {
                e.Name = this.Data.Name;
            });
        }

        public Guid AddOrder(string customerName, string pizzaTaste)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (pizzaTaste == null) throw new ArgumentNullException(nameof(pizzaTaste));

            var order = new Order(Id, customerName, pizzaTaste);
            this.Data.Orders.Add(order);

            this.RaiseEvent<IOrderReceived>(e =>
            {
                e.CustomerName = customerName;
                e.PizzaTaste = pizzaTaste;
                e.OrderId = order.Id;
            });

            return order.Id;

        }

        public IEnumerable<Guid> CompleteOrder(string customerName, string pizzaTaste, DateTime orderCreatedAt)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (pizzaTaste == null) throw new ArgumentNullException(nameof(pizzaTaste));

            var orders = this.Data.Orders.Where(x => x.CustomerName == customerName && x.PizzaTaste == pizzaTaste && x.CreatedAt == orderCreatedAt).ToArray();
            for (int i = orders.Length-1; i >= 0; i--)
            {
                this.Data.Orders.Remove(orders[i]);
            }

            this.RaiseEvent<IOrderCompleted>(e =>
            {
                e.CustomerName = customerName;
                e.PizzaTaste = pizzaTaste;
                e.OrderIds = orders.Select(x => x.Id).ToArray();
            });

            return orders.Select(x => x.Id);

        }

    }
}
