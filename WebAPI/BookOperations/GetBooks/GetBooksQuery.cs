using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.Common;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookListed = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookListed);
            
            return viewModel;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}