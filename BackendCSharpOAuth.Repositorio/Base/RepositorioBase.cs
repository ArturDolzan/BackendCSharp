using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public class RepositorioBase<TEntidade> : BancoContext<TEntidade>, IRepositorioBase<TEntidade> where TEntidade: IdentificadorBase 
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
        public void ChangeObjectState(object entidade, EntityState state)
        {
            ((IObjectContextAdapter)this)
                            .ObjectContext
                            .ObjectStateManager
                            .ChangeObjectState(entidade, state);

        }

        public virtual TEntidade Salvar(TEntidade entidade)
        {
            var registro = Recuperar("AsNoTracking").Where(x => x.Id == entidade.Id).FirstOrDefault();

            if (registro == null)
            {
                return this.Entidade.Add(entidade);
            }
            else
            {
                return this.Atualizar(entidade);
            }
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
            var registro = Recuperar("AsNoTracking").Where(x => x.Id == entidade.Id).FirstOrDefault();

            if (registro == null)
            {
                throw new Exception("A entidade nao foi encontrada para remover!");
            }

            var entry = this.Entry(entidade);

            if (entry.State == EntityState.Detached)
                this.Entidade.Attach(entidade);

            ChangeObjectState(entidade, EntityState.Deleted);

            return entidade;
        }

        public virtual TEntidade RecuperarNovo()
        {
            return Activator.CreateInstance<TEntidade>();
        }
        #endregion
    }
}
