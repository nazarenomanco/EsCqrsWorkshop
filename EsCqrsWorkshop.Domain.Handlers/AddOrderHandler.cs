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
    class AddOrderHandler : AbstractCommandHandler<AddOrder>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Pizzeria.Pizzeria.Factory CompanyFactory { get; set; }

        protected override object OnExecute(AddOrder command)
        {
            using (var repository = this.RepositoryFactory.OpenSession())
            {
                var pizzeria = repository.GetById<Pizzeria.Pizzeria>(command.PizzeriaId);
                var id = pizzeria.AddOrder(command.CustomerName, command.PizzaTaste);

                repository.CommitChanges();

                return new {PizzeriaId = pizzeria.Id, OrderId = id};
            }
        }
    }
}
