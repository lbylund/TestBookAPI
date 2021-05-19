using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using TestBooksJsonFile.Entities;

namespace TestBooksJsonFile.Repositories
{
    public interface IBooksRepository
    {
        IWebHostEnvironment WebHostEnvironment { get; }
       // Book GetBook(string id);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksSortedById();
        IEnumerable<Book> GetBooksContainingId(string id);
        IEnumerable<Book> GetBooksSortedByAuthor();
        IEnumerable<Book> GetBooksContainingAuthor(string author);
        IEnumerable<Book> GetBooksSortedByTitle();
        IEnumerable<Book> GetBooksContainingTitle(string title);
        IEnumerable<Book> GetBooksSortedByGenre();
        IEnumerable<Book> GetBooksContainingGenre(string genre);
        IEnumerable<Book> GetBooksSortedByPrice();
        IEnumerable<Book> GetBooksWithPrice(double fromPrice, double toPrice);
        IEnumerable<Book> GetBooksSortedByPublished();
        IEnumerable<Book> GetBooksSortedByDescription();
        IEnumerable<Book> GetBooksContainingDescription(string description);
        IEnumerable<Book> GetBooksFromPublishedDate(int year, int? month, int? day);
    }
}