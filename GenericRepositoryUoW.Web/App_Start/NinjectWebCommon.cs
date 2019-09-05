
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GenericRepositoryUoW.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GenericRepositoryUoW.Web.App_Start.NinjectWebCommon), "Stop")]


namespace GenericRepositoryUoW.Web.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GenericRepositoryUoW.Services;
    using GenericRepositoryUoW.Services.Interfaces;
    using GenericRepositoryUoW.Data.UoW;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
                /// Starts the application
                /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
                /// Stops the application.
                /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
                /// Creates the kernel that will manage your application.
                /// </summary>
                /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
                /// Load your modules or register your services here!
                /// </summary>
                /// <param name="kernel">The kernel.
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUoW>().To<UoW>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IDepartmentCourseService>().To<DepartmentCourseService>();
            kernel.Bind<ITestService>().To<TestService>();
        }
    }
}