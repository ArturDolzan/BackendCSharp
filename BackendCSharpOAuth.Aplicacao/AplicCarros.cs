using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Aplicacao
{
    public class AplicCarros : IAplicCarros
    {
        private readonly IServCarros _servCarros;

        public AplicCarros(IServCarros servCarros)
        {
            _servCarros = servCarros;
        }

        public void Teste()
        {
            _servCarros.Teste();
        }
    }
}
