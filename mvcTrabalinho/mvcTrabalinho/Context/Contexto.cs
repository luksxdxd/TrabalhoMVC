using mvcTrabalinho.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace mvcTrabalinho.Context
{
    public class Contexto : DbContext
    {
        public DbSet<ProdutoModel> produtos { get; set; }
        public DbSet<PedidoModel> pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}