using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class UsuariosCargaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuariosAdm TipoUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Foto { get; set; }
    }
}
