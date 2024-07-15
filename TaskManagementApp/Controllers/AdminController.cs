using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly TaskManagementContext _context;

        public AdminController(TaskManagementContext context)
        {
            _context = context;
            // GET: api/Admin/Reports
            [HttpGet("Reports")]
            async Task<IActionResult> GetReports([FromQuery] string period)
            {
                DateTime startDate = DateTime.UtcNow;
                DateTime endDate;

                switch (period.ToLower())
                {
                    case "week":
                        endDate = startDate.AddDays(7);
                        break;
                    case "month":
                        endDate = startDate.AddMonths(1);
                        break;
                    default:
                        return BadRequest("Invalid period specified. Use 'week' or 'month'.");
                }

                var tasks = await _context.Tasks
                    .Where(t => t.DueDate >= startDate && t.DueDate <= endDate && !t.IsCompleted)
                    .ToListAsync();

                return Ok(tasks);
            }
        }
    }
}
    

