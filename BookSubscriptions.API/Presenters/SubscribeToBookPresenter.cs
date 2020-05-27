using System.Net;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Api.Serialization;
using BookSubscriptions.Presenters;

namespace BookSubscriptions.Api.Presenters
{
  public sealed class SubscribeToBookPresenter : IOutputPort<BookSubscriptionResponse>
  {
    public JsonContentResult ContentResult { get; }

    public SubscribeToBookPresenter()
    {
      ContentResult = new JsonContentResult();
    }

    public void Handle(BookSubscriptionResponse response)
    {
      ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
      ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.BookIdList) : JsonSerializer.SerializeObject(response.Errors);
    }
  }
}
