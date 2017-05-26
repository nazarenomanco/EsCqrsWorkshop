using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EsCqrsWorkshop.Domain.Pizzerie;
using System.ComponentModel.Composition;

namespace EsCqrsWorkshop.Domain.Handlers
{
    [Export( typeof( IWindsorInstaller ) )]
    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install( IWindsorContainer container, IConfigurationStore store )
        {
            container.Register
            (
                Types.FromThisAssembly()
                    .IncludeNonPublicTypes()
                    .Where(t => !t.IsInterface && !t.IsAbstract && t.Namespace != null && t.Namespace.EndsWith(".EventHandlers"))
                    .WithService.FirstInterface()
                    .LifestyleSingleton()
            );
        }
    }
}
