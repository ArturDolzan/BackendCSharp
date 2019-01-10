using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio.Base
{
    public interface IServicoBase<TEntidade> where TEntidade : IdentificadorBase
    {
        List<TEntidade> Listar(QueryParamsDTO dto);
        TEntidade RecuperarPorId(QueryPadraoDTO dto);
        TEntidade Salvar(TEntidade entidade);
        TEntidade Remover(TEntidade entidade);
        int RecuperarTotal();
    }
}
