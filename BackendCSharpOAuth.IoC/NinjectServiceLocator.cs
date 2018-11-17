using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Ninject;

namespace BackendCSharpOAuth.IoC.App_Start
{
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        public IKernel Kernel { get; private set; }

        public NinjectServiceLocator(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return Kernel.Get(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}