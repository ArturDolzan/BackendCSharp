using BackendCSharpOAuth.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Base
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade: class 
    {
        #region contexto
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
        #endregion

        #region recuperar
        public virtual IQueryable<TEntidade> Recuperar()
        {
            return entidades.Set<TEntidade>().AsQueryable<TEntidade>();
        }

        public IQueryable<TEntidade> Recuperar(string includes)
        {
            if (includes.ToUpper().Trim().IndexOf("ASNOTRACKING") != -1)
            {
                return RecuperarAsNoTracking(includes);
            }

            return entidades.Set<TEntidade>().Include(includes).AsQueryable<TEntidade>();
        }

        private IQueryable<TEntidade> RecuperarAsNoTracking(string includes)
        {
            var inc = includes.ToUpper().Trim().Replace("ASNOTRACKING", "");

            if (string.IsNullOrEmpty(inc))
            {
                return entidades.Set<TEntidade>().AsNoTracking().AsQueryable<TEntidade>();
            }
            else
            {
                return entidades.Set<TEntidade>().AsNoTracking().Include(inc).AsQueryable<TEntidade>();
            } 
        }
        #endregion
    }
}
