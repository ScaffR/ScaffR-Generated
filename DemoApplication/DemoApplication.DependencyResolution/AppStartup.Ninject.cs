#region credits
// ***********************************************************************
// Assembly	: DemoApplication.DependencyResolution
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
#region

using DemoApplication.DependencyResolution;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppStartup), "Stop")]

namespace DemoApplication.DependencyResolution
{
    #region

    using System;
    using System.Web;
    using System.Web.Mvc;
    using Core.Common.Membership.PasswordPolicies;
    using Core.Interfaces.Data;
    using Core.Interfaces.Eventing;
    using Core.Interfaces.Membership;
    using Core.Interfaces.Notifications;
    using Core.Interfaces.Photos;
    using Core.Interfaces.Service;
    using Core.Interfaces.Site;
    using Core.Services;
    using Dropdowns;
    using Dropdowns.Dropdowns;
    using Infrastructure.Configuration;
    using Infrastructure.Data;
    using Infrastructure.Eventing;
    using Infrastructure.Membership;
    using Infrastructure.Notifications;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MvcSiteMapProvider;
    using MvcSiteMapProvider.Extensibility;
    using Ninject;
    using Ninject.Web.Common;
    using Security.Authentication;
    using Security.Authorization;

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
            DependencyResolver.SetResolver(new NinjectResolver(kernel));  
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
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

            // security
            kernel.Bind<IAuthenticationService>().To<ClaimsAuthenticationService>().InRequestScope();

            // dropdowns
            kernel.Bind<IDropdownProvider>().To<Dropdowns>().InRequestScope();

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