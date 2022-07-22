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
    [Route("api/journals/{journalID}/entries")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly JournalDBContext _context;

        public EntriesController(JournalDBContext context)
        {
            _context = context;
        }

        // GET: api/journals/{journalID}/entries
        [HttpGet]
        public async Task<ActionResult<List<Entry>>> GetEntries(int journalID)
        {
            var journal = await _context.Journals.FindAsync(journalID);

            if (journal == null || journal.Entries == null)
            {
                return NotFound();
            }

            return journal.Entries.ToList();
        }

        // GET: api/journals/{journalID}/entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(int journalID, int id)
        {
            if (_context.Entries == null)
            {
                return NotFound();
            }
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        // PUT: api/journals/{journalID}/entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(int journalID, int id, Entry entry)
        {
            entry.ID = id;
            entry.JournalId = journalID;
            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntry", new { journalID = journalID, id = entry.ID }, entry);
        }

        // POST: api/journals/{journalID}/entries
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(int journalID, Entry entry)
        {
            if (_context.Entries == null)
            {
                return Problem("Entity set 'JournalDBContext.Entries'  is null.");
            }

            if (entry == null)
            {
                return Problem("Entry can not be empty");
            }

            var journal = await _context.Journals.FindAsync(journalID);
            if (journal == null)
            {
                return NotFound("Journal not found by id");
            }

            entry.JournalId = journalID;

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntry", new { journalID = journalID, id = entry.ID }, entry);
        }

        // DELETE: api/journals/{journalID}/entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int journalID, int id)
        {
            if (_context.Entries == null)
            {
                return NotFound();
            }
            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntryExists(int id)
        {
            return (_context.Entries?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
