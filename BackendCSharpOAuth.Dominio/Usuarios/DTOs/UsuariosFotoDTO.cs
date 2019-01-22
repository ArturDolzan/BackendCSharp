using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class UsuariosFotoDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Foto { get; set; }
    }
}
