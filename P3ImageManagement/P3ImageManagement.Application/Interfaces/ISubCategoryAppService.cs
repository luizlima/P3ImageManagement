using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Interfaces
{
    public interface ISubCategoryAppService
    {
        void Add(P3ImageManagement.Domain.Models.SubCategory subCategory);
        P3ImageManagement.Domain.Models.SubCategory GetById(int id);
    }
}
