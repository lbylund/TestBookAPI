using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestBooksJsonFile.Entities;

namespace TestBooksJsonFile.Repositories
{
    public class JsonFileRepository : IBooksRepository
    {
        public JsonFileRepository(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "books.json"); }
        }

        private Book[] BooksFromJsonFile => JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(JsonFileName));

        public IEnumerable<Book> GetBooks()
        {
            return BooksFromJsonFile;
        }

        public IEnumerable<Book> GetBooksContainingId(string id)
        {            
            var filteredBooks = BooksFromJsonFile.Where(book => book.Id.Contains(id, StringComparison.OrdinalIgnoreCase)).OrderBy(Book => Book.Id);
            return filteredBooks;
        }

        public IEnumerable<Book> GetBooksSortedById()
        {
                return BooksFromJsonFile.OrderBy(book => book.Id);
        }

        public IEnumerable<Book> GetBooksSortedByTitle()
        {
            return BooksFromJsonFile.OrderBy(book => book.Title);
        }

        public IEnumerable<Book> GetBooksContainingTitle(string title)
        {  
            var filteredBooks = BooksFromJsonFile.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).OrderBy(book => book.Title);

            return filteredBooks;
        }

        public IEnumerable<Book> GetBooksSortedByAuthor()
        {
            return BooksFromJsonFile.OrderBy(book => book.Author);
        }

        public IEnumerable<Book> GetBooksContainingAuthor(string author)
        {
            var filteredBooks = BooksFromJsonFile.Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).OrderBy(book => book.Author);

            return filteredBooks;
        }

        public IEnumerable<Book> GetBooksSortedByGenre()
        {
            return BooksFromJsonFile.OrderBy(book => book.Genre);
        }

        public IEnumerable<Book> GetBooksContainingGenre(string genre)
        {
            var filteredBooks = BooksFromJsonFile.Where(book => book.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).OrderBy(book => book.Genre);

            return filteredBooks;
        }

        public IEnumerable<Book> GetBooksSortedByPrice()
        {
            return BooksFromJsonFile.OrderBy(book => book.Price);
        }

        public IEnumerable<Book> GetBooksWithPrice(double fromPrice, double toPrice)
        {
            return !(toPrice == 0 || toPrice < fromPrice)
                ? BooksFromJsonFile.Where(book => book.Price >= fromPrice && book.Price <= toPrice).OrderBy(book => book.Price)
                : BooksFromJsonFile.Where(book => book.Price == fromPrice).OrderBy(book => book.Price);
        }

        public IEnumerable<Book> GetBooksSortedByPublished()
        {
            return BooksFromJsonFile.OrderBy(book => book.Publish_date);
        }

        public IEnumerable<Book> GetBooksSortedByDescription()
        {
            return BooksFromJsonFile.OrderBy(book => book.Description);
        }

        public IEnumerable<Book> GetBooksContainingDescription(string description)
        {
            var filteredBooks = BooksFromJsonFile.Where(book => book.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).OrderBy(book => book.Description);

            return filteredBooks;
        }

        public IEnumerable<Book> GetBooksFromPublishedDate(int year, int? month, int? day)
        {
            day = (day > 0 && day < 32) ? day : 1;
            month = (month > 0 && month < 13) ? month : 1;
            DateTime dt = new(year, (int)month, (int)day);
            var filteredBooks = BooksFromJsonFile.Where(book => book.Publish_date >= dt).OrderBy(book => book.Publish_date);

            return filteredBooks;
        }
    }
}
