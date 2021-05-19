using System;

namespace TestBooksJsonFile.Dtos
{
    public record BookDto
    {
        public string Id { get; init; }
        public string Author { get; init; }
        public string Title { get; init; }
        public string Genre { get; init; }
        public double Price { get; init; }

        private DateTime _Publish_date;
        public DateTime Publish_date
        {
            get
            {
                return _Publish_date.Date;      //returns just the Date part
            }

            init { _Publish_date = value; }
        }
        public string Description { get; init; }
    }
}
