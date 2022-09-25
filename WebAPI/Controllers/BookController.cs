using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.GetBooks;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        // private static List<Book> bookList = new List<Book>()
        // {
        //     new Book{
        //         Id = 1,
        //         Title = "Lean Startup",
        //         GenreId = 1,
        //         PageCount = 200,
        //         PublishDate = new DateTime(2001,06,12)
        //     },

        //     new Book{
        //         Id = 2,
        //         Title = "Herland",
        //         GenreId = 2,
        //         PageCount = 250,
        //         PublishDate = new DateTime(2010,05,23)
        //     },

        //     new Book{
        //         Id = 3,
        //         Title = "Dune",
        //         GenreId = 2,
        //         PageCount = 540,
        //         PublishDate = new DateTime(2002,12,21)
        //     }
        // };

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var bookListed = _context.Books.Where(b => b.Id == id).SingleOrDefault();
            return bookListed;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel model)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = model;
                command.Handle();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book is null)
                return BadRequest();
            
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var deletedBook = _context.Books.SingleOrDefault(b => b.Id == id);
            if(deletedBook is null)
                return BadRequest();
            
            _context.Remove(deletedBook);
            _context.SaveChanges();
            return Ok();
        }
    }
}