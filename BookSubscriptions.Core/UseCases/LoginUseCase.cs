using System.Threading.Tasks;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.Services;
using BookSubscriptions.Core.Interfaces.UseCases;

namespace BookSubscriptions.Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.Email) && !string.IsNullOrEmpty(message.Password))
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindByEmail(message.Email);
                if (user != null)
                {
                    // validate password
                    if (await _userRepository.CheckPassword(user, message.Password))
                    {
                        // generate token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName),true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
