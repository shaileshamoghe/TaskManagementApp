using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskManagementContext _context;

    public TasksController(TaskManagementContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assignment>>> GetTasks()
    {
        return await _context.Tasks.Include(t => t.Notes).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Task>> CreateTask(Assignment task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.AssignmentId }, task);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Assignment>> GetTask(int id)
    {
        var task = await _context.Tasks.Include(t => t.Notes).FirstOrDefaultAsync(t => t.AssignmentId == id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
