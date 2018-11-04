using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Repositorio.Models.Configuracao;
using System.Data.Entity;
using System.Diagnostics;

namespace BackendCSharpOAuth.Repositorio
{
    public class BancoContext : DbContext
    {
        public BancoContext()
            : base("BancoContext")
        {
            Database.SetInitializer<BancoContext>(null);

            Database.Log = (p => Debug.WriteLine(p));
        }

        public DbSet<Carros> Carros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Configurations.Add(new CarrosConfig());

            base.OnModelCreating(modelBuilder);
           
        }

    }
}