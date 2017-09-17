using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Infra.Dao.Context;
using P3ImageManagement.Domain.Interfaces;

namespace P3ImageManagement.Infra.Dao.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(P3ImageDBContext context) : base(context)
        {
            
        }

        public List<SubCategory> GetByCategoryId(int categoryId)
        {
            return _context.Set<SubCategory>().Where(x => x.CategoryId == categoryId).ToList();
        }

        public SubCategory GetBySlug(string slug)
        {
            return _context.Set<SubCategory>().SingleOrDefault(x => x.Slug == slug);
        }
    }
}
