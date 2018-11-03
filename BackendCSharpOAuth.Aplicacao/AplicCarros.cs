using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Aplicacao
{
    public class AplicCarros : IAplicCarros
    {
        private readonly IServCarros _servCarros;

        public AplicCarros(IServCarros servCarros)
        {
            _servCarros = servCarros;
        }

        public List<Carros> Listar(QueryPaginacaoDTO dto)
        {
            return _servCarros.Listar(dto);
        }

        public Carros Salvar(Carros carros)
        {
           
            return _servCarros.Salvar(carros);
        }
    }
}
