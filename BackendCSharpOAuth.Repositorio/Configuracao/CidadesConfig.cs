using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Configuracao
{
    public class CidadesConfig : EntityTypeConfiguration<Cidades>, IMapping
    {
        public CidadesConfig()
        {
            this.ToTable("Cidades");

            this.HasKey<int>(s => s.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            this.Property(p => p.CodigoIbge)
                .HasColumnName("Codigo_ibge")
                .IsRequired();

            this.Property(p => p.CodigoEstado)
                .HasColumnName("Estado_id")
                .IsRequired();

            this.Property(p => p.Populacao2010)
                .HasColumnName("Populacao_2010")
                .IsRequired();

            this.Property(p => p.DensidadeDemo)
                .HasColumnName("Densidade_demo")
                .IsRequired();

            this.Property(p => p.Gentilico)
                .HasColumnName("Gentilico")
                .IsRequired();

            this.Property(p => p.Area)
                .HasColumnName("Area")
                .IsRequired();

            HasRequired(x => x.Estados)
                .WithMany()
                .HasForeignKey(x => x.CodigoEstado);
        }
    }
}
