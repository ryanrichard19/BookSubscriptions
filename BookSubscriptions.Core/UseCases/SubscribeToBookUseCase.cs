using System.Threading.Tasks;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.UseCases;

namespace BookSubscriptions.Core.UseCases
{
    public sealed class SubscribeToBookUseCase : ISubscribeToBookUseCase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public SubscribeToBookUseCase(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(BookSubscriptionRequest message, IOutputPort<BookSubscriptionResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserId.ToString()) && !string.IsNullOrEmpty(message.BookId.ToString()))
            {

                var userid = await _subscriptionRepository.CreateAsync(message.UserId, message.BookId);
                    // validate password
                    if (true)
                    {
                        // generate token
                        //outputPort.Handle(new BookSubscriptionResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName), true));
                        outputPort.Handle(new BookSubscriptionResponse(new[] { new Error("login_failure", "Invalid email or password.") }));
                        return true;
                    }
                
            }
             outputPort.Handle(new BookSubscriptionResponse(new[] { new Error("login_failure", "Invalid email or password.") }));
            return false;
        }
    }
}
