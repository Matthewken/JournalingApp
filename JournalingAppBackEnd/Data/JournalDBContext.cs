using JournalingAppBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalingAppBackEnd.Data
{
    public class JournalDBContext : DbContext
    {
        public JournalDBContext(DbContextOptions<JournalDBContext> options) : base(options)
        {
        }

        public DbSet<Journal>? Journals { get; set; }
        public DbSet<Entry>? Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>().ToTable("Journal");
            modelBuilder.Entity<Entry>().ToTable("Entry");
        }
    }
}