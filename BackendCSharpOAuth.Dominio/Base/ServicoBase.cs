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
        public IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase()
        {
            //_repositorio = repositorio;
        }

        public List<TEntidade> Listar(QueryPaginacaoDTO dto)
        {
            return _repositorio.Recuperar().ToList();
        }
        
    }
}
