using System;
using Microsoft.EntityFrameworkCore;
using ORMBenchmark.Models;

namespace ORMBenchmark.Data.EntityFramework
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Author> Authors;
        public DbSet<Book> Books;

        public ApplicationDBContext() : base() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Author>(author =>
                {
                    author
                        .HasKey(a => a.Id);
                    author
                        .Property(a => a.Id)
                        .ValueGeneratedOnAdd();
                });

            modelBuilder
                .Entity<Book>(book =>
                {
                    book
                        .HasKey(b => b.Id);
                    book
                        .Property(b => b.Id)
                        .ValueGeneratedOnAdd();
                    book
                        .HasOne(b => b.Author)
                        .WithMany(a => a.Books)
                        .HasForeignKey(b => b.AuthorId);
                });
        }
    }
}
