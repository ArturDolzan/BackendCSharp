using BackendCSharpOAuth.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServUsuarios : ServicoBase<Usuarios>, IServUsuarios
    {
        public ServUsuarios(IRepUsuarios repositorio) :base(repositorio)
        {
        }

        public Usuarios RecuperarUsuarioParaToken(string usuario, string senha)
        {
            return GetRepositorio<IRepUsuarios>()
                           .Recuperar(new string[] { "AsNoTracking" })
                           .Where(x=>x.Nome == usuario && x.Senha == senha)
                           .FirstOrDefault();
        }
    }
}
