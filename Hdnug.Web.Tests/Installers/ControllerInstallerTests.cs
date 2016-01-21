using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using Hdnug.Web.Controllers;
using Hdnug.Web.Installers;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Installers
{
    [TestFixture]
    public class ControllerInstallerTests
    {
        private IWindsorContainer _containerWithControllers;

        [SetUp]
        public void SetUp()
        {
            _containerWithControllers = new WindsorContainer()
                .Install(new ControllerInstaller());
        }

        [Test]
        public void AllControllersImplementIController()
        {
            var allHandlers = GetAllHandlers(_containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof(IController), _containerWithControllers);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, controllerHandlers);
        }

        [Test]
        public void AllControllersAreRegistered()
        {
            // Is<TType> is an helper, extension method from Windsor in the Castle.Core.Internal namespace
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void AllAndOnlyControllersHaveControllersSuffix()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.EndsWith("Controller"));
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithControllers);
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
