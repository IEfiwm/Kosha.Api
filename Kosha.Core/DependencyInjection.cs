using Kosha.Core.Bussinus.SMHelper.Provider;
using Kosha.DataLayer.Helper;
using System.Configuration;
namespace Kosha.Core
{
    public static class DependencyInjection
    {
        public static ConnectionStringSettingsCollection connectionStrings;
        public static void Initialise()
        {
            DataAccessObject.Init(connectionStrings);
            ContextManager.Init(connectionStrings);
        }
         
    }
     
}
