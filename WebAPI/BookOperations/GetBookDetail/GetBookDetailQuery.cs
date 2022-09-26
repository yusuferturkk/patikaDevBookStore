using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int Id { get; set; }
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var bookListed = _context.Books.Where(b => b.Id == Id).SingleOrDefault();
            if (bookListed is null)
                throw new InvalidOperationException ("Kitap bulunamadı.");
            
            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(bookListed);

            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}