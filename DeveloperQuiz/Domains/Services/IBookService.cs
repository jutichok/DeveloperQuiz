using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperQuiz.Domains.Models;

namespace DeveloperQuiz.Domains.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks(Book book);
        Task<IEnumerable<Book>> GetBooksWithPaging(int page,int pageSize, Book book);

    }
}
