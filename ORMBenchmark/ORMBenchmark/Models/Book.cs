using System;
using ORMBenchmark.Interfaces;

namespace ORMBenchmark.Models
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
