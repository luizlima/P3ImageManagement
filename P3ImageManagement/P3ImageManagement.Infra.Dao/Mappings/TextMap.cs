using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class TextMap : EntityTypeConfiguration<Text>
    {
        public TextMap()
        {
            Map(x => 
            {
                //x.MapInheritedProperties();
                x.ToTable("Text");
            });

            Property(x => x.Value).HasMaxLength(512);
        }
    }
}
