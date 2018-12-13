using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendCSharpOAuth.Infra.Extensao;

namespace BackendCSharpOAuth.Dominio.Base
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade: IdentificadorBase
    {
        public readonly IRepositorioBase<TEntidade> Repositorio;

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
            return Repositorio.Recuperar().OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }

        public virtual int RecuperarTotal()
        {
            return Repositorio.Recuperar().Count();
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
                    throw new Exception(e.TratarErro());
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
                    throw new Exception(e.TratarErro());
                }
            }

            return (TEntidade)ent;
        }
        #endregion

    }
}
