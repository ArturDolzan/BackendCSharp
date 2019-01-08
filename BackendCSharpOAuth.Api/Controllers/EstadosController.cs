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
    public class EstadosController : ControllerBase<Estados>
    {
        private readonly IServEstados _servEstados;

        public EstadosController(IServEstados servEstados, IServEstados iservEstados)
            : base(servEstados)
        {
            _servEstados = iservEstados;
        }

        [HttpPost]
        public virtual HttpResponseMessage Filtrar(QueryParamsDTO dto)
        {
            try
            {
                var ret = _servEstados.ListarFiltro(dto);

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = ret.Count });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }
    }
}