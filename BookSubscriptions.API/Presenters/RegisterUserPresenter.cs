using System.Net;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Api.Serialization;
using BookSubscriptions.Presenters;

namespace BookSubscriptions.Api.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
