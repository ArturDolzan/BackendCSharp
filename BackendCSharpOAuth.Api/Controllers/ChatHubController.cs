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
using Microsoft.AspNet.SignalR;
using BackendCSharpOAuth.Api.Mensageria;
using BackendCSharpOAuth.Dominio.Mensageria;
using BackendCSharpOAuth.Api.Mensageria.DTOs;

namespace BackendCSharpOAuth.Api.Controllers
{

    public class ChatHubController : ControllerResposta
    {
        private readonly IServChat _servChat;

        public ChatHubController(IServChat servChat)
        {
            _servChat = servChat;
        }

        [HttpPost]
        public virtual HttpResponseMessage Postar()
        {
            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                //context.Clients.All.Publicar("aa", "bb");
                context.Clients.All.PublicarParaUsuario(new { Usuario = "a", Mensagem = "b" });

                return RetornarSucesso("Ok!");
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage RecuperarUsuariosConectadosChat(UsuarioChatLogadoDTO dto)
        {
            try
            {
                var ret = UserHandler.ConnectedIds.ToList();

                foreach (var item in ret)
                {
                    item.QtdeMsgNaoVisualizadas = _servChat.RecuperarMsgPendentesVisualizacao(item.AppUser, dto.Usuario);
                }

                return RetornarSucesso("Usuários chat recuperados com sucesso!", new { Dados = ret });
            }
            catch (System.Exception e)
            {
                return RetornarErro(e.TratarErro());
            }
        }
        
    }
}