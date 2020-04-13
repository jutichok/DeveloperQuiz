using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DeveloperQuiz.Domains.Models;
using DeveloperQuiz.Domains.Repositories;
using DeveloperQuiz.Domains.Services;
using DeveloperQuiz.Utils;

namespace DeveloperQuiz.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<IEnumerable<Book>> GetBooks(Book book)
        {
            if (book == null) return _bookRepository.GetBooks();
            return _bookRepository.GetBooks(getPredicate(book));
        }

        public Task<IEnumerable<Book>> GetBooksWithPaging(int page, int pageSize, Book book)
        {
            var skipAmount = pageSize * (page - 1);
            return _bookRepository.GetBooksWithPaging(skipAmount, pageSize, getPredicate(book));
            
        }
        private Expression<Func<Book, bool>> getPredicate(Book book)
        {
            Expression<Func<Book, bool>> completeExpression = b => b.PublishedDateUtc >= book.PublishedDateUtc;
            //if (!string.IsNullOrEmpty(book.Id.ToString()))
            //{
            //    Expression<Func<Book, bool>> expression = b => b.Id == book.Id;
            //    completeExpression = completeExpression.And(expression);
            //}
            //if(!string.IsNullOrEmpty(book.Title))
            //{
            //    Expression<Func<Book, bool>> expression = b => b.Title == book.Title;
            //    completeExpression = completeExpression.And(expression);
            //}
            

            return completeExpression;
        }
    }
}
