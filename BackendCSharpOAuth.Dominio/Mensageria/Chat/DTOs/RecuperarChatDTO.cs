using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Mensageria
{
    public class RecuperarChatDTO
    {
        public int Id { get; set; }

        public string UsuarioOrigem { get; set; }

        public string UsuarioDestino { get; set; }

        public DateTime DataHora { get; set; }

        public string Mensagem { get; set; }

        public EnumChatVisualizado Visualizado { get; set; }

        public string FotoOrigem { get; set; }

        public string FotoDestino { get; set; }
    }
}
