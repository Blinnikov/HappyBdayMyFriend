using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(executingAssembly);
            builder.RegisterAssemblyModules(executingAssembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}