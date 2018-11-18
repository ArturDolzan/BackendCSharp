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
using BackendCSharpOAuth.Infra.Extensao;

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

                return RetornarSucesso("Registros recuperados com sucesso!", ret);
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Salvar(TEntidade entidade)
        {
            try
            {
                var retorno = Servico.Salvar(entidade);

                return RetornarSucesso("Registro salvo com sucesso!", retorno);
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Remover(TEntidade entidade)
        {
            try
            {
                var retorno = Servico.Remover(entidade);

                return RetornarSucesso("Registro removido com sucesso!", retorno);
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        #region Respostas
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
        #endregion
    }
}