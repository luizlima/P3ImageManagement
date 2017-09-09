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
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly IRepository<SubCategory> _subCategoryRepository;

        public SubCategoryAppService(IRepository<SubCategory> subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public void Add(SubCategory subCategory)
        {
            _subCategoryRepository.Add(subCategory);
            _subCategoryRepository.SaveChanges();
        }

        public SubCategory GetById(int id)
        {
            return _subCategoryRepository.GetById(id);
        }
    }
}
