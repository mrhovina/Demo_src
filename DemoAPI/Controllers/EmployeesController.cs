using AutoMapper;
using DemoAPI.Data;
using CommonSRC.Dtos;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeesController(IRepo repository, IMapper mapper, ILogger<EmployeesController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //Get all employees on api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees() 
        {
            try
            {
                var employeeItems = _repository.GetEmployees();
                if (employeeItems?.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeeItems));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        //Get employee by id on api/employees/id
        [HttpGet("{id}", Name ="GetEmployee")]
        public ActionResult<EmployeeReadDto> GetEmployee(int id) 
        {
            try
            {
                var employeeItem = _repository.GetEmployeeById(id);

                if (employeeItem != null)
                {
                    return Ok(_mapper.Map<EmployeeReadDto>(employeeItem));
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

            
            
        }
        //Post employe on api/employees
        [HttpPost()]
        public ActionResult<EmployeeCreateDto> CreateEmployee(EmployeeCreateDto employeeCreateDto) 
        {
            try
            {
                var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
                _repository.CreateEmployee(employeeModel);
                _repository.SaveChanges();

                var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

                return CreatedAtRoute(nameof(GetEmployee), new { id = employeeReadDto.id }, employeeReadDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeUpdateDto> UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto) 
        {

            try
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

            
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteEmployee(int id) 
        {

            try
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

            
        }
    }
}
