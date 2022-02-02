using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Kosha.Core.Contract.AuthenticationCode;
using Kosha.Core.Services.AuthenticationCode;
using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Services.UserToken;
using Kosha.DataLayer.Context;
using FishHoghoghi.Controllers;
 
namespace FishHoghoghi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            
            var container = new UnityContainer();

            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            /*container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());*/
            container.RegisterType<IUserHelper, UserHelper>();
            container.RegisterType<IAuthenticationCodeService, AuthenticationCodeService>();
            container.RegisterType<IUserTokenService, UserTokenService>();
            container.RegisterType<IUserContract, UserContract>();
            container.RegisterType<IController, TestController>("Test");


            return container;
        }
    }
}