using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public int TaskId { get; set; }
        
        public string  Task { get; set; }
    }
}
