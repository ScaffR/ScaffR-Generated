#region credits
// ***********************************************************************
// Assembly	: DemoApplication.DependencyResolution
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion
#region

using ParadiseBookers.Core.Common.Membership.PasswordPolicies;
using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Interfaces.Eventing;
using ParadiseBookers.Core.Interfaces.Membership;
using ParadiseBookers.Core.Interfaces.Notifications;
using ParadiseBookers.Core.Interfaces.Photos;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Interfaces.Site;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Core.Services;
using ParadiseBookers.DependencyResolution;
using ParadiseBookers.Dropdowns;
using ParadiseBookers.Infrastructure.Configuration;
using ParadiseBookers.Infrastructure.Data;
using ParadiseBookers.Infrastructure.Eventing;
using ParadiseBookers.Infrastructure.Logging;
using ParadiseBookers.Infrastructure.Membership;
using ParadiseBookers.Infrastructure.Notifications;
using ParadiseBookers.Security.Authentication;
using ParadiseBookers.Security.Authorization;
using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Extensibility;
using Ninject;
using Ninject.Web.Common;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppStartup), "Stop")]

namespace ParadiseBookers.DependencyResolution
{
    #region

    

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

            // This is needed due to changed dependency resolution for WebAPI
            DependencyResolver.SetResolver(new NinjectResolver(kernel));

            // We don't need this, plus it messes up when controller is not found
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));

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

            kernel.Bind<IRepository<Log>>().To<LoggingRepository>().InRequestScope();
            kernel.Bind<IService<Log>>().To<LoggingService>().InRequestScope();

            // security
            kernel.Bind<IAuthenticationService>().To<ClaimsAuthenticationService>().InRequestScope();

            // dropdowns
            kernel.Bind<IDropdownProvider>().To<Dropdowns.Dropdowns.Dropdowns>().InRequestScope();

            // membership
            kernel.Bind<IUserAccountService>().To<UserAccountService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<INotificationService>().To<MembershipNotifications>().InRequestScope();
            kernel.Bind<IPasswordPolicy>().To<NopPasswordPolicy>().InRequestScope();

            // sitemap
            kernel.Bind<IAclModule>().To<ClaimsAuthorizeModule>().InSingletonScope();
            kernel.Bind<ISiteMapNodeVisibilityProvider>().To<FilteredSiteMapNodeVisibilityProvider>().InSingletonScope();

            // settings
            kernel.Bind<ISiteSettings>().ToConstant(AppConfig.Instance.Site).InSingletonScope();
            kernel.Bind<IPhotoSettings>().ToConstant(AppConfig.Instance.Photos).InSingletonScope();
            kernel.Bind<IMembershipSettings>().ToConstant(AppConfig.Instance.Membership).InSingletonScope();
        }

        public class NinjectControllerFactory : DefaultControllerFactory
        {
            private readonly IKernel ninjectKernel;

            public NinjectControllerFactory(IKernel kernel)
            {
                ninjectKernel = kernel;
            }

            protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
            {
                return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
            }
        }
    }
}