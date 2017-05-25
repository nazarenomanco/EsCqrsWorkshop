namespace EsCqrsWorkshop.ViewModels.Services
{
    class PizzerieViewContextFactory : IViewContextFactory<IPizzerieViewContext>
    {
        public IPizzerieViewContext Create() 
        {
            return new PizzerieViewContext();
        }
    }
}
