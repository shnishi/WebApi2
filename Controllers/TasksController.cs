using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2.Model;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksDbContext _context;

        public TasksController(TasksDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebApi2.Model.Task>>> Gettasks()
        {
          if (_context.tasks == null)
          {
              return NotFound();
          }
            return await _context.tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApi2.Model.Task>> GetTask(int id)
        {
          if (_context.tasks == null)
          {
              return NotFound();
          }
            var task = await _context.tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, WebApi2.Model.Task task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebApi2.Model.Task>> PostTask(WebApi2.Model.Task task)
        {
          if (_context.tasks == null)
          {
              return Problem("Entity set 'TasksDbContext.tasks'  is null.");
          }
            _context.tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.TaskId }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_context.tasks == null)
            {
                return NotFound();
            }
            var task = await _context.tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (_context.tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
