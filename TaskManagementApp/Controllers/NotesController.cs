using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly TaskManagementContext _context;

        public NotesController(TaskManagementContext context)
        {
            _context = context;
        }


        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskNote>>> GetNotes()
        {
            return await _context.TaskNotes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskNote>> GetNote(int id)
        {
            var note = await _context.TaskNotes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, TaskNote note)
        {
            if (id != note.TaskNoteId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<TaskNote>> PostNote(TaskNote note)
        {
            _context.TaskNotes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.TaskNoteId }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.TaskNotes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.TaskNotes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _context.TaskNotes.Any(e => e.TaskNoteId == id);
        }
    }
}
