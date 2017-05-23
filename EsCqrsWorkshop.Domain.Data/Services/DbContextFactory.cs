using Radical.CQRS.Data;
using System.Data.Entity.Infrastructure;

namespace Sample.Domain.Services
{
    public class DbContextFactory : IDbContextFactory<DomainContext>
    {
        public DomainContext Create()
        {
            var ctx = new SampleDomainContext();
            
            return ctx;
        }
    }
}
