using System.Collections.Generic;
using System.Linq;
using WebAPI.Common;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBooksQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            var bookListed = _context.Books.OrderBy(b => b.Id).ToList();
            List<BooksViewModel> viewModel = new List<BooksViewModel>();
            
            foreach(var book in bookListed)
            {
                viewModel.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")
                });
            }
            return viewModel;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}