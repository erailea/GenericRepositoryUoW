using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using GenericRepositoryUoW.Services;
using GenericRepositoryUoW.Data.UoW;

namespace GenericRepositoryUoW.Infrastructure
{
    /// <summary>
    /// To configure ninject NinjectDependencyResolver class inherits from IDependencyResolver
    /// </summary>
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //kernel.Bind<IUoW>().To<UoW>().WhenInjectedInto<CourseService>();
            kernel.Bind<ICourseService>().To<CourseService>();

            //kernel.Bind<IUoW>().To<UoW>().WhenInjectedInto<DepartmentCourseService>();
            kernel.Bind<IDepartmentCourseService>().To<DepartmentCourseService>();

            //kernel.Bind<IUoW>().To<UoW>().WhenInjectedInto<DepartmentService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();

            //kernel.Bind<IUoW>().To<UoW>().WhenInjectedInto<TestService>();
            kernel.Bind<ITestService>().To<TestService>();
        }
    }
}