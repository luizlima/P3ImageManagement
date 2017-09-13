﻿using P3ImageManagement.Application.Interfaces;
using P3ImageManagement.Application.ViewModels;
using P3ImageManagement.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P3ImageManagement.UI.AngularJS.Controllers
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

        // GET: api/SubCategory
        [Route("api/subcategories/{categoryId}/category")]
        public IEnumerable<SubCategoryViewModel> GetByCategoryId(int categoryId)
        {
            _subCategoryAppService = Ioc.Instance.container.GetInstance<ISubCategoryAppService>();
            var subCategories = _subCategoryAppService.GetByCategoryId(categoryId);

            return subCategories;
        }

        // POST: api/SubCategory
        public HttpResponseMessage Post([FromBody]SubCategoryViewModel subCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subCategoryAppService.Add(subCategoryViewModel);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subCategoryViewModel);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subCategoryViewModel.Id }));

                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
