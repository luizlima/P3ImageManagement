using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class TextAreaMap : EntityTypeConfiguration<TextArea>
    {
        public TextAreaMap()
        {
            Map(x => 
            {
                x.ToTable("TextArea");
            });

            Property(x => x.Value).HasMaxLength(512);
        }
    }
}
