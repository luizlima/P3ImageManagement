using P3ImageManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Domain.Interfaces;
using P3ImageManagement.Application.ViewModels;
using P3ImageManagement.Application.Patterns.FieldPattern;
using P3ImageManagement.Infra.Dao.Repository;

namespace P3ImageManagement.Application.Services
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IP3RouteAppService _p3RouteAppService;
        private readonly ICategoryAppService _categoryAppService;

        public SubCategoryAppService(ISubCategoryRepository subCategoryRepository, ICategoryAppService categoryAppService, IP3RouteAppService p3RouteAppService)
        {
            _subCategoryRepository = subCategoryRepository;
            _categoryAppService = categoryAppService;
            _p3RouteAppService = p3RouteAppService;
        }

        public void Add(SubCategoryViewModel subCategoryViewModel)
        {
            SubCategory subCategory = new SubCategory();
            subCategory.Description = subCategoryViewModel.Description;
            subCategory.Slug = subCategoryViewModel.Slug;
            subCategory.CategoryId = subCategoryViewModel.CategoryViewModel.Id;
            FieldCreator creator = new FieldCreator();
            foreach (var item in subCategoryViewModel.FieldsViewModel)
            {
                subCategory.Fields.Add(creator.FactoryMethod(item));
            }

            _subCategoryRepository.Add(subCategory);
            _subCategoryRepository.SaveChanges();

            subCategoryViewModel.Id = subCategory.Id;

            _p3RouteAppService.Add(new P3Route(_categoryAppService.GetById(subCategory.CategoryId).Slug + "/" + subCategory.Slug,
                                                "App/Views/render-form.htm",
                                                ""));
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
                    CategoryViewModel = _categoryAppService.GetById(subCategory.CategoryId),
                    FieldsViewModel = ConvertToViewModels(subCategory.Fields)
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

        public SubCategoryViewModel GetBySlug(string slug)
        {
            var subCategory = _subCategoryRepository.GetBySlug(slug);
            var subCategoryViewModel = new SubCategoryViewModel();
            subCategoryViewModel.Id = subCategory.Id;
            subCategoryViewModel.Description = subCategory.Description;
            subCategoryViewModel.Slug = subCategory.Slug;
            subCategoryViewModel.CategoryViewModel = _categoryAppService.GetById(subCategory.CategoryId);
            subCategoryViewModel.FieldsViewModel = ConvertToViewModels(subCategory.Fields);

            return subCategoryViewModel;
        }

        public void Remove(int id)
        {
            var subCategory = _subCategoryRepository.GetById(id);
            _subCategoryRepository.Remove(subCategory);
        }

        private List<FieldViewModel> ConvertToViewModels(List<Field> fields)
        {
            var fieldsViewModel = new List<FieldViewModel>();
            FieldViewModelCreator creator = new FieldViewModelCreator();
            foreach (var item in fields.OrderBy(f => f.Order))
            {
                fieldsViewModel.Add(creator.FactoryMethod(item));
            }

            return fieldsViewModel;
        }

        public List<SubCategoryViewModel> GetByCategoryId(int categoryId)
        {
            var subCategories = _subCategoryRepository.GetByCategoryId(categoryId);
            var subCategoriesViewModel = new List<SubCategoryViewModel>();
            subCategories.ForEach(delegate (SubCategory subCategory) {
                subCategoriesViewModel.Add(new SubCategoryViewModel()
                {
                    Id = subCategory.Id,
                    Description = subCategory.Description,
                    Slug = subCategory.Slug
                });
            });

            return subCategoriesViewModel;
        }
    }
}
