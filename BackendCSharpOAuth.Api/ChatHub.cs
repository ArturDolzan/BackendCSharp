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

            UserHandler.Add(Context.ConnectionId, nome);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            UserHandler.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override System.Threading.Tasks.Task OnReconnected()
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

            UserHandler.Add(Context.ConnectionId, nome);
            return base.OnReconnected();
        }

        public void EnviarMensagemParaTodos(string message)
        {
            //Clients.All.Publicar(name, message);
        }

        public void EnviarMensagemParaUsuario(string usuarioDestino, string message)
        {
            var users = UserHandler.RecuperarConnectionsIdPorUsuario(usuarioDestino);

            foreach (var item in users)
            {
                Clients.Client(item.ConnectionId).PublicarParaUsuario(message);
            }           
        }
    
    }

    public static class UserHandler
    {
        public static List<UserIdent> ConnectedIds = new List<UserIdent>();

        public static void Remove(string connectionId)
        {
            var t = ConnectedIds.FirstOrDefault(x => x.ConnectionId == connectionId);

            if (t != null)
            {
                ConnectedIds.Remove(t);
            }
        }

        public static void Add(string connectionId, string appUser)
        {
            Remove(connectionId);
            ConnectedIds.Add(new UserIdent()
            {
                AppUser = appUser,
                ConnectionId = connectionId
            });
        }

        public static List<UserIdent> RecuperarConnectionsIdPorUsuario(string appUser)
        {
            return ConnectedIds.Where(x => x.AppUser == appUser).ToList();
        }
    }

    public class UserIdent
    {
        public string AppUser { get; set; }
        public string ConnectionId { get; set; }
    }

}