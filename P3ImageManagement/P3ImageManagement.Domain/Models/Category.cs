using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    public class Category : Entity
    {
        public Category(int id, string description, string slug)
        {
            this.Id = id;
            this.Description = description;
            this.Slug = slug;
        }
    }
}
