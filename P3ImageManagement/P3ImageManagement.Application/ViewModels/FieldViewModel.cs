using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.ViewModels
{
    public class FieldViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ordem")]
        [Required]
        public int Order { get; set; }
        [Display(Name = "Descrição")]
        [Required]
        public string Description { get; set; }
    }
}
