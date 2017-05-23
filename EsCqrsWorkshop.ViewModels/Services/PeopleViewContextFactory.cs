namespace Sample.ViewModels.Services
{
    class PeopleViewContextFactory : IViewContextFactory<IPeopleViewContext>
    {
        public IPeopleViewContext Create() 
        {
            return new PeopleViewContext();
        }
    }
}
