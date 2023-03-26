using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Data
{


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}