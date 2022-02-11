using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.DataLayer.Helper
{
    public static class ContextManager
    {
        public static ConnectionStringSettingsCollection connectionStrings;
        public static void Init(ConnectionStringSettingsCollection connectionString)
        {
            connectionStrings = connectionString;
        }
    }
}
