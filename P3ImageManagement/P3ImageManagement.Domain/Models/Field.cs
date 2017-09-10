using System;
using System.Collections.Generic;

namespace P3ImageManagement.Domain.Models
{
    public abstract class Field
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Description { get; set; }
        
        //public Checkbox Checkbox { get; set; }

        //public Select Select { get; set; }

        //public Text Text { get; set; }

        //public TextArea TextArea { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
