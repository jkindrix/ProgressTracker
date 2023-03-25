using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgressTracker.Domain;

namespace ProgressTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Task> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

    }
}