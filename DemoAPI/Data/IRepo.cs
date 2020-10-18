using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Data
{
    public interface IRepo
    {
        bool SaveChanges();
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee emp);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(Employee emp);
    }
}
