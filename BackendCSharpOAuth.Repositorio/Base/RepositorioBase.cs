using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public class RepositorioBase<T> : IRepositorioBase<T>
    {
        public BancoContext _entidades;
        public BancoContext entidades
        {
            get
            {
                if (_entidades == null)
                {
                    _entidades = new BancoContext();
                }
                return _entidades;
            }
        }

       // public IQueryable<T> Recuperar(string includes) where T : class
      //  {
      //      return entidades.Set<T>().AsQueryable<T>();
      //  }
    }
}
