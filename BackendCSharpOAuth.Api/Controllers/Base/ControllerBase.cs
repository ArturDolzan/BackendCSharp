using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using System.Net.Http;
using System.Web.Http;
using BackendCSharpOAuth.Infra.Extensao;

namespace BackendCSharpOAuth.Api.Controllers.Base
{
    #if !DEBUG
        [Authorize]
    #endif
    public class ControllerBase<TEntidade> : ControllerResposta where TEntidade: IdentificadorBase
    {
        public readonly IServicoBase<TEntidade> Servico;

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
        public virtual HttpResponseMessage Listar(QueryParamsDTO dto)
        {
            try
            {
                var ret = Servico.Listar(dto);
                var total = Servico.RecuperarTotal();

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = total});
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage RecuperarPorId(CodigoPadraoDTO dto)
        {
            try
            {
                var ret = Servico.RecuperarPorId(dto);

                return RetornarSucesso("Registro recuperado com sucesso!", new { Dados = ret });
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
    }
}