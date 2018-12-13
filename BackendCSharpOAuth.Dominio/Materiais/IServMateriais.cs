using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public interface IServMateriais : IServicoBase<Materiais>
    {
        List<Materiais> ListarFiltro(QueryPaginacaoDTO dto);
    }
}
