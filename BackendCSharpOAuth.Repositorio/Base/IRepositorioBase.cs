using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public interface IRepositorioBase<T>
    {
        BancoContext entidades
        {
            get;
        }
    }
}
