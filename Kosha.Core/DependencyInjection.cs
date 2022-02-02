using Kosha.Core.Bussinus.SMHelper.Provider;
using System.Configuration;
namespace Kosha.Core
{
    public static class DependencyInjection
    {
        public static void Initialise(ConnectionStringSettingsCollection connectionStrings)
        {
            DataAccessObject.Init(connectionStrings);
        }
         
    }
     
}
