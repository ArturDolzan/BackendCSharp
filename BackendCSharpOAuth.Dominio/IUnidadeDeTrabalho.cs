using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public interface IUnidadeDeTrabalho<TEntidade> where TEntidade : class
    {
        DbSet<TEntidade> Entidade
        {
            get;
            set;
        }

        int PersistirTransacao();
        void RejeitarTransacao();
        DbContextTransaction CriarTransacaoEmEscopo();
    }
}
