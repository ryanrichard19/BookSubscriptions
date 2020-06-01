using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public SubscriptionRepository(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IUserRepository userRepository,
            IBookRepository bookRepository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }


        public async Task<CreateSubscriptionResponse> CreateAsync(string userId, int bookId)
        {
            AppUser appuser = await _userRepository.FindByIdAsync(userId);
            bool subscriptionResult = true;
            var sub = new Subscribtion
            {
                AppUserId = userId,
                BookId = bookId

            };
            try
            {

                await _dbContext.Subscribtion.AddAsync(sub);
                await _dbContext.SaveChangesAsync();
                var userSubscriptionList = await _dbContext.Subscribtion.AsNoTracking()
                            .Include(s => s.Book)
                            .Where(s => s.AppUserId == userId)
                            .ToListAsync();

            } catch (Exception ex)
            {
                subscriptionResult = false;
                IEnumerable<Error> errors = new IEnumerable<Error>();
                return new CreateSubscriptionResponse(null,
             false,
             new IEnumerable<Error>()..Add( new Error(ex.GetType().ToString(), ex.Message));

            }   

            var tem = new List<int>();
            return new CreateSubscriptionResponse(userSubscriptionList,
                subscriptionResult, subscriptionResult ? null : new Error(
                 null);
            return new CreateUserResponse(appUser.Id,
              identityResult.Succeeded,
              identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }


    }
}
