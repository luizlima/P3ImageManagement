using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Mappings
{
    public class SelectMap : EntityTypeConfiguration<Select>
    {
        public SelectMap()
        {
            Map(x => 
            {
                x.ToTable("Select");
            });

            Property(x => x.Values).HasMaxLength(512);
        }
    }
}
