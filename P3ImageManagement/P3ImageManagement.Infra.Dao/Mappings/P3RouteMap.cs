using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class P3RouteMap : EntityTypeConfiguration<P3Route>
    {
        public P3RouteMap()
        {
            ToTable("P3Route");

            HasKey(x => x.Id);

            Property(x => x.Path).HasMaxLength(256).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                                        new IndexAnnotation(new IndexAttribute("IX_Path")
                                                                    { IsUnique = true }
                                        ));
            Property(x => x.TemplateUrl).HasMaxLength(512).IsRequired();
    }
    }
}
