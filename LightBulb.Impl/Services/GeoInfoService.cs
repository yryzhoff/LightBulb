using System.Diagnostics;
using System.Threading.Tasks;
using LightBulb.Models;
using Newtonsoft.Json.Linq;
using Tyrrrz.Extensions;

namespace LightBulb.Services
{
    public class GeoInfoService : IGeoInfoService
    {
        private readonly IHttpService _httpService;

        public GeoInfoService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<GeoInfo> GetAsync()
        {
            var response = await _httpService.GetStringAsync("http://freegeoip.net/json");
            if (response.IsBlank()) return null;

            try
            {
                // Parse
                var parsed = JToken.Parse(response);

                // Extract data
                var countryName = parsed["country_name"].Value<string>().NullIfBlank();
                var countryCode = parsed["country_code"].Value<string>().NullIfBlank();
                var city = parsed["city"].Value<string>().NullIfBlank();
                var lat = parsed["latitude"].Value<double>();
                var lng = parsed["longitude"].Value<double>();

                // Populate
                var result = new GeoInfo(countryName, countryCode, city, lat, lng);

                return result;
            }
            catch
            {
                Debug.WriteLine("Could not deserialize geo info", GetType().Name);
                return null;
            }
        }
    }
}