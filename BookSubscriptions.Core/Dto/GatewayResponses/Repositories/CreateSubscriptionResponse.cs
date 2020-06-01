using System.Collections.Generic;
using BookSubscriptions.Core.Domain.Entities;

namespace BookSubscriptions.Core.Dto.GatewayResponses.Repositories
{
    public sealed class CreateSubscriptionResponse : BaseGatewayResponse
    {
        public IEnumerable<Subscribtion> UserSubscriptionList { get; }
        public CreateSubscriptionResponse(IEnumerable<Subscribtion> userSubscriptionList, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UserSubscriptionList = userSubscriptionList;
        }
    }
}
