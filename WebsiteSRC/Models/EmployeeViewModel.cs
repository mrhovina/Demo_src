using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteSRC.Models
{
    public class EmployeeViewModel
    {
        public int id { get; }
        public string employee_name { get; set; }
        public int? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public string pictureBase64 { get; set; }
    }
}
