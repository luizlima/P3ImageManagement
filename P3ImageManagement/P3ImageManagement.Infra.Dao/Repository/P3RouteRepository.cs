using P3ImageManagement.Domain.Models;
using P3ImageManagement.Infra.Dao.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Repository
{
    public class P3RouteRepository : IDisposable
    {
        protected readonly P3ImageDBContext _context;

        public P3RouteRepository(P3ImageDBContext context)
        {
            _context = context;
        }

        public void Add(P3Route obj)
        {
            _context.Set<P3Route>().Add(obj);
        }

        public IQueryable<P3Route> GetAll()
        {
            return _context.Set<P3Route>();
        }

        public P3Route GetById(int id)
        {
            return _context.Set<P3Route>().SingleOrDefault(x => x.Id == id);
        }

        public void Remove(P3Route obj)
        {
            _context.Set<P3Route>().Remove(obj);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(P3Route obj)
        {
            _context.Entry<P3Route>(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
