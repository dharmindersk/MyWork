using System.Configuration;
using System.Collections.Specialized;

namespace Utility
{
    public class Configuration
    {
        // Variables
        private StringDictionary Parameters;

        public Configuration()
        {
            Parameters = new StringDictionary();

            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                Parameters[key] = ConfigurationManager.AppSettings[key];
            }
        }
        // Retrieve a parameter value if it exists
        public string this[string Param]
        {
            get
            {
                return (Parameters[Param]);
            }
        }
    }

}
