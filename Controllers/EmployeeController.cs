using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webproject.DTOS;
using webproject.Model;
using webproject.Services;

namespace webproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Mail))
                return BadRequest("Invalid employee data");

            var employee = new EmployeeModel
            {
                Name = dto.Name,
                Salary = dto.Salary,
                Domain = dto.Domain,
                Mail = dto.Mail
            };

            var result = await _employeeService.AddAsync(employee);

            if (result == null)
                return Conflict("Employee already exists or there was an error saving.");

            return CreatedAtAction(nameof(GetAllEmployees), new { id = result.EmployeeId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {

            var deleted = await _employeeService.DeleteAsync(id);

            if (!deleted)
                return NotFound($"Employee with ID {id} not found or could not be deleted.");

            return NoContent();


        }
    }
}
