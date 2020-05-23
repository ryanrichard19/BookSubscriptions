using System.Threading.Tasks;
using BookSubscriptions.Core.Dto;

namespace BookSubscriptions.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
