using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommonSRC.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string employee_name { get; set; }
        public int? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public string pictureBase64 { get; set; }



    }
}
