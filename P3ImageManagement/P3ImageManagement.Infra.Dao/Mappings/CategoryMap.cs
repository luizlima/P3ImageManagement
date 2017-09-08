using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);

            Property(x => x.Description).HasMaxLength(128).IsRequired();
            Property(x => x.Slug).HasMaxLength(256).IsRequired();

            HasMany(x => x.SubCategories)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
