using BackendCSharpOAuth.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Mensageria
{
    public class Chat : IdentificadorBase
    {
        public string UsuarioOrigem { get; set; }

        public string UsuarioDestino { get; set; }

        public DateTime DataHora { get; set; }

        public string Mensagem { get; set; }

        public EnumChatVisualizado Visualizado { get; set; }
    }

    public enum EnumChatVisualizado
    {
        [Description("Visualizado")]
        Viualizado = 1,

        [Description("Não visualizado")]
        NaoVisualizado = 0
    }
}
