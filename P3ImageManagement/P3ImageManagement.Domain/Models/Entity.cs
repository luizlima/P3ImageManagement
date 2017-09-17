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

        public override bool Equals(object obj)
        {
            if(obj is Entity)
            {
                Entity entity = obj as Entity;
                return this.Id == entity.Id;
            }
            return false;
        }
    }
}
