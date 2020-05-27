using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Infrastructure.Data.Entities;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using System.Collections.Generic;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories
{
    public class SubscriptionRepository //: ISubscriptionRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public SubscriptionRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        //public async Task<CreateSubscriptionResponse> CreateAsync(User user, Book book)
        //{
        //    var subscription = new Subscribtion
        //    {
        //        AppUser = _mapper.Map<User, AppUser>(user),
        //        Book = book

        //    };
        //    //var createSubscriptionResult = await _dbContext.Subscribtions.AddAsync(subscription);





        //    return new CreateSubscriptionResponse(appUser.Id,
        //        identityResult.Succeeded,
        //        identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));

        //}


    }
}
