using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;

namespace BookSubscriptions.Core.Dto.UseCaseRequests
{
  public class LoginRequest : IUseCaseRequest<LoginResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public LoginRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
