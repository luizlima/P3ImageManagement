using System.Collections.Generic;

namespace P3ImageManagement.Domain.Models
{
    public abstract class Field
    {
        public int Order { get; set; }

        public string Description { get; set; }

        public List<string> Values { get; set; }
    }
}
