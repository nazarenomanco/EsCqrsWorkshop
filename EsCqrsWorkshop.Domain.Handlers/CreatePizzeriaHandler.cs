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
    class CreatePizzeriaHandler : AbstractCommandHandler<CreatePizzeria>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Pizzeria.Factory PizzeriaFactory { get; set; }

        protected override object OnExecute(CreatePizzeria command)
        {
            using (var repository = this.RepositoryFactory.OpenSession())
            {
                var pizzeria = this.PizzeriaFactory.CreateNew(command.Name);

                repository.Add(pizzeria);
                repository.CommitChanges();

                return pizzeria.Id;
            }
        }
    }
}
