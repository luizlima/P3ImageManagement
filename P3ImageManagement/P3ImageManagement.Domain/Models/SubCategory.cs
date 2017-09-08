using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    public class SubCategory : Entity
    {
        public SubCategory()
        {
            this.Category = new Category();
            this.Fields = new List<Field>();
        }

        public SubCategory(int id, String description, string slug, Category category) : base()
        {
            this.Id = id;
            this.Description = description;
            this.Slug = slug;
            this.Category = category;
            this.Fields = new List<Field>();
        }

        public virtual List<Field> Fields { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
