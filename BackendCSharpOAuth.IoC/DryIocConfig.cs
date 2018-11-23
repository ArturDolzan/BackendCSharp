using DryIoc;
using DryIoc.WebApi;
using System;
using System.Linq;
using System.Web.Http;
using CommonServiceLocator;
using BackendCSharpOAuth.Repositorio.Base;
using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Dominio.Infra;
using BackendCSharpOAuth.Repositorio.Infra;

namespace BackendCSharpOAuth.IoC
{
    public static class DryIocConfig
    {        
        public static HttpConfiguration ConfigureDependencyInjection(this HttpConfiguration config)
        {
            try
            {
                var container = new Container().WithWebApi(config, throwIfUnresolved: t => t.IsController());

                ServiceLocator.SetLocatorProvider(() => new DryIocServiceLocator(container));

                container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), reuse: Reuse.InCurrentScope);

                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("BackendCSharpOAuth."));

                var types = (from p in assemblies
                             from i in p.GetTypes()
                             where i.IsClass                                
                                && !i.IsAbstract
                                && i != typeof(IRepositorioBase<>)
                                && i != typeof(RepositorioBase<>)
                             select i).ToList();
                foreach (var type in types)
                {
                    try
                    {
                        container.RegisterMany(type.GetInterfaces(), type, Reuse.InResolutionScope);
                        container.Register(type, Reuse.InResolutionScope);
                    }
                    catch (Exception ex)
                    {                  
                    }
                }
                return config;
            }
            catch (Exception ex)
            {
                throw ex;
            }                       
        }

        class Bootstrap
        {
            public Bootstrap()
            {
                new DomainBotstrap();

                new RepBotstrap();      
            }
        }
    }
}
