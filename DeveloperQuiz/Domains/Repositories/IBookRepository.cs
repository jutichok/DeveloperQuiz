using System;
using DeveloperQuiz.Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DeveloperQuiz.Domains.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetBooks(Expression<Func<Book, bool>> predicate);
        Task<IEnumerable<Book>> GetBooksWithPaging(int skipAmount,int pageSize, Expression<Func<Book, bool>> predicate);
    }
}
