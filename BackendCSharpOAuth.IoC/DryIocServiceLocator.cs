using System;
using System.Collections.Generic;
using DryIoc;
using CommonServiceLocator;

namespace BackendCSharpOAuth.IoC
{
    public class DryIocServiceLocator : ServiceLocatorImplBase
    {
        private readonly IContainer container;

        public DryIocServiceLocator(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public IContainer GetContainer()
        {
            return container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == null) throw new ArgumentNullException("serviceType");
            return container.Resolve(serviceType, key);
        }


        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (serviceType == null) throw new ArgumentNullException("serviceType");
            return container.ResolveMany<object>(serviceType);
        }
    }
}
