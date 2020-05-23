using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;

namespace BookSubscriptions.Core.Interfaces.UseCases
{
  public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
  {
  }
}
