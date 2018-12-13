using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Infra.Base.Query
{
    public class MontaQuery<TEntidade> where TEntidade: IdentificadorBase
    {
        public IQueryable<TEntidade> Monta(Filtros filtros, IQueryable<TEntidade> query) 
        {
            return query;
        }
    }
}
