using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JournalingAppBackEnd.Data;
using JournalingAppBackEnd.Models;

namespace JournalingAppBackEnd.Controllers
{
    [Route("api/journals")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private readonly JournalDBContext _context;

        public JournalsController(JournalDBContext context)
        {
            _context = context;
        }

        // GET: api/journals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journal>>> GetJournals()
        {
            if (_context.Journals == null)
            {
                return NotFound();
            }
            return await _context.Journals.Include(x => x.Entries).ToListAsync();
        }

        // GET: api/journals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journal>> GetJournal(int id)
        {
            if (_context.Journals == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals.Include(j => j.Entries).FirstOrDefaultAsync(j => j.ID == id);
            if (journal == null)
            {
                return NotFound();
            }

            return journal;
        }

        // PUT: api/journals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournal(int id, Journal journal)
        {
            if (id != journal.ID)
            {
                return BadRequest();
            }

            _context.Entry(journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/journals
        [HttpPost]
        public async Task<ActionResult<Journal>> PostJournal(Journal journal)
        {
            if (_context.Journals == null)
            {
                return Problem("Entity set 'JournalDBContext.Journals'  is null.");
            }

            _context.Journals.Add(journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournal", new { id = journal.ID }, journal);
        }

        // DELETE: api/journals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            if (_context.Journals == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals.Include(j => j.Entries).FirstOrDefaultAsync(j => j.ID == id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JournalExists(int id)
        {
            return (_context.Journals?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
