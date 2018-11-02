using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using BackendCSharpOAuth.Repositorio.Base;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio
{
    public class RepCarros : RepositorioBase, IRepCarros
    {
        public List<Carros> Listar(QueryPaginacaoDTO dto)
        {
            return entidades.Carros.OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }
    }
}
