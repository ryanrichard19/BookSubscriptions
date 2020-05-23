using Autofac;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.Services;
using BookSubscriptions.Infrastructure.Auth;
using BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories;
namespace BookSubscriptions.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
