using System;

namespace TestBooksJsonFile.Entities
{
    public record Book
    {
        public string Id { get; init; }
        public string Author { get; init; }
        public string Title { get; init; }
        public string Genre { get; init; }  
        public double Price { get; init; }
        public string Description { get; init; }
        private DateTime _Publish_date;
        public DateTime Publish_date
        {
            get
            {
                return _Publish_date.Date;      //we just need the date part of DateTime
            }

            init { _Publish_date = value; }
        }
    }
}