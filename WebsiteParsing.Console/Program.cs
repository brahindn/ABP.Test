using Microsoft.Extensions.DependencyInjection;
using WebsiteParsing;
using WebsiteParsing.Application.Services.Contracts;

var startup = new Startup();
var services = new ServiceCollection();

startup.ConfigureServices(services);

var serviceProvider =  services.BuildServiceProvider();
var serviceManager = serviceProvider.GetRequiredService<IServiceManager>();
var mainAddress = "https://www.ilcats.ru/toyota/?function=getModels&market=EU";

var dataCar = GetDataFromModelCar(url: mainAddress);

//Для економії часу в поле "Дата випуску" вставляеться DataTime.Now (для економії часу.) Тому час кожногу разу різний і БД записує такий результат, що на перший погляд виглядає як запис дублікатів.

Console.ReadLine();


async Task GetDataFromModelCar(string url)
{
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
                                                var carModelCode = int.Parse(car.SelectSingleNode(".//div[@class='List ']//div[@class='id']").InnerText);

                                                await serviceManager.CarService.CreateCarAsync(carModelName, carModelCode, DateTime.Now);
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
}
