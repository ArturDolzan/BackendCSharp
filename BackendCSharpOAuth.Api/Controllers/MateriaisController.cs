using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BackendCSharpOAuth.Infra.Extensao;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class MateriaisController : ControllerBase<Materiais>
    {
        private readonly IServMateriais _servMateriais;

        public MateriaisController(IServMateriais servMateriais, IServMateriais iservMateriais)
            : base(servMateriais)
        {
            _servMateriais = iservMateriais;
        }

        [HttpPost]
        public virtual HttpResponseMessage Filtrar(QueryPaginacaoDTO dto)
        {
            try
            {
                var ret = _servMateriais.ListarFiltro(dto);                

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = ret.Count });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }
    }
}