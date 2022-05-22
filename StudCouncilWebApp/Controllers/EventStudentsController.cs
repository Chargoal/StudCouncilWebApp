using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudCouncilWebApp.Models;

namespace StudCouncilWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStudentsController : ControllerBase
    {
        private readonly StudCouncilContext _context;

        public EventStudentsController(StudCouncilContext context)
        {
            _context = context;
        }

        // GET: api/EventStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventStudent>>> GetEventStudents()
        {
          if (_context.EventStudents == null)
          {
              return NotFound();
          }
            return await _context.EventStudents.ToListAsync();
        }

        // GET: api/EventStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventStudent>> GetEventStudent(int id)
        {
          if (_context.EventStudents == null)
          {
              return NotFound();
          }
            var eventStudent = await _context.EventStudents.FindAsync(id);

            if (eventStudent == null)
            {
                return NotFound();
            }

            return eventStudent;
        }

        // PUT: api/EventStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventStudent(int id, EventStudent eventStudent)
        {
            if (id != eventStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventStudentExists(id))
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

        // POST: api/EventStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventStudent>> PostEventStudent(EventStudent eventStudent)
        {
          if (_context.EventStudents == null)
          {
              return Problem("Entity set 'StudCouncilContext.EventStudents'  is null.");
          }
            _context.EventStudents.Add(eventStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventStudent", new { id = eventStudent.Id }, eventStudent);
        }

        // DELETE: api/EventStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventStudent(int id)
        {
            if (_context.EventStudents == null)
            {
                return NotFound();
            }
            var eventStudent = await _context.EventStudents.FindAsync(id);
            if (eventStudent == null)
            {
                return NotFound();
            }

            _context.EventStudents.Remove(eventStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventStudentExists(int id)
        {
            return (_context.EventStudents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
