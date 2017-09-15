using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ImageManagement.Domain.Models
{
    public class P3Route
    {
        public P3Route()
        {

        }

        public P3Route(string path,string templateUrl,string controller)
        {
            Path = path;
            TemplateUrl = templateUrl;
            Controller = controller;
        }

        public int Id { get; set; }

        public string Path { get; set; }

        public string TemplateUrl { get; set; }

        public string Controller { get; set; }
    }
}
