using P3ImageManagement.Domain.Interfaces;
using P3ImageManagement.Infra.Dao.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Infra.Dao.Config
{
    public class UnitOfWork : IUnitOfWork
    {
        private P3ImageDBContext _context;

        public UnitOfWork(P3ImageDBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
