using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Windows.Devices.Geolocation;
using WindowsPhoneClient.UI.Models;

namespace WindowsPhoneClient.UI.Converters
{
    public class GeoCoordinateToCoordinateModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var coordinate = value as CoordinateModel;
            if (coordinate == null)
                return new GeoCoordinate();

            var geoCoordinate = new GeoCoordinate();
            geoCoordinate.Latitude = coordinate.Latitude;
            geoCoordinate.Longitude = coordinate.Longitude;

            return geoCoordinate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var geoCoordinate = value as GeoCoordinate;
            if (geoCoordinate == null)
                return new CoordinateModel();

            return new CoordinateModel
            {
                Latitude = geoCoordinate.Latitude,
                Longitude = geoCoordinate.Longitude
            };
        }
    }
}
