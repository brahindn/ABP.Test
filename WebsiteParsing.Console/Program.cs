using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics;
using WebsiteParsing;
using WebsiteParsing.Application.Services.Contracts;
using static System.Net.WebRequestMethods;

var startup = new Startup();
var services = new ServiceCollection();

startup.ConfigureServices(services);

var serviceProvider =  services.BuildServiceProvider();
var serviceManager = serviceProvider.GetRequiredService<IServiceManager>();

await TestDataInDataBase();

var mainAddress = "https://www.ilcats.ru/toyota/?function=getModels&market=EU";

var dataCar = GetDataFromModelCar(url: mainAddress);


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


static Dictionary<string, string> GetDataFromModelCar(string url)
{
    var carProperties = new Dictionary<string, string>();

    try
    {
        using (HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.All })
        {
            using (var client = new HttpClient(handler))
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var html = response.Content.ReadAsStringAsync().Result;

                        if (!string.IsNullOrEmpty(html))
                        {
                            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                            document.LoadHtml(html);

                            var carList = document.DocumentNode.SelectNodes(".//body[@class='toyota']//div[@class='ifMultilistBody']//div[@class='List Multilist']");

                            if(carList != null && carList.Count > 0)
                            {
                                foreach(var list in carList)
                                {
                                    var cars = list.SelectNodes("./div[@class]");

                                    if (cars != null && cars.Count > 0)
                                    {
                                        foreach(var car in cars)
                                        {
                                            try
                                            {
                                                var carModelName = car.SelectSingleNode(".//div[@class='Header']").InnerText;
                                                var carModelCode = car.SelectSingleNode(".//div[@class='List ']//div[@class='id']").InnerText;

                                                carProperties.Add(carModelName, carModelCode);
                                            }
                                            catch(Exception ex)
                                            {
                                                Console.WriteLine(ex.InnerException.Message);
                                            }
                                        }
                                    } 
                                }
                            }                                
                        }
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message.ToString());
    }

    return carProperties;
}