using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using WindowsPhoneClient.UI.ViewModels;

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

        private async void ShowAndShareLoaded(object sender, RoutedEventArgs e)
        {
            await SetMapView();
            SetMapControlItemsSource();
        }

        private async Task SetMapView()
        {
            var dataContext = DataContext as ShowAndShareAroundMeViewModel;
            await dataContext.GetCurrentUserPosition();
            if (dataContext.MapItems.Count == 0)
            {
                var currentLocation = new GeoCoordinate(dataContext.CurrentUserLocation.Latitude, dataContext.CurrentUserLocation.Longitude);
                Map.SetView(currentLocation, Map.ZoomLevel);
            }
            else
            {
                var firstPartnerLocation = new GeoCoordinate(dataContext.MapItems[0].Coordinate.Latitude, dataContext.MapItems[0].Coordinate.Longitude);
                Map.SetView(firstPartnerLocation, Map.ZoomLevel);
            }
        }

        private void SetMapControlItemsSource()
        {
            var dataContext = DataContext as ShowAndShareAroundMeViewModel;
            MapExtensions.GetChildren(Map)
                .OfType<MapItemsControl>()
                .First()
                .ItemsSource = dataContext.MapItems;
        }
    }
}
