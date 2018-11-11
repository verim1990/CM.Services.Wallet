using Autofac;
using CM.Services.Wallet.Concrete.Domain.Services;
using CM.Services.Wallet.Contract.Domain.Services;
using Module = Autofac.Module;

namespace CM.Services.Wallet.Concrete
{
    public class ConcreteAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>().InstancePerLifetimeScope();
        }
    }
}