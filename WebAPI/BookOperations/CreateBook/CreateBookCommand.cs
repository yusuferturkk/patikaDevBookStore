using System;
using System.Linq;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var addBook = _context.Books.SingleOrDefault(b => b.Title == Model.Title);
            if (addBook is not null)
                throw new InvalidOperationException ("Kitap zaten mevcut");

            addBook = new Book();
            addBook.Title = Model.Title;
            addBook.GenreId = Model.GenreId;
            addBook.PageCount = Model.PageCount;
            addBook.PublishDate = Model.PublishDate;
            
            _context.Add(addBook);
            _context.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}