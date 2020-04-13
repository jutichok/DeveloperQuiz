using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DeveloperQuiz.Domains.Models;
using DeveloperQuiz.Domains.Repositories;
using DeveloperQuiz.Persistances.Contexts;
using DeveloperQuiz.Persistances.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperQuiz.Repositories
{
    public class BookRepository : BaseRepository,IBookRepository
    {
        public BookRepository(MemoryDBContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Book>> GetBooksWithPaging(int skipAmount, int pageSize, Expression<Func<Book, bool>> predicate)
        {
            return await _context.Books.Where(predicate).OrderByDescending(b => b.PublishedDateUtc)
            .Skip(skipAmount)
            .Take(pageSize).ToListAsync();
        }

        

        public async Task<IEnumerable<Book>> GetBooks(Expression<Func<Book, bool>> predicate)
        {
            return await _context.Books.Where(predicate).OrderByDescending(b => b.PublishedDateUtc).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.OrderByDescending(b => b.PublishedDateUtc).ToListAsync();

        }
    }
}
