

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webproject.Model
{
    public class EmployeeModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        
        public string Name { get; set; }

        
        public double Salary { get; set; }

        public string Domain { get; set; }

       
        public string Mail { get; set; }
    }
}
