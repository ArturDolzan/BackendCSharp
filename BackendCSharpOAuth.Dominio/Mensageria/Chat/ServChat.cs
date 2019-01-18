using BackendCSharpOAuth.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Mensageria
{
    class ServChat: ServicoBase<Chat>, IServChat
    {
        public ServChat(IRepChat repositorio)
            : base(repositorio)
        {
        }

        public List<RecuperarChatDTO> RecuperarChat(RecuperarChatCargaDTO dto)
        {
            var listaChat = new List<RecuperarChatDTO>();

            var ret = GetRepositorio<IRepChat>()
                      .Recuperar()
                      .Where(x => (x.UsuarioOrigem == dto.UsuarioOrigem && x.UsuarioDestino == dto.UsuarioDestino) ||
                                  (x.UsuarioOrigem == dto.UsuarioDestino && x.UsuarioDestino == dto.UsuarioOrigem))
                      .OrderBy(x => x.DataHora).Take(20)
                      .ToList();

            foreach (var item in ret)
            {
                listaChat.Add(new RecuperarChatDTO()
                {
                    Id = item.Id,
                    UsuarioOrigem = item.UsuarioOrigem,
                    UsuarioDestino = item.UsuarioDestino,
                    DataHora = item.DataHora,
                    Mensagem = item.Mensagem,
                    Visualizado = item.Visualizado,
                    CaminhoFoto = "assets/user2-160x160.jpg"
                });
            }

            return listaChat;
        }
    }
}
