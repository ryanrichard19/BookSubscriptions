using System.Collections.Generic;

namespace BookSubscriptions.Core.Dto.GatewayResponses.Repositories
{
    public sealed class CreateSubscriptionResponse : BaseGatewayResponse
    {
        public IEnumerable<int> BooksIdList { get; }
        public CreateSubscriptionResponse(IEnumerable<int> booksIdList, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            BooksIdList = booksIdList;
        }
    }
}
