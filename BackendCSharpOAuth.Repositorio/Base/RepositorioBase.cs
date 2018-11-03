using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public class RepositorioBase
    {
        private BancoContext _entidades;
        protected BancoContext entidades
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

        public BancoContext GetRepositorio()
        {
            return entidades;
        }
    }
}
