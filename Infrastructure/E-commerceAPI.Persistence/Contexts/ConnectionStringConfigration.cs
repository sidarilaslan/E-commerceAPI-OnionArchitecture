using Microsoft.Extensions.Configuration;
using System.IO;

namespace E_commerceAPI.Persistence.Contexts
{
    public static class ConnectionStringConfiguration
    {
        private static IConfiguration _configuration;

        static ConnectionStringConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../E-commerce.API"))
                .AddJsonFile("appsettings.json").Build();
        }

        public static string GetLocalMssqlServerConnectionString()
        {
            return _configuration.GetConnectionString("localMssqlServer");
        }
    }
}
