using Castle;
using Jason.Configuration;
using Jason.Windsor;
using System.Linq;
using System.Net;
using System.Windows;
using EsCqrsWorkshop.WpfClient.Presentation;
using Topics.Radical.Windows.Presentation.Boot;
using Topics.Radical.Windows.Presentation.Helpers;
using EsCqrsWorkshop.InMemoryBus.Services;

namespace EsCqrsWorkshop.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServicePointManager.DefaultConnectionLimit = 10;

            new WindsorApplicationBootstrapper<MainView>()
                .OnBeforeInstall(bootConventions =>
                {
                    bootConventions.AssemblyFileScanPatterns = entryAssembly =>
                    {
                        return bootConventions
                            .DefaultAssemblyFileScanPatterns(entryAssembly)
                            .Union(new[] { "EsCqrsWorkshop.*.dll" });
                    };
                })
                .OnBoot(container =>
                {
                    var probeDirectory = EnvironmentHelper.GetCurrentDirectory();
                    var wrapper = (ServiceProviderWrapper)container;

                    wrapper.Container.Resolve<UnreliableServiceBus>().StartPolling();

                    new DefaultJasonServerConfiguration(probeDirectory)
                    {
                        Container = new WindsorJasonContainerProxy(wrapper.Container),
                        //TypeFilter = t => !t.Is<ShopperFallbackCommandHandler>()
                    }
                        .AddEndpoint(new Jason.Client.JasonInProcessEndpoint())
                        .Initialize();

                    //.UsingAsFallbackCommandValidator<ObjectDataAnnotationValidator>();
                });
        }
    }
}
