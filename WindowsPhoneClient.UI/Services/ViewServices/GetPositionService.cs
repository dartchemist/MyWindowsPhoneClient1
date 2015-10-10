using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using WindowsPhoneClient.UI.Models;

namespace WindowsPhoneClient.UI.Services.ViewServices
{
    public class GetPositionService : IGetPositionService
    {   
        public async Task<CoordinateModel> GetCurrentPosition()
        {
            var geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            var currentPosition = await geolocator.GetGeopositionAsync();
            return new CoordinateModel
            {
                Latitude = currentPosition.Coordinate.Latitude,
                Longitude = currentPosition.Coordinate.Longitude
            };
        }
    }
}
