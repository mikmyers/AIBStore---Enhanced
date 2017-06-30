using System.Web.Mvc;
using Microsoft.Practices.Unity;
//using Unity.Mvc3;
using Microsoft.Practices.Unity.Mvc;
using AIBStore.Domain.Concrete;
using AIBStore.Domain.Abstract;
using AIBStore.MVC.Infrastucture.Abstract;
using AIBStore.MVC.Infrastucture.Concrete;

namespace AIBStore.MVC
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>(); 
            container.RegisterType<IProductRepository, EFProductRepository>();
            container.RegisterType<IProductCategoryRepository, EFProductCategoryRepository>();
            container.RegisterType<IOrderProcessor, OrderProcessor>();
            container.RegisterType<IAuthProvider, FormsAuthProvider>();
            container.RegisterType<IEmailProcessor, EmailProcessor>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            return container;
        }
    }
}