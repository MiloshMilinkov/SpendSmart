using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Architecture.Data
{
    public class SpendSmartDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Ensures auto-increment for Id
        }

    }
}
