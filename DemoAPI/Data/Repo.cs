using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Data
{
    public class Repo : IRepo
    {
        private readonly EmployeeContext _context;

        public Repo(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.id == id);
        }

        bool IRepo.SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        void IRepo.CreateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            _context.Employees.Add(emp);
        }

        void IRepo.UpdateEmployee(Employee emp)
        {
            
        }

        void IRepo.DeleteEmployee(Employee emp)
        {
            _context.Employees.Remove(emp);
        }
    }
}
