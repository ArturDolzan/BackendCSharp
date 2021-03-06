﻿using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public interface IServCidades : IServicoBase<Cidades>
    {
        List<Cidades> ListarFiltro(QueryParamsDTO dto);
    }
}
