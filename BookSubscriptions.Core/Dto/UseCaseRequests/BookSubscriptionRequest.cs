using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;

namespace BookSubscriptions.Core.Dto.UseCaseRequests
{
    public class BookSubscriptionRequest : IUseCaseRequest<BookSubscriptionResponse>
    {
        public int UserId { get; }
        public int BookId { get; }

        public BookSubscriptionRequest(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
