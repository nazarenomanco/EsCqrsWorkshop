using Jason.Client.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EsCqrsWorkshop.Messages.Commands;
using EsCqrsWorkshop.ViewModels;
using Topics.Radical.Windows.Presentation;
using Topics.Radical.Windows.Presentation.ComponentModel;
using Topics.Radical.Windows.Presentation.Services.Validation;


namespace EsCqrsWorkshop.WpfClient.Presentation
{
    class MainViewModel : AbstractViewModel, IExpectViewLoadedCallback
    {
        readonly IWorkerServiceClientFactory clientFactory;
        readonly IViewContextFactory<IPizzerieViewContext> pizzerieViewContextFactory;

        public MainViewModel(IWorkerServiceClientFactory clientFactory, IViewContextFactory<IPizzerieViewContext> pizzerieViewContextFactory)
        {
            this.clientFactory = clientFactory;
            this.pizzerieViewContextFactory = pizzerieViewContextFactory;
            this.Pizzerie = new ObservableCollection<PizzeriaView>();

        }

        public void OnViewLoaded()
        {
            this.PopulatePizzerie();
        }

        async Task PopulatePizzerie()
        {
            using (var db = this.pizzerieViewContextFactory.Create())
            {
                var all = await db.PizzerieView
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                foreach (var item in all)
                {
                    this.Pizzerie.Add(item);
                }
            }
        }

        public ObservableCollection<PizzeriaView> Pizzerie
        {
            get { return this.GetPropertyValue(() => this.Pizzerie); }
            set { this.SetPropertyValue(() => this.Pizzerie, value); }
        }

        public PizzeriaView SelectedPizzeria
        {
            get { return this.GetPropertyValue(() => this.SelectedPizzeria); }
            set { this.SetPropertyValue(() => this.SelectedPizzeria, value); }
        }

        public string NewPizzeriaName
        {
            get { return this.GetPropertyValue(() => this.NewPizzeriaName); }
            set { this.SetPropertyValue(() => this.NewPizzeriaName, value); }
        }

        public void CreateNewPizzeria()
        {

            if (string.IsNullOrEmpty(this.NewPizzeriaName))
                return;

            using (var client = this.clientFactory.CreateClient())
            {
                var key = (Guid)client.Execute(new CreatePizzeria(this.NewPizzeriaName));
            }

        }

    }
}
