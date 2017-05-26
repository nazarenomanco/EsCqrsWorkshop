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
            this.Orders = new ObservableCollection<OrderView>();

        }

        public void OnViewLoaded()
        {
            this.PopulatePizzerie();
            SetupPropertyMetadata();
        }

        private void SetupPropertyMetadata()
        {
            this.GetPropertyMetadata(() => this.SelectedPizzeria)
                .OnChanged(pvc =>
                {
                    if (this.SelectedPizzeria != null)
                    {
                        this.PopulateOrders();
                    }
                });
        }

        async Task PopulatePizzerie()
        {

            this.Pizzerie = new ObservableCollection<PizzeriaView>();

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

        public string NewOrderCustomerName
        {
            get { return this.GetPropertyValue(() => this.NewOrderCustomerName); }
            set { this.SetPropertyValue(() => this.NewOrderCustomerName, value); }
        }

        public string NewOrderPizzaTaste
        {
            get { return this.GetPropertyValue(() => this.NewOrderPizzaTaste); }
            set { this.SetPropertyValue(() => this.NewOrderPizzaTaste, value); }
        }

        public ObservableCollection<OrderView> Orders
        {
            get { return this.GetPropertyValue(() => this.Orders); }
            set { this.SetPropertyValue(() => this.Orders, value); }
        }

        public OrderView SelectedOrder
        {
            get { return this.GetPropertyValue(() => this.SelectedOrder); }
            set { this.SetPropertyValue(() => this.SelectedOrder, value); }
        }



        public void CreateNewPizzeria()
        {

            if (string.IsNullOrEmpty(this.NewPizzeriaName))
                return;

            using (var client = this.clientFactory.CreateClient())
            {
                client.Execute(new CreatePizzeria(this.NewPizzeriaName));
            }

            this.PopulatePizzerie();

        }

        public void AddOrder()
        {
            if (this.SelectedPizzeria == null)
                return;

            if (string.IsNullOrEmpty(this.NewOrderCustomerName))
                return;

            if (string.IsNullOrEmpty(this.NewOrderPizzaTaste))
                return;

            using (var client = this.clientFactory.CreateClient())
            {
                client.Execute(new AddOrder(this.SelectedPizzeria.PizzeriaId, this.NewOrderCustomerName, this.NewOrderPizzaTaste));
            }

            this.PopulateOrders();
        }

        public void CompleteOrder()
        {
            if (this.SelectedPizzeria == null)
                return;

            if (this.SelectedOrder == null)
                return;

            using (var client = this.clientFactory.CreateClient())
            {
                client.Execute(new CompleteOrder(this.SelectedPizzeria.PizzeriaId, this.SelectedOrder.OrderId));
            }

            this.PopulateOrders();
        }

        public void PizzeriaSelectionChanged()
        {
            this.PopulateOrders();
        }

        async Task PopulateOrders()
        {
            this.Orders = new ObservableCollection<OrderView>();

            using (var db = this.pizzerieViewContextFactory.Create())
            {
                var all = await db.OrdersView
                    .Where(x => x.PizzeriaId == this.SelectedPizzeria.PizzeriaId)
                    .OrderBy(x => x.CreatedAt)
                    .ToListAsync();

                foreach (var item in all)
                {
                    this.Orders.Add(item);
                }
            }
        }

    }
}
