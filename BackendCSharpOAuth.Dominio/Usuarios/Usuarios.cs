using BackendCSharpOAuth.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class Usuarios : IdentificadorBase
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuariosAdm TipoUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public byte[] Foto { get; set; }
    }

    public enum EnumTipoUsuariosAdm
    {
        [Description("Administrador")]
        Administrador = 1,

        [Description("Comum")]
        Comum = 2
    }
}
