using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Interfaces
{
    public interface IP3RouteAppService
    {
        void Add(P3Route categoryViewModel);
        P3Route GetById(int id);
        List<P3Route> GetAll();
        void Remove(int id);
    }
}
