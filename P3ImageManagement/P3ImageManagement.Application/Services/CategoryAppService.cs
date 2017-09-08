using P3ImageManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Domain.Interfaces;

namespace P3ImageManagement.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
