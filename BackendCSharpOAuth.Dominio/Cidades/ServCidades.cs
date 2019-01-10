using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServCidades : ServicoBase<Cidades>, IServCidades
    {
        public ServCidades(IRepCidades repositorio)
            : base(repositorio)
        {
        }

        public List<Cidades> ListarFiltro(QueryParamsDTO dto)
        {

            if (dto.Includes != null)
            {
                return Repositorio.Recuperar(dto.Includes).Where(x => x.Nome.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.CodigoIbge.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Populacao2010.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.DensidadeDemo.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Gentilico.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Area.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()))
                                                      .OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();                
            }

            return Repositorio.Recuperar().Where(x => x.Nome.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.CodigoIbge.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Populacao2010.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.DensidadeDemo.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Gentilico.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) ||
                                                      x.Area.ToString().ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()))
                                                      .OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
            
        }
    }
}
