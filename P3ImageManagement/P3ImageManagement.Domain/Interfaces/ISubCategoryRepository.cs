using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Interfaces
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        List<SubCategory> GetByCategoryId(int categoryId);
        SubCategory GetBySlug(string slug);
    }
}
