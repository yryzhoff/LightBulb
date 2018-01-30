using System.Threading.Tasks;
using LightBulb.Models;

namespace LightBulb.Services
{
    public interface IGeoInfoService
    {
        /// <summary>
        /// Get geoinfo for current location
        /// </summary>
        Task<GeoInfo> GetAsync();
    }
}