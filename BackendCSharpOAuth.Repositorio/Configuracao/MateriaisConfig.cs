using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Configuracao
{
    public class MateriaisConfig : EntityTypeConfiguration<Materiais>, IMapping
    {
        public MateriaisConfig()
        {
            this.ToTable("Materiais");

            this.HasKey<int>(s => s.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            this.Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            this.Property(p => p.ValorUnitario)
                .HasColumnName("Valor_unitario")
                .IsRequired();

            this.Property(p => p.Observacao)
                .HasColumnName("Observacao");

            this.Property(p => p.Ativo)
                .HasColumnName("Ativo")
                .IsRequired();
        }
    }
}
