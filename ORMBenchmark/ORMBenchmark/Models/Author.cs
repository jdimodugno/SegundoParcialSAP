using System;
using System.Collections.Generic;
using ORMBenchmark.Interfaces;

namespace ORMBenchmark.Models
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
