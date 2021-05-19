using TestBooksJsonFile.Dtos;
using TestBooksJsonFile.Entities;

namespace TestBooksJsonFile
{
    public static class Extensions
    {
        public static BookDto AsDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                Price = book.Price,
                Publish_date = book.Publish_date,
                Description = book.Description
            };
        }

        public static double[] GetPricesFromString(this string priceString)
        {
            string[] priceArr = priceString.Split("&");

            if (priceArr.Length > 1)
            {
                double.TryParse(priceArr[0], out double price);
                double.TryParse(priceArr[1], out double toPrice);
                return new []{ price, toPrice };
            }
            else
            {
                double.TryParse(priceArr[0], out double price);
                return new [] { price, 0};
            }

        }
    }
}
