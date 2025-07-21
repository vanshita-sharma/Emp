using webproject.Model;
namespace webproject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
       
        Task<EmployeeModel?> AddAsync(EmployeeModel employee);
        Task<EmployeeModel?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(string mail);


    }
}
