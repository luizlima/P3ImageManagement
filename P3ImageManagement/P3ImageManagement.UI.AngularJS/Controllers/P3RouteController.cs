using P3ImageManagement.Application.Interfaces;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.IoC;
using System.Collections.Generic;
using System.Web.Http;

namespace P3ImageManagement.UI.AngularJS.Controllers
{
    public class P3RouteController : ApiController
    {
        private IP3RouteAppService _p3RouteAppService;

        public P3RouteController()
        {
            _p3RouteAppService = Ioc.Instance.container.GetInstance<IP3RouteAppService>();
        }

        // GET: api/p3route
        public IEnumerable<P3Route> Get()
        {
            var routes = _p3RouteAppService.GetAll();

            return routes;
        }
    }
}
