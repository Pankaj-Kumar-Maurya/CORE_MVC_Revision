using Microsoft.EntityFrameworkCore;

namespace CORE_MVC_Revision.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { 
        
        }

        public DbSet<Student> Student { get; set; }
    }
}
