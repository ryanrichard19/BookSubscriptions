using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;

namespace BookSubscriptions.Core.Dto.UseCaseRequests
{
    public class BookSubscriptionRequest : IUseCaseRequest<BookSubscriptionResponse>
    {
        public string UserId { get; }
        public int BookId { get; }

        public BookSubscriptionRequest(string userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
