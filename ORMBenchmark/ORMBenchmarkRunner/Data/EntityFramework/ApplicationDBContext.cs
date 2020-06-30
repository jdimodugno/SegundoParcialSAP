using System;
using Microsoft.EntityFrameworkCore;
using ORMBenchmark.Models;

namespace ORMBenchmark.Data.EntityFramework
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Book> Books;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Benchmark;User=sa;Password=cdd4646!;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book => { book.HasKey(b => b.Id); });
        }
    }
}
