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

namespace BackendCSharpOAuth.Api.Controllers.Mensageria
{
    public class ChatController : ControllerBase<Chat>
    {
        public ChatController(IServChat servChat)
            : base(servChat)
        {
        }

        [HttpPost]
        public HttpResponseMessage RecuperarChat(RecuperarChatCargaDTO dto)
        {
            try
            {
                var ret = GetServico<IServChat>().RecuperarChat(dto);

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