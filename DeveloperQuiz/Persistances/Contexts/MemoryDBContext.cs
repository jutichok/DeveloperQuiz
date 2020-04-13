using System;
using DeveloperQuiz.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperQuiz.Persistances.Contexts
{
    public class MemoryDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public MemoryDBContext(DbContextOptions<MemoryDBContext> options) : base(options) {
            InitBooks();
        }

        private void InitBooks()
        {
            for (int i=1; i<=100; i++)
            {
                Book book = new Book() {
                    Id = i,
                    Title = $"Title{i}",
                    PublishedDateUtc = DateTime.Now
                };
                Books.Add(book);
            }
            SaveChanges();
        }

    }
}
