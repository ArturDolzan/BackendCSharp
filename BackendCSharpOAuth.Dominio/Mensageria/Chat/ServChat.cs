using BackendCSharpOAuth.Api.Mensageria.DTOs;
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
        private readonly IRepUsuarios _repUsuarios;

        public ServChat(IRepChat repositorio, IRepUsuarios repUsuarios)
            : base(repositorio)
        {
            _repUsuarios = repUsuarios;
        }

        public List<RecuperarChatDTO> RecuperarChat(RecuperarChatCargaDTO dto)
        {
            var listaChat = new List<RecuperarChatDTO>();

            var ret = GetRepositorio<IRepChat>()
                      .Recuperar(new string[] { "AsNoTracking" })
                      .Where(x => (x.UsuarioOrigem == dto.UsuarioOrigem && x.UsuarioDestino == dto.UsuarioDestino) ||
                                  (x.UsuarioOrigem == dto.UsuarioDestino && x.UsuarioDestino == dto.UsuarioOrigem))
                      .OrderByDescending(x => x.Id).Take(20)
                      .ToList();

            foreach (var item in ret.OrderBy(x => x.Id))
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

        public RecuperarChatDTO EnviarMensagem(EnviarMensagemCargaDTO dto)
        {
             var ret = Salvar(new Chat()
            {
                Id = 0,
                UsuarioOrigem = dto.UsuarioOrigem,
                UsuarioDestino = dto.UsuarioDestino,
                Mensagem = dto.Mensagem,
                DataHora = DateTime.Now,
                Visualizado = EnumChatVisualizado.NaoVisualizado
            });

            return new RecuperarChatDTO()
            {
                Id = ret.Id,
                UsuarioOrigem = ret.UsuarioOrigem,
                UsuarioDestino = ret.UsuarioDestino,
                DataHora = ret.DataHora,
                Mensagem = ret.Mensagem,
                Visualizado = ret.Visualizado,
                CaminhoFoto = "assets/user2-160x160.jpg"
            };
        }

        public int RecuperarMsgPendentesVisualizacao(string usuarioOrigem, string usuarioDestino)
        {
            var registro = GetRepositorio<IRepChat>()
                            .Recuperar(new string[] { "AsNoTracking" })
                            .Where(x => x.UsuarioOrigem == usuarioOrigem 
                                        && x.UsuarioDestino == usuarioDestino 
                                        && x.Visualizado == EnumChatVisualizado.NaoVisualizado)
                            .GroupBy(g => new { g.UsuarioOrigem })
                            .Select(g => new { g.Key.UsuarioOrigem, Qtde = g.Count() })
                            .FirstOrDefault();

            if (registro == null)
            {
                return 0;
            }

            return registro.Qtde;
        }

        public void MarcarMensagensVisualizadas(UsuarioChatMarcarVisualizadoDTO dto)
        {
            var registros = GetRepositorio<IRepChat>()
                            .Recuperar()
                            .Where(x => x.UsuarioOrigem == dto.UsuarioOrigem && x.UsuarioDestino == dto.UsuarioDestino && x.Visualizado == EnumChatVisualizado.NaoVisualizado).ToList();

            foreach (var item in registros)
            {
                item.Visualizado = EnumChatVisualizado.Viualizado;

                Salvar(item);
            }

        }

        public byte[] RecuperarFotoUsuarioChat(string usuario)
        {
            var user = _repUsuarios
                      .Recuperar(new string[] { "AsNoTracking" })
                      .Where(x => x.Nome == usuario)
                      .Select(s => new { s.Id, s.Foto })
                      .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user.Foto;
        }

    }
}
