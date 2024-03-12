using Microsoft.Extensions.DependencyInjection;
using WebsiteParsing;

var startup = new Startup();
var services = new ServiceCollection();

startup.ConfigureServices(services);