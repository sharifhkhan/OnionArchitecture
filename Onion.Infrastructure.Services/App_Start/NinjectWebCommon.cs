using Onion.Infrastructure.Services.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Onion.Infrastructure.Services.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Onion.Domain.Interfaces;
    using Onion.Infrastructure.Repositories;

    public static class NinjectWebCommon
    {
        #region Static Fields

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        #endregion

        /// <summary>
        ///   Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///   Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        #region Methods

        /// <summary>
        ///   Creates the kernel that will manage your application.
        /// </summary>
        /// <returns> The created kernel. </returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            // Install our Ninject-based IDependencyResolver into the Web API config
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">
        /// The kernel. 
        /// </param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepositoryContext>().To<Northwind>();

            kernel.Bind<IProductRepository>().To<ProductRepository>();
        }

        #endregion
    }
}