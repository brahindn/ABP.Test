using Microsoft.Extensions.DependencyInjection;
using WebsiteParsing;
using WebsiteParsing.Application.Services.Contracts;

var startup = new Startup();
var services = new ServiceCollection();

startup.ConfigureServices(services);

var serviceProvider =  services.BuildServiceProvider();
var serviceManager = serviceProvider.GetRequiredService<IServiceManager>();

await TestDataInDataBase();


Console.ReadLine();



async Task TestDataInDataBase()
{
    try
    {
        var date = DateTime.Parse("10/10/2023");
        await serviceManager.CarService.CreateCarAsync("Audi", 7770777, date);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Something went wrong: {ex.InnerException.Message}");
    }
    try
    {
        await serviceManager.EquipmentService.CreateEquipmentAsync(7770777, "EquipmentForReallyMen", "Engine_1", "body_1", "4.8", "hell", "gear", "cab_1", "transmissionModel", "loadingCapacity");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Something went wrong: {ex.InnerException.Message}");
    }

    Console.WriteLine("Test method is done");
}