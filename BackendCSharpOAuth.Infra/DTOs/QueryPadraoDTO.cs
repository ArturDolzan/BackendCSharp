using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Infra.DTOs
{
    public class QueryPadraoDTO
    {
        public int Id { get; set; }

        public string[] Includes { get; set; }
    }
}