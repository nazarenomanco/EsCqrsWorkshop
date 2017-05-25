using System;

namespace EsCqrsWorkshop.ViewModels
{
    public interface IViewContextFactory<TContext> where TContext : IDisposable
    {
        TContext Create();
    }
}
