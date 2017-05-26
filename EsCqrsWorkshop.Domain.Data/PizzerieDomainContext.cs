using Radical.CQRS.Data;
using System.Data.Entity;
using EsCqrsWorkshop.Domain.Data.Migrations;
using EsCqrsWorkshop.Domain.Pizzerie;
using EsCqrsWorkshop.Domain.ValueObjects;

namespace EsCqrsWorkshop.Domain
{
    public class PizzerieDomainContext : DomainContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .ToTable("dbo.Orders");
            modelBuilder.MapPropertiesOf<Order>();

            modelBuilder.Entity<Pizzeria.PizzeriaState>()
                .ToTable("dbo.Pizzerie")
                .HasMany(x => x.Orders)
                .WithOptional()
                .HasForeignKey(x => x.PizzeriaId)
                .WillCascadeOnDelete();
            modelBuilder.MapPropertiesOf<Pizzeria.PizzeriaState>(propertiesToSkip: new[] { "Orders" });
        }
    }
}
