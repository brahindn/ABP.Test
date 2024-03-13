using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebsiteParsing.Application.Services.Contracts;
using WebsiteParsing.Application.Services.Implementation;
using WebsiteParsing.DataAccess;
using WebsiteParsing.DataAccess.Repositories.Contracts;
using WebsiteParsing.DataAccess.Repositories.Implementation;

namespace WebsiteParsing
{
    public class Startup
    {
        private IConfiguration Config { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            Config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Config);
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
