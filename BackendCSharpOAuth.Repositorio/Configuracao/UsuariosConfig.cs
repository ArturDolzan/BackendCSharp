using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Configuracao
{
    public class UsuariosConfig : EntityTypeConfiguration<Usuarios>, IMapping
    {
        public UsuariosConfig()
        {
            this.ToTable("Usuarios");

            this.HasKey<int>(s => s.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            this.Property(x => x.Senha)
                .HasColumnName("Senha")
                .IsRequired();
        }
    }
}
