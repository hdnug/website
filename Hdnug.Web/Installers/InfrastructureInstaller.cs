using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hdnug.Web.Inrastructure.Interfaces;
using Hdnug.Web.Inrastructure.Providers;

namespace Hdnug.Web.Installers
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMailingListService>()
                .ImplementedBy<MailgunMailingListService>());
        }
    }
}
