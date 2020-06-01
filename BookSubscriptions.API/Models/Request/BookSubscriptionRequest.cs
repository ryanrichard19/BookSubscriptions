using System.ComponentModel.DataAnnotations;

namespace BookSubscriptions.Api.Models.Request
{
    public class BookSubscriptionRequest
    {
       
        public string UserId { get; set; }

        public int BookId { get; set; }
    }
}
