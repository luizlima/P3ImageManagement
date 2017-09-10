using P3ImageManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Domain.Interfaces;
using P3ImageManagement.Application.ViewModels;

namespace P3ImageManagement.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(CategoryViewModel categoryViewModel)
        {
            Category category = new Category(categoryViewModel.Description, categoryViewModel.Slug);
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            categoryViewModel.Id = category.Id;
        }

        public List<CategoryViewModel> GetAll()
        {
            var categories = _categoryRepository.GetAll().ToList();
            var categoriesViewModel = new List<CategoryViewModel>();
            categories.ForEach(delegate (Category category) {
                categoriesViewModel.Add(new CategoryViewModel()
                {
                    Id = category.Id ,
                    Description = category.Description,
                    Slug = category.Slug
                });
            });
            return categoriesViewModel;
        }

        public CategoryViewModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return new CategoryViewModel() { Id = category.Id, Description = category.Description, Slug = category.Slug};
        }

        public void Remove(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Remove(category);
        }
    }
}
