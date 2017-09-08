using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Infra.Dao.Context;

namespace P3ImageManagement.Infra.Dao.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(P3ImageDBContext context) : base(context)
        {
        }
    }
}
