using System.ComponentModel.DataAnnotations;

namespace BookSubscriptions.Api.Models.Request
{
    public class BookSubscriptionRequest
    {
       
        public int UserId { get; set; }

        public int BookId { get; set; }
    }
}
