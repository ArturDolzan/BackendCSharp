using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Api.Mensageria
{
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
        public int QtdeMsgNaoVisualizadas { get; set; }
        public byte[] Foto { get; set; }
    }
}