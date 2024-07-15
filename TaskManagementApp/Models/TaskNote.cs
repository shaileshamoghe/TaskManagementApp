using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class TaskNote
    {
        [Key]
        public int TaskNoteId { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public string Note { get; set; }
        public int TaskId { get; set; }
        public string  Task{ get; set; }
    }
}
