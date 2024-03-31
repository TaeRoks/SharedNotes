using Microsoft.EntityFrameworkCore;
using SharedNotes.Shared.Entities;

namespace SharedNotes.Shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            :base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }
    }
}
