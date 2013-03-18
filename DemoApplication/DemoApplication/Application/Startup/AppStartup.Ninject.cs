#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
#region

using DemoApplication.Application.Startup;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppStartup), "Stop")]

namespace DemoApplication.Application.Startup
{
    #region

    using System;
    using System.Web;
    using System.Web.Http;
    using Core.Interfaces.Data;
    using Core.Interfaces.Eventing;
    using Core.Interfaces.Photos;
    using Core.Interfaces.Service;
    using Core.Interfaces.Site;
    using Core.Interfaces.Storage;
    using Core.Services;
    using DependencyResolution;
    using Dropdowns;
    using Infrastructure.Configuration;
    using Infrastructure.Data;
    using Infrastructure.Eventing;
    using Infrastructure.Storage.Providers;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Security.Authentication;

    #endregion

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
            // infrastructure
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
            kernel.Bind<IMessageBus>().ToConstant(MessageBus.Instance).InSingletonScope();

            // services/repositories
            //kernel.Bind<IPersonService>().To<PersonService>().InRequestScope();
            //kernel.Bind<IPersonRepository>().To<PersonRepository>().InRequestScope();
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
            kernel.Bind<IStorageProvider>().To<SessionStorageProvider>();

            // settings
            kernel.Bind<ISiteSettings>().ToConstant(AppConfig.Instance.Site).InSingletonScope();
            kernel.Bind<IPhotoSettings>().ToConstant(AppConfig.Instance.Photos).InSingletonScope();
        }
    }
}