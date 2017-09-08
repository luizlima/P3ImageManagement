using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Interfaces
{
    public interface ICategoryAppService
    {
        void Add(P3ImageManagement.Domain.Models.Category category);
        P3ImageManagement.Domain.Models.Category GetById(int id);
    }
}
