using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using BackendCSharpOAuth.Api.Usuarios;
using BackendCSharpOAuth.Dominio;
using System.Web.Mvc;
using BackendCSharpOAuth.IoC.App_Start;

namespace BackendCSharpOAuth.Api
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
       
        public override async Task ValidateClientAuthentication
            (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials
            (OAuthGrantResourceOwnerCredentialsContext context)
        {

            //var usuario = BaseUsuarios
            //   .Usuarios()
            //   .FirstOrDefault(x => x.Nome == context.UserName
            //                   && x.Senha == context.Password);

            var servUsuarios = NinjectWebCommon.Resolve<IServUsuarios>();
            var usuario = servUsuarios.RecuperarUsuarioParaToken(context.UserName, context.Password);
            
            // cancelando a emissão do token se o usuário não for encontrado
            if (usuario == null)
            {
                context.SetError("invalid_grant", 
                    "Usuário não encontrado e/ou senha incorreta.");
                return;
            }

            // emitindo o token com informacoes extras
            // se o usuário existe
            var identidadeUsuario = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identidadeUsuario);
        }
    }
}