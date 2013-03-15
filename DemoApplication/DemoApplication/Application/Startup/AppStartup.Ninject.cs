using DemoApplication.Application.Startup;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppStartup), "Stop")]

namespace DemoApplication.Application.Startup
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Core.Interfaces.Data;
    using Core.Interfaces.Service;
    using Data;
    using DependencyResolution;
    using Dropdowns;
    using Infrastructure.Interfaces.Storage;
    using Infrastructure.Storage.Providers;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Security;
    using Service;

    public partial class AppStartup
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
            kernel.Bind<IPersonService>().To<PersonService>().InRequestScope();
            kernel.Bind<IPersonRepository>().To<PersonRepository>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IRoleService>().To<RoleService>().InRequestScope();
            kernel.Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();
            kernel.Bind<IUserRoleService>().To<UserRoleService>().InRequestScope();
            kernel.Bind<IUserRoleRepository>().To<UserRoleRepository>().InRequestScope();
            kernel.Bind<IUserEmailService>().To<UserEmailService>().InRequestScope();
            kernel.Bind<IUserEmailRepository>().To<UserEmailRepository>().InRequestScope();
            kernel.Bind<IAuthenticationService>().To<ClaimsBasedAuthenticationService>().InRequestScope();
            kernel.Bind<IDropdownProvider>().To<Dropdowns>().InRequestScope();
            kernel.Bind<ITaskService>().To<TaskService>().InRequestScope();
            kernel.Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
            kernel.Bind<IStorageProvider>().To<SessionStorageProvider>();
        }
    }
}