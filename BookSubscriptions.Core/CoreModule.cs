using Autofac;
using BookSubscriptions.Core.Interfaces.UseCases;
using BookSubscriptions.Core.UseCases;

namespace BookSubscriptions.Core
{
  public class CoreModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
    }
  }
}
