using Microsoft.Extensions.DependencyInjection;
using WebsiteParsing.DataAccess;

namespace WebsiteParsing.Console.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>();
        }
    }
}
