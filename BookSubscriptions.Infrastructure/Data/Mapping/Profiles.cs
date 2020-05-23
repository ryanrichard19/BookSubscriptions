using AutoMapper;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Infrastructure.Data.Entities;


namespace BookSubscriptions.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash});
            CreateMap<AppUser, User>().ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));
        }
    }
}
