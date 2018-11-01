using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio
{
    public class RepCarros : IRepCarros
    {
        private BancoContext _entidades;
        protected BancoContext entidades
        {
            get
            {
                if (_entidades == null)
                {
                    _entidades = new BancoContext();
                }
                return _entidades;
            }
        }

        public List<Carros> Listar(QueryPaginacaoDTO dto)
        {
            return entidades.Carros.OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }
    }
}
