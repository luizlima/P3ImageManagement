using P3ImageManagement.Application.Interfaces;
using P3ImageManagement.Application.ViewModels;
using P3ImageManagement.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P3ImageManagement.Api.Controllers
{
    public class SubCategoryController : ApiController
    {
        private ISubCategoryAppService _subCategoryAppService;

        public SubCategoryController()
        {
            _subCategoryAppService = Ioc.Instance.container.GetInstance<ISubCategoryAppService>();
        }

        // GET: api/SubCategory
        public IEnumerable<SubCategoryViewModel> Get()
        {
            _subCategoryAppService = Ioc.Instance.container.GetInstance<ISubCategoryAppService>();
            var subCategories = _subCategoryAppService.GetAll();

            return subCategories;
        }
    }
}
