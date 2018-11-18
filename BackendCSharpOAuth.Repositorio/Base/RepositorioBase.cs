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

        public virtual IQueryable<TEntidade> RecuperarPorId(int id)
        {
            return Entidade.AsQueryable<TEntidade>().Where(x=>x.Id == id);
        }

        public virtual IQueryable<TEntidade> Recuperar(string[] includes)
        {
            var noTrack = includes.Where(x=> string.Format("AsNoTracking").ToUpper().Trim().Contains(x.ToUpper().Trim())).Any();

            if (noTrack)
            {
                return RecuperarAsNoTracking(includes);
            }

            string aincludes = "";
            foreach (var item in includes)
            {
                if (item.ToUpper().Trim() != "ASNOTRACKING")
                {
                    if (string.IsNullOrEmpty(aincludes))
                    {
                        aincludes = item;
                    }
                    else
                    {
                        aincludes = aincludes + string.Format(", {0}", item);
                    }
                }
            }

            return Entidade.Include(aincludes).AsQueryable<TEntidade>();
        }

        private IQueryable<TEntidade> RecuperarAsNoTracking(string[] includes)
        {
            string aincludes = "";
            foreach (var item in includes)
            {
                if (item.ToUpper().Trim() != "ASNOTRACKING")
                {
                    if (string.IsNullOrEmpty(aincludes))
                    {
                        aincludes = item;
                    }
                    else
                    {
                        aincludes = aincludes + string.Format(", {0}", item);
                    }
                }
            }

            if (string.IsNullOrEmpty(aincludes))
            {
                return Entidade.AsNoTracking().AsQueryable<TEntidade>();
            }

            return Entidade.AsNoTracking().Include(aincludes).AsQueryable<TEntidade>();
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
            var registro = Recuperar(new string[] { "AsNoTracking"} ).Where(x => x.Id == entidade.Id).FirstOrDefault();

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
            var registro = Recuperar(new string[] { "AsNoTracking" }).Where(x => x.Id == entidade.Id).FirstOrDefault();

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
