using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var deletedBook = _context.Books.SingleOrDefault(b => b.Id == Id);
            if(deletedBook is null)
                throw new InvalidOperationException ("Kitap bulunamadı");
            
            _context.Remove(deletedBook);
            _context.SaveChanges();
        }
    }

    public class DeleteBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}