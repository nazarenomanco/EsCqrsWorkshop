using Radical.CQRS.Data;
using System.Data.Entity.Infrastructure;

namespace EsCqrsWorkshop.Domain.Services
{
    public class DbContextFactory : IDbContextFactory<DomainContext>
    {
        public DomainContext Create()
        {
            var ctx = new PizzerieDomainContext();
            
            return ctx;
        }
    }
}
