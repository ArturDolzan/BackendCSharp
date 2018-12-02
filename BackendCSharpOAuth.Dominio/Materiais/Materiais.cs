using BackendCSharpOAuth.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class Materiais : IdentificadorBase
    {
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public string Observacao { get; set; }

        public EnumMateriaisAtivo Ativo { get; set; }
    }

    public enum EnumMateriaisAtivo
    {
        [Description("Ativo")]
        Ativo = 1,

        [Description("Desativado")]
        Desativado = 2
    }
}
