using P3ImageManagement.Application.Interfaces;
using P3ImageManagement.Application.ViewModels;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P3ImageManagement.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private  ICategoryAppService _categoryAppService;

        public CategoryController()
        {
            _categoryAppService = Ioc.Instance.container.GetInstance<ICategoryAppService>();
        }

        // GET: api/Category
        public IEnumerable<CategoryViewModel> Get()
        {
            _categoryAppService = Ioc.Instance.container.GetInstance<ICategoryAppService>();
            var categories = _categoryAppService.GetAll();

            return categories;
        }

        // GET: api/Category/5
        public CategoryViewModel Get(int id)
        {
            var category = _categoryAppService.GetById(id);

            return category;
        }

        // POST: api/Category
        public HttpResponseMessage Post([FromBody]CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryAppService.Add(categoryViewModel);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categoryViewModel);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categoryViewModel.Id }));

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

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _categoryAppService.Remove(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
