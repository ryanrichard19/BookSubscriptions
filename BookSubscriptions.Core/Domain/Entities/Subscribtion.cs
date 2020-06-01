using System;
using BookSubscriptions.Core.Domain.Entities;

namespace BookSubscriptions.Core.Domain.Entities
{
    public class Subscribtion : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
