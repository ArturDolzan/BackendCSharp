using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Dominio.Mensageria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BackendCSharpOAuth.Infra.Extensao;
using BackendCSharpOAuth.Api.Mensageria.DTOs;
using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Api.Mensageria;

namespace BackendCSharpOAuth.Api.Controllers.Mensageria
{
    public class ChatController : ControllerBase<Chat>
    {
        private readonly IServUsuarios _servUsuarios;

        public ChatController(IServChat servChat, IServUsuarios servUsuarios)
            : base(servChat)
        {
            _servUsuarios = servUsuarios;
        }

        [HttpPost]
        public HttpResponseMessage RecuperarChat(RecuperarChatCargaDTO dto)
        {
            try
            {
                var ret = GetServico<IServChat>().RecuperarChat(dto);

                foreach (var item in ret)
                {
                    var userDest = _servUsuarios.RecuperarPorUsuario(new NomeUsuarioDTO() { Usuario = item.UsuarioDestino });

                    if (userDest.Foto != null)
                    {
                        var diretorioUsuarioHelper = new DiretorioUsuarioHelper();
                        diretorioUsuarioHelper.CriarFotoUsuarioDiretorioTemp(userDest, false);
                    }
                }

                return RetornarSucesso("Registros recuperados com sucesso!", new { Dados = ret});
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage MarcarMensagensVisualizadas(UsuarioChatMarcarVisualizadoDTO dto)
        {
            try
            {
                GetServico<IServChat>().MarcarMensagensVisualizadas(dto);

                return RetornarSucesso("Mensagens marcadas como visualizadas com sucesso!");
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }
    }
}