using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    [Serializable]
    public class Category : Entity
    {
        public Category()
        {
            this.SubCategories = new List<SubCategory>();
        }

        public Category(string description, string slug)
        {
            this.Description = description;
            this.Slug = slug;
            this.SubCategories = new List<SubCategory>();
        }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
