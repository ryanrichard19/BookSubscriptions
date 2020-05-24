using System;

namespace BookSubscriptions.Core.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
    }
}
