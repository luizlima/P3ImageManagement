using P3ImageManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.Dao.Repository;

namespace P3ImageManagement.Application.Services
{
    public class P3RouteAppService : IP3RouteAppService
    {
        private readonly P3RouteRepository _p3RouteRepository;

        public P3RouteAppService(P3RouteRepository p3RouteRepository)
        {
            _p3RouteRepository = p3RouteRepository;
        }

        public void Add(P3Route p3Route)
        {
            _p3RouteRepository.Add(p3Route);
            _p3RouteRepository.SaveChanges();
        }

        public List<P3Route> GetAll()
        {
            return _p3RouteRepository.GetAll().ToList();
        }

        public P3Route GetById(int id)
        {
            return _p3RouteRepository.GetById(id);
        }

        public void Remove(int id)
        {
            var route = _p3RouteRepository.GetById(id);
            _p3RouteRepository.Remove(route);
        }
    }
}
