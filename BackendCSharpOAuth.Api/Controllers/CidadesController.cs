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
    public class CidadesController : ControllerBase<Cidades>
    {
        private readonly IServCidades _servCidades;

        public CidadesController(IServCidades servCidades, IServCidades iservCidades)
            : base(servCidades)
        {
            _servCidades = iservCidades;
        }

        [HttpPost]
        public virtual HttpResponseMessage Filtrar(QueryParamsDTO dto)
        {
            try
            {
                var ret = _servCidades.ListarFiltro(dto);

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = ret.Count });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }
    }
}