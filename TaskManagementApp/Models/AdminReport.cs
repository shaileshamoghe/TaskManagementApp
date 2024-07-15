
using System.ComponentModel.DataAnnotations;
namespace TaskManagementApp.Models
{
    public class AdminReport
    {
        [Key]
        public int AdminReportId { get; set; }
        public string Period { get; set; }
        public DateTime ReportDate { get; set; }
        public string PendingTasks { get; set; }
    }
}
