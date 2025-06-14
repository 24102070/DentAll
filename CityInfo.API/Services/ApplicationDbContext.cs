using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
        
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
