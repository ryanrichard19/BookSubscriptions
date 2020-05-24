using System.Collections.Generic;
using System.Threading.Tasks;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;

namespace BookSubscriptions.Core.Interfaces.Gateways.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
    }
}
