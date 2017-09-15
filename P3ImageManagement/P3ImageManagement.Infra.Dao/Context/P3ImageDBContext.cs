using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.Dao.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Context
{
    public class P3ImageDBContext : DbContext, IDisposable
    {
        public P3ImageDBContext()
        {
            Database.SetInitializer<P3ImageDBContext>(new DropCreateDatabaseAlways<P3ImageDBContext>());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Field> Fields{ get; set; }

        public DbSet<Checkbox> Checkboxes { get; set; }

        public DbSet<Select> Selects { get; set; }

        public DbSet<Text> Texts{ get; set; }

        public DbSet<TextArea> TextAreas { get; set; }

        public DbSet<P3Route> P3Routes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new CheckboxMap());
            modelBuilder.Configurations.Add(new SelectMap());
            modelBuilder.Configurations.Add(new TextMap());
            modelBuilder.Configurations.Add(new TextAreaMap());
            modelBuilder.Configurations.Add(new P3RouteMap());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
