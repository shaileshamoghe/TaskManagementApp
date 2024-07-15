using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Manager 
    {
        [Key]
        public int ManagerId { get; set; }
        public ICollection<Team> Teams { get; set; }
        public string EmployeeName { get; set; }
        public List<Employee> TeamMembers { get; set; }
    }
}
