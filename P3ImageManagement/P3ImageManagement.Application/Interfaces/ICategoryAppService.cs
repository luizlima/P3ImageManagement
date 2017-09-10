using P3ImageManagement.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Interfaces
{
    public interface ICategoryAppService
    {
        void Add(CategoryViewModel categoryViewModel);
        CategoryViewModel GetById(int id);
        List<CategoryViewModel> GetAll();
        void Remove(int id);
    }
}
