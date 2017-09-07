using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    public class SubCategory : Entity
    {
        public SubCategory(int id, String description, string slug, Category category) : base()
        {
            this.Id = id;
            this.Description = description;
            this.Slug = slug;
            this.Category = category;
        }

        public Category Category { get; set; }

        public List<Field> Fields { get; set; }
    }
}
