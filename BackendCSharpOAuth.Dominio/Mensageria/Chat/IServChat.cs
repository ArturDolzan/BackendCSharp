using BackendCSharpOAuth.Api.Mensageria.DTOs;
using BackendCSharpOAuth.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Mensageria
{
    public interface IServChat : IServicoBase<Chat>
    {
        List<RecuperarChatDTO> RecuperarChat(RecuperarChatCargaDTO dto);
        RecuperarChatDTO EnviarMensagem(EnviarMensagemCargaDTO dto);
        int RecuperarMsgPendentesVisualizacao(string usuarioOrigem, string usuarioDestino);
        void MarcarMensagensVisualizadas(UsuarioChatMarcarVisualizadoDTO dto);
        byte[] RecuperarFotoUsuarioChat(string usuario);
    }
}
