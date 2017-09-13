using P3ImageManagement.Application.ViewModels;
using P3ImageManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Application.Patterns.FieldPattern
{
    public class FieldViewModelCreator
    {
        public FieldViewModel FactoryMethod(Field field)
        {
            FieldViewModel fieldVM = new FieldViewModel();
            fieldVM.Order = field.Order;
            fieldVM.Description = field.Description;

            if (field is Checkbox)
            {
                fieldVM.FieldType = "checkbox";
                fieldVM.Values = ((Checkbox)field).Values;
            }
            else if (field is Select)
            {
                fieldVM.FieldType = "select";
                fieldVM.Values = ((Select)field).Values;
            }
            else if (field is Text)
            {
                fieldVM.FieldType = "text";
            }
            else if(field is TextArea)
            {
                fieldVM.FieldType = "textArea";
            }

            return fieldVM;
        }
    }
}
