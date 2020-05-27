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
    public sealed class SubscribeToBookUseCase //: ISubscribeToBookUseCase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public SubscribeToBookUseCase(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        //public  Task<bool> Handle(BookSubscriptionRequest message, IOutputPort<BookSubscriptionResponse> outputPort)
        //{
        //    if (!string.IsNullOrEmpty(message.UserId.ToString()) && !string.IsNullOrEmpty(message.BookId.ToString()))
        //    {
        //        // confirm we have a user with the given name
        //       // var user = await _subscriptionRepository.FindByEmail(message.Email);
        //        //if (user != null)
        //        //{
        //        //    // validate password
        //        //    if (await _userRepository.CheckPassword(user, message.Password))
        //        //    {
        //        //        // generate token
        //        //        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName),true));
        //        //        return true;
        //        //    }
        //        //}
        //    }
        //   // outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid email or password.") }));
        //    return false;
        //}
    }
}
