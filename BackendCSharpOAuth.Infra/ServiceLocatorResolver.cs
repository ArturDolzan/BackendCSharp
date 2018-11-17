using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Infra
{
    public static class ServiceLocatorResolver
    {
        public static T Resolve<T>()
        {
            return (T)ServiceLocator.Current.GetInstance<T>();
        }
    }
}
