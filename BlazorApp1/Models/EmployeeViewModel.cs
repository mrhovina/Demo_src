using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public partial class EmployeeViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Full name is required")]
        public string employee_name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Incorrect value for Salary")]
        public int? employee_salary { get; set; }

        [Range(1, 200, ErrorMessage = "Incorrect value for Age")]
        public int? employee_age { get; set; }
        public string pictureBase64 { get; set; }
    }
}
