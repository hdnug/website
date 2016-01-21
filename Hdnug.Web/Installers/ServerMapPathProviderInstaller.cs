using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hdnug.Web.Inrastructure.Providers;
using Hdnug.Web.Interfaces;

namespace Hdnug.Web.Installers
{
    public class ServerMapPathProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProvideServerMapPath>().ImplementedBy<ServerMapPathProvider>());
        }
    }
}