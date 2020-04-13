using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeveloperQuiz.Domains.Models;
using DeveloperQuiz.Domains.Request;
using DeveloperQuiz.Domains.Services;
using DeveloperQuiz.Repositories;
using DeveloperQuiz.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperQuiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return new OkObjectResult(await _bookService.GetBooks(null));
        }
        [HttpGet("/book/paging")]
        public async Task<IActionResult> GetBooks(int Id, string Title, DateTime PublishedDateUtc,
             int pageSize, int page)
        {
            BookRequest bookRequest = new BookRequest();
            bookRequest.Id = Id;
            bookRequest.Title = Title;
            bookRequest.Page = page;
            bookRequest.PublishedDateUtc = PublishedDateUtc;
            bookRequest.PageSize = pageSize;
            var validator = new BookRequestValidator();
            var validationResult = validator.Validate(bookRequest);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }
            Book bookEntity = _mapper.Map<BookRequest, Book>(bookRequest);
            var books = await _bookService.GetBooksWithPaging(bookRequest.Page.Value, bookRequest.PageSize, bookEntity);
            return new OkObjectResult(books);
        }
    }
}
