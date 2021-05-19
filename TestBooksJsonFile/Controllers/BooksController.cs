using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestBooksJsonFile.Dtos;
using TestBooksJsonFile.Repositories;

namespace TestBooksJsonFile.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repository;

        // using Dependency injection where the controller depends on an abstraction instead of an implementation.
        // The controller do not know what kind of repository it depends on and consequently we can change data surce and the repository implementation without changing the controller

        public BooksController(IBooksRepository repository)
        {
            this.repository = repository;
        }


        // GET api/books
        [HttpGet]
        public IEnumerable<BookDto> GetBookList()
        {
            var books = repository.GetBooks().Select(book => book.AsDto());

            return books;
        }


        // GET api/books/id
        [HttpGet("id")]
        public IEnumerable<BookDto> GetBookListSortedById()
        {
            var books = repository.GetBooksSortedById().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/id/b1
        [HttpGet("id/{id}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksById(string id)
        {
            var books = repository.GetBooksContainingId(id).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/author
        [HttpGet("author")]
        public IEnumerable<BookDto> GetBookListSortedByAuthor()
        {
            var books = repository.GetBooksSortedByAuthor().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/author/joe
        [HttpGet("author/{author}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByAuthor(string author)
        {
            var books = repository.GetBooksContainingAuthor(author).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/title
        [HttpGet("title")]
        public IEnumerable<BookDto> GetBookListSortedByTitle()
        {
            var books = repository.GetBooksSortedByTitle().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/title/jruby
        [HttpGet("title/{title}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByTitle(string title)
        {
            var books = repository.GetBooksContainingTitle(title).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/genre
        [HttpGet("genre")]
        public IEnumerable<BookDto> GetBookListSortedByGenre()
        {
            var books = repository.GetBooksSortedByGenre().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/genre/com
        [HttpGet("genre/{genre}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByGenre(string genre)
        {
            var books = repository.GetBooksContainingGenre(genre).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/price
        [HttpGet("price")]
        public IEnumerable<BookDto> GetBookListSortedByPrice()
        {
            var books = repository.GetBooksSortedByPrice().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/price/33
        // GET api/books/price/33.0&35.0
        [HttpGet("price/{price}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByPrice(string price)
        {
            var prices =  price.GetPricesFromString();
            var fromPrice = prices[0]; 
            var toPrice = prices[1];

            var books = repository.GetBooksWithPrice(fromPrice, toPrice).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/published
        [HttpGet("published")]
        public IEnumerable<BookDto> GetBookListSortedByPublished()
        {
            var books = repository.GetBooksSortedByPublished().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/published/2012
        // GET api/books/published/2012/8
        // GET api/books/ published/2012/8/15
        [HttpGet("published/{year}/{month}/{day}")]
        [HttpGet("published/{year}/{month}")]
        [HttpGet("published/{year}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByPublishedDate(int year, int? month, int? day)
        {
            var books = repository.GetBooksFromPublishedDate(year, month, day).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }


        // GET api/books/description
        [HttpGet("description")]
        public IEnumerable<BookDto> GetBookListSortedByDescription()
        {
            var books = repository.GetBooksSortedByDescription().Select(book => book.AsDto());

            return books;
        }

        // GET api/books/description/deploy
        [HttpGet("description/{description}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksByDescription(string description)
        {
            var books = repository.GetBooksContainingDescription(description).Select(book => book.AsDto());

            if (books?.Any() != true)
            {
                return NotFound();
            }

            return books.ToList();
        }
    }
}
