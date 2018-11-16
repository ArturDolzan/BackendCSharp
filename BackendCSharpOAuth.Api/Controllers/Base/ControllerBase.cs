using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackendCSharpOAuth.Api.Controllers.Base
{
    #if !DEBUG
        [Authorize]
    #endif
    public class ControllerBase<TEntidade> : ApiController where TEntidade: IdentificadorBase
    {
        private readonly IServicoBase<TEntidade> Servico;

        public ControllerBase(IServicoBase<TEntidade> servico)
        {
            Servico = servico;
        }

        public IServicoBase<TEntidade> GetServico()
        {
            return Servico as IServicoBase<TEntidade>;
        }

        public TServico GetServico<TServico>()
        {
            return (TServico)Servico;
        }

        [HttpPost]
        public virtual HttpResponseMessage Listar(QueryPaginacaoDTO dto)
        {
            try
            {
                var ret = Servico.Listar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Registros recuperados com sucesso!", Content = ret });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Salvar(TEntidade entidade)
        {
            try
            {
                var retorno = Servico.Salvar(entidade);

                return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro salvo com sucesso!" });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Remover(TEntidade entidade)
        {
            try
            {
                var retorno = Servico.Remover(entidade);

                return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro removido com sucesso!" });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }
    }
}