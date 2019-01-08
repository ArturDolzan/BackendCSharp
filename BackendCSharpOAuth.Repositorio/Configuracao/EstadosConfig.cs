using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Configuracao
{
    public class EstadosConfig : EntityTypeConfiguration<Estados>, IMapping
    {
        public EstadosConfig()
        {
            this.ToTable("Estados");

            this.HasKey<int>(s => s.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            this.Property(p => p.Sigla)
                .HasColumnName("Sigla")
                .IsRequired();
        }
    }
}
