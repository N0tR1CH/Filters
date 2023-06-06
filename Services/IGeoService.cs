namespace Filters.Services
{
    public interface IGeoService
    {
        Task<string> GetCountry(string ipAddress);
    }
}
