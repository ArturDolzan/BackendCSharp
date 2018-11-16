using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Base
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade: IdentificadorBase
    {
        private readonly IRepositorioBase<TEntidade> Repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            Repositorio = repositorio;
        }

        public IRepositorioBase<TEntidade> GetRepositorio()
        {
            return Repositorio as IRepositorioBase<TEntidade>;
        }

        public TRepositorio GetRepositorio<TRepositorio>()
        {
            return (TRepositorio)Repositorio;
        }

        #region recuperar
        public virtual List<TEntidade> Listar(QueryPaginacaoDTO dto)
        {
            return Repositorio.Recuperar().ToList();
        }
        #endregion


        #region crud
        public virtual TEntidade Salvar(TEntidade entidade)
        {
            var ent = new object();
            using (var transaction = GetRepositorio().CriarTransacaoEmEscopo())
            {
                try
                {
                    ent = Repositorio.Salvar(entidade);
                    Repositorio.PersistirTransacao();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }

            return (TEntidade)ent;
        }

        public virtual TEntidade Remover(TEntidade entidade)
        {
            var ent = new object();
            using (var transaction = GetRepositorio().CriarTransacaoEmEscopo())
            {
                try
                {
                    ent = Repositorio.Remover(entidade);
                    Repositorio.PersistirTransacao();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }

            return (TEntidade)ent;
        }
        #endregion

    }
}
