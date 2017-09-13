using P3ImageManagement.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Interfaces
{
    public interface ISubCategoryAppService
    {
        void Add(SubCategoryViewModel subCategoryViewModel);
        SubCategoryViewModel GetById(int id);
        List<SubCategoryViewModel> GetAll();
        List<SubCategoryViewModel> GetByCategoryId(int categoryId);
        void Remove(int id);
    }
}
