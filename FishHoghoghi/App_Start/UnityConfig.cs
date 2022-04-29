using FishHoghoghi.App_Start;
using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Contract.AuthenticationCode;
using Kosha.Core.Contract.Bank;
using Kosha.Core.Contract.Imported;
using Kosha.Core.Services.AuthenticationCode;
using Kosha.Core.Services.Imported;
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

            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            container.RegisterType<IUserHelper, UserHelper>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectHelper, ProjectHelper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationCodeService, AuthenticationCodeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserTokenService, UserTokenService>(new HierarchicalLifetimeManager());
            container.RegisterType<IImportedService, ImportedService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserContract, UserContract>(new HierarchicalLifetimeManager());
            container.RegisterType<IBankContract, BankContract>(new HierarchicalLifetimeManager());
            container.RegisterType<IImportedContract, ImportedContract>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new App_Start.UnityDependencyResolver(container);

        }
    }
}