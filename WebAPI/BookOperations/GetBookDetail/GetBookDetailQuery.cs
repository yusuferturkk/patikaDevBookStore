using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Common;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;

        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BookDetailViewModel> Handle()
        {
            var bookListed = _context.Books.Where(b => b.Id == Id).SingleOrDefault();
            List<BookDetailViewModel> viewModel = new List<BookDetailViewModel>();

            if (bookListed is null)
                throw new InvalidOperationException ("Kitap bulunamadı.");
            
            viewModel.Add(new BookDetailViewModel()
                {
                    Id = bookListed.Id,
                    Title = bookListed.Title,
                    PageCount = bookListed.PageCount,
                    PublishDate = bookListed.PublishDate.Date.ToString("dd/MM/yyy")
            });

            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}