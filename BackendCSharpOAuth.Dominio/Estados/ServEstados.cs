using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServEstados : ServicoBase<Estados>, IServEstados
    {
        public ServEstados(IRepEstados repositorio)
            : base(repositorio)
        {
        }

        public List<Estados> ListarFiltro(QueryParamsDTO dto)
        {
            return Repositorio.Recuperar().Where(x => x.Nome.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) || 
                                                      x.Sigla.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()))
                                                      .OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }
    }
}
