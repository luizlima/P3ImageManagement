using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.Dao.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (P3ImageDBContext conte = new P3ImageDBContext())
            {
                conte.Categories.Add(new Category());
                conte.SaveChanges();
            }
        }
    }

    public class TesteContext : DbContext
    {
        public TesteContext()
        {
            Database.SetInitializer<TesteContext>(new CreateDatabaseIfNotExists<TesteContext>());
        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
