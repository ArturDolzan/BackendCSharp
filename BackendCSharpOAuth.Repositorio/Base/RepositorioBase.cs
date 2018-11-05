using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public class RepositorioBase<TEntidade> : BancoContext<TEntidade>, IRepositorioBase<TEntidade> where TEntidade: class 
    {      
        #region recuperar
        public virtual IQueryable<TEntidade> Recuperar()
        {
            return Entidade.AsQueryable<TEntidade>();
        }

        public IQueryable<TEntidade> Recuperar(string includes)
        {
            if (includes.ToUpper().Trim().IndexOf("ASNOTRACKING") != -1)
            {
                return RecuperarAsNoTracking(includes);
            }

            return Entidade.Include(includes).AsQueryable<TEntidade>();
        }

        private IQueryable<TEntidade> RecuperarAsNoTracking(string includes)
        {
            var inc = includes.ToUpper().Trim().Replace("ASNOTRACKING", "");

            if (string.IsNullOrEmpty(inc))
            {
                return Entidade.AsNoTracking().AsQueryable<TEntidade>();
            }
            else
            {
                return Entidade.AsNoTracking().Include(inc).AsQueryable<TEntidade>();
            } 
        }
        #endregion

        #region crud
        public virtual void ChangeObjectState(object entidade, EntityState state)
        {
            ((IObjectContextAdapter)this)
                            .ObjectContext
                            .ObjectStateManager
                            .ChangeObjectState(entidade, state);

        }

        public virtual TEntidade Salvar(TEntidade entidade)
        {
            return this.Entidade.Add(entidade);
        }

        public virtual TEntidade Atualizar(TEntidade entidade)
        {
            var entry = this.Entry(entidade);

            if (entry.State == EntityState.Detached)
                this.Entidade.Attach(entidade);

            ChangeObjectState(entidade, EntityState.Modified);

            return entidade;
        }

        public virtual TEntidade Remover(TEntidade entidade)
        {
            var entry = this.Entry(entidade);

            if (entry.State == EntityState.Detached)
                this.Entidade.Attach(entidade);

            ChangeObjectState(entidade, EntityState.Deleted);

            return entidade;
        }
        #endregion
    }
}
