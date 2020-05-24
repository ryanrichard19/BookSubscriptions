using System;
using BookSubscriptions.Api.Presenters;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.UseCases;
using BookSubscriptions.Core.UseCases;
using Microsoft.Extensions.DependencyInjection;
using BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories;
using BookSubscriptions.Core.Interfaces.Services;
using BookSubscriptions.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using BookSubscriptions.Infrastructure.Data.Entities;

namespace BookSubscriptions.API.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddSingleton<RegisterUserPresenter>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();
            services.AddScoped<LoginPresenter>();

            services.AddScoped<ILoginUseCase, LoginUseCase>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddScoped<UserManager<AppUser>>();

    }
    }
}
