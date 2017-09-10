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
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly IRepository<SubCategory> _subCategoryRepository;
        private readonly ICategoryAppService _categoryAppService;

        public SubCategoryAppService(IRepository<SubCategory> subCategoryRepository, ICategoryAppService categoryAppService)
        {
            _subCategoryRepository = subCategoryRepository;
            _categoryAppService = categoryAppService;
        }

        public void Add(SubCategoryViewModel subCategoryViewModel)
        {
            SubCategory subCategory = new SubCategory();
            subCategory.Description = subCategoryViewModel.Description;
            subCategory.Slug = subCategoryViewModel.Slug;
            subCategory.CategoryId = subCategoryViewModel.CategoryViewModel.Id;

            _subCategoryRepository.Add(subCategory);
            _subCategoryRepository.SaveChanges();
            subCategoryViewModel.Id = subCategory.Id;
        }

        public List<SubCategoryViewModel> GetAll()
        {
            var subCategories = _subCategoryRepository.GetAll().ToList();
            var subCategoriesViewModel = new List<SubCategoryViewModel>();
            subCategories.ForEach(delegate (SubCategory subCategory) {
                subCategoriesViewModel.Add(new SubCategoryViewModel()
                {
                    Id = subCategory.Id,
                    Description = subCategory.Description,
                    Slug = subCategory.Slug,
                    CategoryViewModel = _categoryAppService.GetById(subCategory.CategoryId)
                });
            });
            return subCategoriesViewModel;
        }

        public SubCategoryViewModel GetById(int id)
        {
            var subCategory = _subCategoryRepository.GetById(id);
            var subCategoryViewModel = new SubCategoryViewModel();
            subCategoryViewModel.Id = subCategory.Id;
            subCategoryViewModel.Description = subCategory.Description;
            subCategoryViewModel.Slug = subCategory.Slug;
            subCategoryViewModel.CategoryViewModel = _categoryAppService.GetById(subCategory.CategoryId);

            return subCategoryViewModel;

        }

        public void Remove(int id)
        {
            var subCategory = _subCategoryRepository.GetById(id);
            _subCategoryRepository.Remove(subCategory);
        }
    }
}
