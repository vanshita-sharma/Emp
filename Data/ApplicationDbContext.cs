using Microsoft.EntityFrameworkCore;
using webproject.Model;

namespace webproject.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<EmployeeModel> Employees { get; set; }

       
    }
}
