using System;
namespace BookSubscriptions.API.Models
{
    public class BookDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
    }
}
