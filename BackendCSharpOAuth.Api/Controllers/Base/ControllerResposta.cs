using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackendCSharpOAuth.Api.Controllers.Base
{
    public class ControllerResposta : ApiController
    {
        public virtual HttpResponseMessage RetornarSucesso(string mensagem)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = mensagem });
        }

        public virtual HttpResponseMessage RetornarSucesso(string mensagem, object conteudo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = mensagem, Content = conteudo });
        }

        public virtual HttpResponseMessage RetornarErro(string mensagem)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = mensagem });
        }

        public virtual HttpResponseMessage RetornarErro(string mensagem, object conteudo)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = mensagem, Content = conteudo });
        }

        public virtual HttpResponseMessage RetornarSemAutorizacao(string mensagem)
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Mensagem = mensagem });
        }
    }
}