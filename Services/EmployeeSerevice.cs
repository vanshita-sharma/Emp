using Microsoft.EntityFrameworkCore;
using webproject.Data;
using webproject.Model;

namespace webproject.Services
{
    public class EmployeeSerevice : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeSerevice(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModel?> AddAsync(EmployeeModel employee)
        {
            try
            {
                if (employee == null || string.IsNullOrWhiteSpace(employee.Mail))
                {
                    Console.WriteLine("Invalid employee input.");
                    return null;
                }

                var exists = await _context.Employees.AnyAsync(e => e.Mail == employee.Mail);
                Console.WriteLine($"Exists check: {exists}");

                if (exists)
                {
                    Console.WriteLine("Employee with same email already exists.");
                    return null;
                }

                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }



    }

}







