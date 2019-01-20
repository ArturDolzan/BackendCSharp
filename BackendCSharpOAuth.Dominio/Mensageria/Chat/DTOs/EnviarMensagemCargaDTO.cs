using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Mensageria
{
    public class EnviarMensagemCargaDTO
    {
        public string UsuarioOrigem { get; set; }
        public string UsuarioDestino { get; set; }
        public string Mensagem { get; set; }
    }
}
