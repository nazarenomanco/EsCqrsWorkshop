using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsCqrsWorkshop.Messages.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Handlers
{
    class CompleteOrderHandler : AbstractCommandHandler<CompleteOrder>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Pizzeria.Pizzeria.Factory CompanyFactory { get; set; }

        protected override object OnExecute(CompleteOrder command)
        {
            using (var repository = this.RepositoryFactory.OpenSession())
            {
                var pizzeria = repository.GetById<Pizzeria.Pizzeria>(command.PizzeriaId);


                pizzeria.CompleteOrder(command.CustomerName, command.PizzaTaste, command.OrderCreatedAt);

                repository.CommitChanges();

                // Cosa torno?
                return null;

            }
        }
    }
}
