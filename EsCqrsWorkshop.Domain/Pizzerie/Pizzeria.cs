﻿using System;
using System.Collections.Generic;
using System.Linq;
using EsCqrsWorkshop.Domain.ValueObjects;
using Radical.CQRS;
using Topics.Radical.Linq;

namespace EsCqrsWorkshop.Domain.Pizzerie
{
    public class Pizzeria : Aggregate<Pizzeria.PizzeriaState>
    {
        public class PizzeriaState : AggregateState
        {
            public string Name { get; set; }
            public ISet<Order> Orders { get; set; } = new HashSet<Order>();
        }

        public class Factory
        {
            public Pizzeria CreateNew(string nome)
            {
                var state = new PizzeriaState()
                {
                    Name = nome,
                    Orders = new HashSet<Order>()
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

        public Guid CompleteOrder(Guid pizzeriaId, Guid orderId)
        {
            if (orderId == null) throw new ArgumentNullException(nameof(orderId));

            var order = this.Data.Orders.Single(x => x.Id == orderId);
            order.Completed = true;

            this.RaiseEvent<IOrderCompleted>(e =>
            {
                e.PizzeriaId = pizzeriaId;
                e.OrderId = order.Id;
                e.CustomerName = order.CustomerName;
                e.PizzaTaste = order.CustomerName;
            });

            return order.Id;

        }

    }
}
