using webproject.Model;
namespace webproject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
       
        Task<EmployeeModel?> AddAsync(EmployeeModel employee);
      
    }
}
