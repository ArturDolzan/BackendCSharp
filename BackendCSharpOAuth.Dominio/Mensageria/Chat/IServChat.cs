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
    }
}
