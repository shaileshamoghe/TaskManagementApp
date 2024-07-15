using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<TaskNote> TaskNotes { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int AssignedToId { get; set; }
        public Employee AssignedTo { get; set; }
        public List<TaskNote> Notes { get; set; } = new List<TaskNote>();
      
    }
}
