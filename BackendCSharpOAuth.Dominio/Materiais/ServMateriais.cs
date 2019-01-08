using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServMateriais : ServicoBase<Materiais>, IServMateriais
    {
        public ServMateriais(IRepMateriais repositorio) : base(repositorio)
        {
        }

        public List<Materiais> ListarFiltro(QueryParamsDTO dto)
        {
            return Repositorio.Recuperar().Where(x => x.Descricao.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Observacao.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Quantidade.ToString().Contains(dto.Filter) ||
                                                      x.ValorUnitario.ToString().Contains(dto.Filter)).OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }
    }
}
