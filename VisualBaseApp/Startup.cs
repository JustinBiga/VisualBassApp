using System;
using MySql.Data.MySqlClient;

namespace VisualBaseApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddSingleton<MySqlConnection>(sp =>
            {
                return new MySqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            });

            // ...
        }
    }
}


