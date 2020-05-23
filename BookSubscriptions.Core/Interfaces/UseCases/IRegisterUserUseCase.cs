using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;

namespace BookSubscriptions.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
