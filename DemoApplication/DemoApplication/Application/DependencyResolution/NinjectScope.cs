namespace DemoApplication.Application.DependencyResolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Syntax;

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot ResolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            this.ResolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = this.ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.ResolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = this.ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.ResolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            var disposable = (IDisposable)this.ResolutionRoot;
            if (disposable != null) disposable.Dispose();
            this.ResolutionRoot = null;
        }
    }
}