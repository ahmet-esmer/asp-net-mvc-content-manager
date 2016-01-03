

using ConfigLibrary;

namespace ModelLayer
{
    class ConnectionString
    {
        public static string Build()
        {
            return ConfigHelper.GetConnectionString();
        }
    }
}
