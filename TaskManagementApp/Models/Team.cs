using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public int ManagerId { get; set; }
        public string TeamName { get; set; }
        public List<Employee> Members { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}
