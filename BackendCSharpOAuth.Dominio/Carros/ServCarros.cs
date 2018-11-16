using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Dominio
{
    public class ServCarros : ServicoBase<Carros>, IServCarros
    {        
        public ServCarros(IRepCarros repositorio): base(repositorio) 
        {
        }
    }
}