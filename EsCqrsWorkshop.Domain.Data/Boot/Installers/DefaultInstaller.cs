using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
//using Sample.Domain.People;
using System.ComponentModel.Composition;

namespace Sample.Domain.Data.Boot.Installers
{
    [Export( typeof( IWindsorInstaller ) )]
    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install( IWindsorContainer container, IConfigurationStore store )
        {
            //container.Register
            //(
            //    Types.FromAssemblyContaining<Person>()
            //        .IncludeNonPublicTypes()
            //        .Where( t => !t.IsInterface && !t.IsAbstract && !t.IsGenericType && t.Namespace != null && t.IsNested && t.Name.EndsWith( "Factory" ) )
            //        .WithService.Select( ( type, baseTypes ) => new[] { type } )
            //        .LifestyleSingleton()
            //);
        }
    }
}
