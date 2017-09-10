using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required]
        public String Description { get; set; }
        [Required]
        public string Slug { get; set; }
    }
}
