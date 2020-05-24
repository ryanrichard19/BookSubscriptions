using System.Threading.Tasks;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;

namespace BookSubscriptions.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<User> FindByEmail(string email);
        Task<bool> CheckPassword(User user, string password);
    }
}
