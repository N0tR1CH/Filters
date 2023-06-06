namespace Filters.Services
{
    public class GeoService : IGeoService
    {
        public async Task<string> GetCountry(string ipAddress)
        {
            using (var client = new HttpClient())
            {
                var info = await client.GetStringAsync($"http://edns.ip-api.com/");
                return info;
            }
        }
    }
}
