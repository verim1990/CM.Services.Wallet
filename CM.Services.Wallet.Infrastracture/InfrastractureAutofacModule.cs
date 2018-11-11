using Autofac;
using CM.Services.Wallet.Infrastracture.Repositories;
using CM.Shared.Kernel.Application.Interfaces.Repository;
using CM.Shared.Kernel.Application.Repository;
using System.Reflection;
using Module = Autofac.Module;

namespace CM.Services.Wallet.Infrastracture
{
    public class InfrastractureAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register repositories
            builder
                .RegisterAssemblyTypes(typeof(UserRepository).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .AsClosedTypesOf(typeof(EFRepository<,>));

            builder
                .RegisterGeneric(typeof(EFRepository<,>))
                .As(typeof(IRepository<>));
        }
    }
}