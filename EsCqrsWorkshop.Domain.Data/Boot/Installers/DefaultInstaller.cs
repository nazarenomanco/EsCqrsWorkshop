using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EsCqrsWorkshop.Domain.Pizzerie;
using System.ComponentModel.Composition;

namespace EsCqrsWorkshop.Domain.Data.Installers
{
    [Export( typeof( IWindsorInstaller ) )]
    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install( IWindsorContainer container, IConfigurationStore store )
        {
            container.Register
            (
                Types.FromAssemblyContaining<Pizzeria>()
                    .IncludeNonPublicTypes()
                    .Where(t => !t.IsInterface && !t.IsAbstract && !t.IsGenericType && t.Namespace != null && t.IsNested && t.Name.EndsWith("Factory"))
                    .WithService.Select((type, baseTypes) => new[] { type })
                    .LifestyleSingleton()
            );
        }
    }
}
