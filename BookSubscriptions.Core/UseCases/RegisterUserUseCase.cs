using System.Linq;
using System.Threading.Tasks;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.UseCases;

namespace BookSubscriptions.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.FirstName, message.LastName,message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
