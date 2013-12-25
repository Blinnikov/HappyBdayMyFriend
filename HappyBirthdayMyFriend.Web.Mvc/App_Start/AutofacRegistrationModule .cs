using Autofac;
using HappyBdayMyFriend.DataAccess;
using HappyBdayMyFriend.DataAccess.Contracts;

namespace HappyBirthdayMyFriend.Web.Mvc
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RepositoryFactories>()
                .As<RepositoryFactories>()
                .SingleInstance();

            builder
                .RegisterType<RepositoryProvider>()
                .As<IRepositoryProvider>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}