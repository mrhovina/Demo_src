using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(200)]
        public string employee_name { get; set; }
        
        public int? employee_salary { get; set; }
        public int? employee_age { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string pictureBase64 { get; set; }
    }
}
