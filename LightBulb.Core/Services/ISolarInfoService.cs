using System;
using LightBulb.Models;

namespace LightBulb.Services
{
    public interface ISolarInfoService
    {
        /// <summary>
        /// Get solar info for given coordinates and date
        /// </summary>
        SolarInfo Get(double latitude, double longitude, DateTime date);
    }
}