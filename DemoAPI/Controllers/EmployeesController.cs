using AutoMapper;
using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get all employees on api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees() 
        {
            var employeeItems = _repository.GetEmployees();
            if (employeeItems.Count() == 0)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeeItems));

            
        }

        //Get employee by id on api/employees/id
        [HttpGet("{id}", Name ="GetEmployee")]
        public ActionResult<EmployeeReadDto> GetEmployee(int id) 
        {
            var employeeItem = _repository.GetEmployeeById(id);

            if (employeeItem != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employeeItem));
            }
            else return NotFound();
            
        }
        //Post employe on api/employees
        [HttpPost()]
        public ActionResult<EmployeeCreateDto> CreateEmployee(EmployeeCreateDto employeeCreateDto) 
        {
            var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
            _repository.CreateEmployee(employeeModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployee), new { id = employeeReadDto.id }, employeeReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeUpdateDto> UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto) 
        {
            var employeeItem = _repository.GetEmployeeById(id);
            if (employeeItem == null)
            {
                NotFound();
            }

            _mapper.Map(employeeUpdateDto, employeeItem);

            _repository.UpdateEmployee(employeeItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteEmployee(int id) 
        {
            var employeeItem = _repository.GetEmployeeById(id);
            if (employeeItem == null)
            {
                return NotFound();
            }
            _repository.DeleteEmployee(employeeItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
