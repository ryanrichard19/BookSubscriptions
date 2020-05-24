using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Infrastructure.Data.Entities;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {

            var appUser = new AppUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Email = user.Email,
                EmailConfirmed = true
            };

            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(appUser.Id,
                identityResult.Succeeded,
                identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));


        }

        public async Task<User> FindByName(string userName)
        {
            return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
        }

        public async Task<User> FindByEmail(string email)
        {
            return _mapper.Map<User>(await _userManager.FindByEmailAsync(email));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }
    }
}
