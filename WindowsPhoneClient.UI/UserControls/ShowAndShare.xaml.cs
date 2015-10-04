using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;

namespace WindowsPhoneClient.UI.UserControls
{
    public partial class ShowAndShare : UserControl
    {
        public static readonly DependencyProperty MapPositionProperty =
            DependencyProperty.Register("MapPosition", typeof(GeoCoordinate), typeof(ShowAndShare), null);

        public GeoCoordinate MapPosition
        {
            get { return (GeoCoordinate)GetValue(MapPositionProperty); }
            set { SetValue(MapPositionProperty, value); }
        }
        
        public ShowAndShare()
        {
            InitializeComponent();
        }

        private async void MapLoaded(object sender, RoutedEventArgs e)
        {
            var geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            var geoPosition = await geolocator.GetGeopositionAsync();

            Map.Center = new GeoCoordinate(geoPosition.Coordinate.Latitude, geoPosition.Coordinate.Longitude);
            Map.ZoomLevel = 15;
        }
    }
}
