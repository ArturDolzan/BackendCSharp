﻿using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Repositorio.Models.Configuracao;
using System.Data.Entity;
using System.Diagnostics;
using BackendCSharpOAuth.Infra;
using FirebirdSql.Data.FirebirdClient;

namespace BackendCSharpOAuth.Repositorio
{
    public class BancoContext<TEntidade> : DbContext, IUnidadeDeTrabalho<TEntidade> where TEntidade : IdentificadorBase
    {
        public DbSet<TEntidade> Entidade
        {
            get;
            set;
        }

        public BancoContext()
            : base(new FbConnection(@"database=localhost:teste2.fdb;user=sysdba;password=masterkey"), true)
        {
            Database.SetInitializer<BancoContext<TEntidade>>(null);

            Database.Log = (p => Debug.WriteLine(p));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //modelBuilder.HasDefaultSchema("public");

            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
           /* var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();


            // Varrendo todos os tipos que são mapeamento 
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }*/

            modelBuilder.Configurations.Add(new CarrosConfig());

            base.OnModelCreating(modelBuilder);  
        }

        public virtual int PersistirTransacao()
        {
            return this.SaveChanges();
        }

        public virtual void RejeitarTransacao()
        {
            // Implementar
        }

        public virtual DbContextTransaction CriarTransacaoEmEscopo()
        {
            return this.Database.BeginTransaction();
        }

    }
}