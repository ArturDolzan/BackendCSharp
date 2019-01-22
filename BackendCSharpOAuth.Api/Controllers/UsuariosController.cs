using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BackendCSharpOAuth.Infra.Extensao;
using System.IO;
using BackendCSharpOAuth.Api.Mensageria;

namespace BackendCSharpOAuth.Api.Controllers
{
    #if !DEBUG
            [Authorize]
    #endif
    public class UsuariosController : ControllerResposta
    {
        private readonly IServUsuarios _servUsuarios;

        public UsuariosController(IServUsuarios servUsuarios)
        {
            _servUsuarios = servUsuarios;
        }

        [HttpPost]
        public HttpResponseMessage Autenticado()
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

        [HttpPost]
        public virtual HttpResponseMessage Listar(QueryParamsDTO dto)
        {
            try
            {
                var ret = _servUsuarios.Listar(dto);

                foreach (var item in ret)
                {
                    item.Foto = null;
                }

                var total = _servUsuarios.RecuperarTotal();

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = total });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Salvar(UsuariosCargaDTO entidade)
        {
            try
            {
                byte[] foto = null;

                if (entidade.Foto != null)
                {
                    foto = Convert.FromBase64String(entidade.Foto);
                }

                var retorno = _servUsuarios.Salvar(new Usuarios() 
                { Id = entidade.Id, 
                  Nome = entidade.Nome, 
                  NomeCompleto = entidade.NomeCompleto, 
                  Senha = entidade.Senha, 
                  TipoUsuario = entidade.TipoUsuario ,
                  Foto = foto
                });

                var diretorioUsuarioHelper = new DiretorioUsuarioHelper();
                diretorioUsuarioHelper.CriarFotoUsuarioDiretorioTemp(retorno, true);

                return RetornarSucesso("Registro salvo com sucesso!", retorno);
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Remover(Usuarios entidade)
        {
            try
            {
                var retorno = _servUsuarios.Remover(entidade);

                return RetornarSucesso("Registro removido com sucesso!", retorno);
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Filtrar(QueryParamsDTO dto)
        {
            try
            {
                var ret = _servUsuarios.ListarFiltro(dto);

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret, Total = ret.Count });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage RecuperarPorId(QueryPadraoDTO dto)
        {
            try
            {
                var ret = _servUsuarios.RecuperarPorId(dto);

                return RetornarSucesso("Registro recuperado com sucesso!", new { Dados = ret });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage RecuperarPorUsuario(NomeUsuarioDTO dto)
        {
            try
            {
                var ret = _servUsuarios.RecuperarPorUsuario(dto);
                
                var diretorioUsuarioHelper = new DiretorioUsuarioHelper();
                var user = diretorioUsuarioHelper.CriarFotoUsuarioDiretorioTemp(ret, false);

                return RetornarSucesso("Registro recuperado com sucesso!", new { Dados = user });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

    }
}