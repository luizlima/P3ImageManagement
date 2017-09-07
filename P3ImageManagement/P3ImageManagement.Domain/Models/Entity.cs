using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public string Slug { get; set; }
    }
}
