using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Net.Http.Headers;
using BackendCSharpOAuth.IoC;
using Microsoft.AspNet.SignalR;
using BackendCSharpOAuth.Dominio;

[assembly: OwinStartup(typeof(BackendCSharpOAuth.Api.Startup))]

namespace BackendCSharpOAuth.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            var config = new HttpConfiguration();

            config.ConfigureDependencyInjection();

            // configurando rotas
            config.MapHttpAttributeRoutes();
  

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando tokens de acesso
            AtivandoAccessTokens(app);

            // ativando configuração WebApi
            app.UseWebApi(config);

           // var hub = new HubConfiguration();
            //hub.EnableJSONP = true;
            //app.MapSignalR(hub);  

            //GlobalHost.DependencyResolver.Register(typeof(ChatHub), () => new ChatHub(new Teste()));
            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });     

        }

        private void AtivandoAccessTokens(IAppBuilder app)
        {
            // configurando fornecimento de tokens
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new ProviderDeTokensDeAcesso()
            };

            // ativando o uso de access tokens            
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
