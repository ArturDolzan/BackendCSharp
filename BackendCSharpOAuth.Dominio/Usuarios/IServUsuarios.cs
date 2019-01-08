using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public interface IServUsuarios : IServicoBase<Usuarios>
    {
        Usuarios RecuperarUsuarioParaToken(string usuario, string senha);
        List<Usuarios> ListarFiltro(QueryParamsDTO dto);
    }
}
