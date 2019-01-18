using BackendCSharpOAuth.Dominio.Mensageria;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio.Configuracao
{
    public class ChatConfig : EntityTypeConfiguration<Chat>, IMapping
    {
        public ChatConfig()
        {
            this.ToTable("Chat");

            this.HasKey<int>(s => s.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(p => p.UsuarioOrigem)
                .HasColumnName("UsuarioOrigem")
                .IsRequired();

            this.Property(p => p.UsuarioDestino)
                .HasColumnName("UsuarioDestino")
                .IsRequired();

            this.Property(p => p.DataHora)
                .HasColumnName("DataHora")
                .IsRequired();

            this.Property(p => p.Mensagem)
                .HasColumnName("Mensagem")
                .IsRequired();

            this.Property(p => p.Visualizado)
                .HasColumnName("Visualizado")
                .IsRequired();
        }
    }
}
