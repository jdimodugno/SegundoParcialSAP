using System;

namespace ORMBenchmark.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
    }
}
