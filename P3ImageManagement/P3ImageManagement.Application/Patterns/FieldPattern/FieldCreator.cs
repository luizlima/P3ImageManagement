using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3ImageManagement.Domain;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Application.ViewModels;

namespace P3ImageManagement.Application.Patterns.FieldPattern
{
    public class FieldCreator
    {
        public Field FactoryMethod(FieldViewModel fieldViewModel)
        {
            if (fieldViewModel.FieldType.Equals("checkbox"))
            {
                Checkbox field = new Checkbox();
                field.Order = fieldViewModel.Order;
                field.Description = fieldViewModel.Description;
                field.Values = fieldViewModel.Values;

                return field;
            }
            else if (fieldViewModel.FieldType.Equals("select"))
            {
                Select field = new Select();
                field.Order = fieldViewModel.Order;
                field.Description = fieldViewModel.Description;
                field.Values = fieldViewModel.Values;

                return field;
            }
            else if (fieldViewModel.FieldType.Equals("text"))
            {
                Text field = new Text();
                field.Order = fieldViewModel.Order;
                field.Description = fieldViewModel.Description;
                field.Value = "";
                return field;
            }
            else if (fieldViewModel.FieldType.Equals("textarea"))
            {
                TextArea field = new TextArea();
                field.Order = fieldViewModel.Order;
                field.Description = fieldViewModel.Description;
                field.Value = "";

                return field;
            }
            else
            {
                return new Text();
            }
        }
    }
}
