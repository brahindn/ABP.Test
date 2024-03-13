namespace WebsiteParsing.Application.Services.Contracts.Services
{
    public interface ICarService
    {
        Task CreateCarAsync(string modelName, int modelCode, DateTime dateRange);
    }
}
