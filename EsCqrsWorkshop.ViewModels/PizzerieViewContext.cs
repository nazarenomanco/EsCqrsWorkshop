using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EsCqrsWorkshop.ViewModels
{
    class PizzerieViewContext : DbContext, IPizzerieViewContext
    {
        readonly DbSet<PizzeriaView> _pizzeriaViewSet;

        public PizzerieViewContext()
        {
            this._pizzeriaViewSet = this.Set<PizzeriaView>();
        }

        public IQueryable<PizzeriaView> PizzerieView
        {
            get { return this._pizzeriaViewSet.AsNoTracking(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var pizzeria = modelBuilder.Entity<PizzeriaView>();
            pizzeria.ToTable("dbo.PizzerieView");
            pizzeria.Property(a => a.PizzeriaId).HasColumnName("Id");
            pizzeria.Property(a => a.Name).HasColumnName("Name");
            pizzeria.HasKey(a => a.PizzeriaId);

            var order = modelBuilder.Entity<OrderView>();
            order.ToTable("dbo.OrdersView");
            order.Property(a => a.OrderId ).HasColumnName("Id");
            order.Property(a => a.PizzeriaId).HasColumnName("PizzeriaId");
            order.Property(a => a.PizzaTaste).HasColumnName("PizzaTaste");
            order.Property(a => a.CustomerName).HasColumnName("CustomerName");
            order.Property(a => a.CreatedAt).HasColumnName("CreatedAt");
            order.HasKey(a => a.OrderId);

        }
    }
}
