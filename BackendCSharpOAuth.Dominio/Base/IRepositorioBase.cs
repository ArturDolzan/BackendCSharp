using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Base
{
    public interface IRepositorioBase<TEntidade> : IUnidadeDeTrabalho<TEntidade> where TEntidade: class
    {        
        IQueryable<TEntidade> Recuperar();
        IQueryable<TEntidade> Recuperar(string includes);

        TEntidade Salvar(TEntidade entidade);
        TEntidade Atualizar(TEntidade entidade);
        TEntidade Remover(TEntidade entidade);
    }
}
