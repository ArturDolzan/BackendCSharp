using BackendCSharpOAuth.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class Cidades : IdentificadorBase
    {
        public string Nome { get; set; }

        public int CodigoIbge { get; set; }

        public int CodigoEstado { get; set; }

        public int Populacao2010 { get; set; }

        public decimal DensidadeDemo { get; set; }

        public string Gentilico { get; set; }

        public decimal Area { get; set; }

        public Estados Estados { get; set; }
    }
}
