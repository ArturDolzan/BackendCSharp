using BackendCSharpOAuth.Api.Mensageria;
using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Dominio.Mensageria;
using BackendCSharpOAuth.Infra;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Api
{
    public class ChatHub: Hub
    {        
        public override System.Threading.Tasks.Task OnConnected()
        {
            var nome = RecuperarUsuarioContextoPorCookie();

            Clients.All.NotificarUsuarioConectou();

            UserHandler.Add(Context.ConnectionId, nome);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Clients.All.NotificarUsuarioDesconectou();

            UserHandler.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            var nome = RecuperarUsuarioContextoPorCookie();

            Clients.All.NotificarUsuarioConectou();

            UserHandler.Add(Context.ConnectionId, nome);
            return base.OnReconnected();
        }

        public void EnviarMensagemParaTodos(string message)
        {
            //Clients.All.Publicar(name, message);
        }

        public void EnviarMensagemParaUsuario(string usuarioOrigem, string usuarioDestino, string message)
        {
            var users = UserHandler.RecuperarConnectionsIdPorUsuario(usuarioDestino);

            var servicoChat = ServiceLocatorResolver.Resolve<IServChat>();
            var chat = servicoChat.EnviarMensagem(new EnviarMensagemCargaDTO()
            {
                UsuarioOrigem = usuarioOrigem,
                UsuarioDestino = usuarioDestino,
                Mensagem = message
            });

            foreach (var item in users)
            {
                Clients.Client(item.ConnectionId).PublicarParaUsuario(chat);
            }           
        }

        public void EnviarDigitandoMensagem(string usuarioOrigem, string usuarioDestino)
        {
            var users = UserHandler.RecuperarConnectionsIdPorUsuario(usuarioDestino);
            
            foreach (var item in users)
            {
                Clients.Client(item.ConnectionId).EnviarDigitando(usuarioOrigem);
            }
        }

        public string RecuperarUsuarioContextoPorCookie()
        {
            string nome;
            try
            {
                nome = Context.Request.Cookies["AppUser"].Value;
            }
            catch (Exception)
            {
                nome = "NaoAutenticado";
            }


            if (string.IsNullOrEmpty(nome))
            {
                nome = "NaoAutenticado";
            }

            return nome;
        }
    
    }

}