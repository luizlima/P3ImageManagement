using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class FieldMap : EntityTypeConfiguration<Field>
    {
        public FieldMap()
        {
            ToTable("Field");

            HasKey(x => x.Id);

            Property(x => x.Order).IsRequired();
            Property(x => x.Description).HasMaxLength(256);

            HasRequired(x => x.SubCategory)
                .WithMany(x => x.Fields)
                .HasForeignKey(x => x.SubCategoryId);
        }
    }
}
