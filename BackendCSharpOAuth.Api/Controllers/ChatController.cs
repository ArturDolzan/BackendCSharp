using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Dominio.Mensageria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BackendCSharpOAuth.Infra.Extensao;

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
    }
}