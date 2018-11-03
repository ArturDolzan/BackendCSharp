using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public class RepositorioBase
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

       
    }
}
