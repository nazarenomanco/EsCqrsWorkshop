using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.Data.Migrations
{
    public class DatabaseInitializer: CreateDatabaseIfNotExists<PizzerieDomainContext>
    {
        protected override void Seed(PizzerieDomainContext context)
        {
            base.Seed(context);

        }
    }
}
