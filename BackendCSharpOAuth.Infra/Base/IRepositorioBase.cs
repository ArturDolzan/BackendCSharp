using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Infra.Base
{
    public interface IRepositorioBase<TEntidade> where TEntidade: class
    {
        IQueryable<TEntidade> Recuperar();
        IQueryable<TEntidade> Recuperar(string includes);
    }
}
