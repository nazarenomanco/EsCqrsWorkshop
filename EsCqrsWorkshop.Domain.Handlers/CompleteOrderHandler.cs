using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsCqrsWorkshop.Domain.Pizzerie;
using EsCqrsWorkshop.Messages.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace EsCqrsWorkshop.Domain.Handlers
{
    class CompleteOrderHandler : AbstractCommandHandler<CompleteOrder>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Pizzeria.Factory CompanyFactory { get; set; }

        protected override object OnExecute(CompleteOrder command)
        {
            using (var repository = this.RepositoryFactory.OpenSession())
            {
                var pizzeria = repository.GetById<Pizzeria>(command.PizzeriaId);

                var id = pizzeria.CompleteOrder(command.PizzeriaId, command.OrderId);

                repository.CommitChanges();

                return new { PizzeriaId = pizzeria.Id, CompletedOrderId = id };

            }
        }
    }
}
