using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BookOperations;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.DeleteBook;
using WebAPI.BookOperations.GetBookDetail;
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
        public IActionResult GetById(int id)
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context);
            try
            {
                query.Id = id;
                query.Handle();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(query);
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
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {                
                command.Id = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.Id = id;
                command.Handle();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}