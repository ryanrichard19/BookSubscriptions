using System.Net;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Api.Serialization;
using BookSubscriptions.Presenters;

namespace BookSubscriptions.Api.Presenters
{
  public sealed class LoginPresenter : IOutputPort<LoginResponse>
  {
    public JsonContentResult ContentResult { get; }

    public LoginPresenter()
    {
      ContentResult = new JsonContentResult();
    }

    public void Handle(LoginResponse response)
    {
      ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
      ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Token) : JsonSerializer.SerializeObject(response.Errors);
    }
  }
}
