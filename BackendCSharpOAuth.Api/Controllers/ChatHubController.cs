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
        private readonly IRepUsuarios _repUsuarios;

        public ChatHubController(IServChat servChat, IRepUsuarios repUsuarios)
        {
            _servChat = servChat;
            _repUsuarios = repUsuarios;
        }

        [HttpPost]
        public virtual HttpResponseMessage RecuperarUsuariosConectadosChat(UsuarioChatLogadoDTO dto)
        {
            //var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            //context.Clients.All.Publicar("aa", "bb");
            //context.Clients.All.PublicarParaUsuario(new { Usuario = "a", Mensagem = "b" });
            try
            {
                var ret = UserHandler.ConnectedIds.ToList();

                foreach (var item in ret)
                {

                    var usuario = _repUsuarios
                                  .Recuperar(new string[] { "AsNoTracking" })
                                  .Where(x => x.Nome == item.AppUser)
                                  .Select(s => new { s.Id, s.Foto })
                                  .FirstOrDefault();

                    item.QtdeMsgNaoVisualizadas = _servChat.RecuperarMsgPendentesVisualizacao(item.AppUser, dto.Usuario);

                    if (usuario.Foto != null)
                    {
                        item.Foto = @"\tmp\fotos\" + item.AppUser + ".jpg";    
                    }                    
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