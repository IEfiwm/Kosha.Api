using FishHoghoghi.App_Start;
using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Contract.AuthenticationCode;
using Kosha.Core.Services.AuthenticationCode;
using Kosha.Core.Services.UserToken;
using Kosha.DataLayer.Context;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace FishHoghoghi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            container.RegisterType<IUserHelper, UserHelper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationCodeService, AuthenticationCodeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserTokenService, UserTokenService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserContract, UserContract>(new HierarchicalLifetimeManager());

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}