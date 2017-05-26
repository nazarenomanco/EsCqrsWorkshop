using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;
using Radical.CQRS.Data;
using EsCqrsWorkshop.Domain.Pizzerie;

namespace EsCqrsWorkshop.Domain.Data.Services
{
    class PizzeriaFinder : IAggregateStateFinder<DomainContext, Pizzeria.PizzeriaState>
    {
        public IAggregateState FindById(DomainContext session, AggregateQuery aggregateQuery)
        {
            //ignoring Aggregate Version
            var db = session.Set<Pizzeria.PizzeriaState>();
            var aggregate = db.Include(nameof(Pizzeria.PizzeriaState.Orders))
                .Single(p => p.Id == aggregateQuery.Id);

            return aggregate;
        }

        public IEnumerable<IAggregateState> FindById(DomainContext session, params AggregateQuery[] aggregateQueries)
        {
            //ignoring Aggregate Version
            var aggregateIds = aggregateQueries.Select(q => q.Id).ToArray();
            var db = session.Set<Pizzeria.PizzeriaState>();
            var result = db.Include(nameof(Pizzeria.PizzeriaState.Orders))
                .Where(p => aggregateIds.Contains(p.Id))
                .ToList();

            return result;
        }
    }
}
