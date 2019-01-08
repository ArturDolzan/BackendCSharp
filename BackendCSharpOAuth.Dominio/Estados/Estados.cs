using BackendCSharpOAuth.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class Estados : IdentificadorBase
    {
        public string Nome { get; set; }

        public string Sigla { get; set; }
    }
}
