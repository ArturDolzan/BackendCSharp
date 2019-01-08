using BackendCSharpOAuth.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServCidades : ServicoBase<Cidades>, IServCidades
    {
        public ServCidades(IRepCidades repositorio)
            : base(repositorio)
        {
        }
    }
}
