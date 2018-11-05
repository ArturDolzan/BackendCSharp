using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Dominio
{
    public interface IServCarros
    {
        List<Carros> Listar(QueryPaginacaoDTO dto);
        Carros Salvar(Carros carros);
        Carros Remover(Carros carros);
       /* List<Carros> PesquisarCarro(PesquisaDTO dto);
        TotalPaginacaoDTO RecuperarTotalRegistros();
        TotalPaginacaoDTO RecuperarTotalRegistrosFiltro(PesquisaDTO dto);
        List<Carros> Listar(QueryPaginacaoDTO dto);
        List<Carros> ListarSearchField();
        Carros Salvar(Carros carros);
        Carros RecuperarPorId(CodigoPadraoDTO dto);
        void Remover(CodigoPadraoDTO dto);*/
    }
}