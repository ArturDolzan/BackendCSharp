using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class UsuariosController : ControllerResposta
    {
        [HttpPost]
        public HttpResponseMessage Autenticado(QueryPaginacaoDTO dto)
        {
            #region IsDebuggingEnabled
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                return RetornarSucesso("Usuário autenticado com sucesso!");
            }
            #endregion

            if (RequestContext.Principal.Identity.IsAuthenticated)
            {
                return RetornarSucesso("Usuário autenticado com sucesso!", conteudo: RequestContext.Principal.Identity.Name);
            }

            return RetornarSemAutorizacao("Usuário não está autenticado. Faça novamente o login!");

        }
    }
}