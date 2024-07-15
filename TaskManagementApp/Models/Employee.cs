using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public string EmployeeName { get; set; }
   
       
    }
}
