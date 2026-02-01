using Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Config
{
    public class PesquisaContext : DbContext
    {
        public PesquisaContext(DbContextOptions<PesquisaContext> options) : base(options) { }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pesquisa> Pesquisas { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<OpcaoResposta> OpcaoResposta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t=>t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
      
}
