using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class SubCategoryMap : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("SubCategory");

            HasKey(x => x.Id);

            Property(x => x.Description).HasMaxLength(128).IsRequired();
            Property(x => x.Slug).HasMaxLength(256).IsRequired();

            HasRequired(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryId);

            HasMany(x => x.Fields)
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryId);
        }
    }
}
