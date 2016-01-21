using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hdnug.Domain.Data;
using Hdnug.Domain.Data.Models.Mapping;
using Highway.Data;

namespace Hdnug.Web.Installers
{
    public class HighwayDataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Registration for domain-bound context
            //container.Register(Component.For<IDomain>().ImplementedBy<HdnugContext>()
            //    .DependsOn(new { connectionString = ConfigurationManager.ConnectionStrings["HdnugContext"].ConnectionString }),
            //    Component.For<IMappingConfiguration>().ImplementedBy<MappingConfiguration>(),
            //    Component.For<IRepository>().ImplementedBy<Repository>());

            container.Register(Component.For<IDataContext>().ImplementedBy<HdnugContext>(),
                Component.For<IMappingConfiguration>().ImplementedBy<MappingConfiguration>(),
                Component.For<IRepository>().ImplementedBy<Repository>());
        }
    }
}