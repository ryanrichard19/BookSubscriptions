using System.Collections.Generic;
using System.Threading.Tasks;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;
using BookSubscriptions.Core.Dto.UseCaseResponses;

namespace BookSubscriptions.Core.Interfaces.Gateways.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<CreateSubscriptionResponse> CreateAsync(User user, Book book);
    }
}
