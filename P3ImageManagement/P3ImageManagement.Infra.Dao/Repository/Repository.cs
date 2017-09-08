using P3ImageManagement.Domain.Interfaces;
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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly P3ImageDBContext _context;
        

        public Repository(P3ImageDBContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry<TEntity>(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
