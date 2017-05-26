using System;
using System.Linq;

namespace EsCqrsWorkshop.ViewModels
{
    public interface IPizzerieViewContext: IDisposable
    {
        IQueryable<PizzeriaView> PizzerieView { get; }

        IQueryable<OrderView> OrdersView { get; }
    }
}
