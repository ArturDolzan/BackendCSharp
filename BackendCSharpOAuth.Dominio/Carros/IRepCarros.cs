﻿using BackendCSharpOAuth.Infra.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public interface IRepCarros : IRepositorioBase<Carros>
    {
        
        List<Carros> Listar(QueryPaginacaoDTO dto);
        Carros Salvar(Carros carros);
    }
}
