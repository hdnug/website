using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using Hdnug.Web.Controllers;
using Hdnug.Web.Installers;
using Highway.Data;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Installers
{
    [TestFixture]
    public class HighwayDataInstallerTests
    {
        private IWindsorContainer _containerWithContexts;

        [SetUp]
        public void SetUp()
        {
            _containerWithContexts = new WindsorContainer()
                .Install(new HighwayDataInstaller());
        }

        [Test]
        public void HdnugContextImplementsIDataContext()
        {
            var allHandlers = GetAllHandlers(_containerWithContexts);
            var contextHandler = GetHandlersFor(typeof (IDataContext), _containerWithContexts);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, contextHandler);
        }

        [Test]
        public void MappingConfigurationImplementsIMappingConfiguration()
        {
            var allHandlers = GetAllHandlers(_containerWithContexts);
            var contextHandler = GetHandlersFor(typeof(IController), _containerWithContexts);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, contextHandler);
        }

        [Test]
        public void RepositoryImplementsIRepository()
        {
            var allHandlers = GetAllHandlers(_containerWithContexts);
            var contextHandler = GetHandlersFor(typeof(IController), _containerWithContexts);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, contextHandler);
        }

        [Test]
        public void HdnugContextIsRegistered()
        {
            // Is<TType> is an helper, extension method from Windsor in the Castle.Core.Internal namespace
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithContexts);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        private Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where)
        {
            return typeof(HomeController).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }
    }
}
