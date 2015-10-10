using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
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
        private ShowAndShareAroundMeViewModel _dataContext;
        
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

        private void ShowAndShareLoaded(object sender, RoutedEventArgs e)
        {
            _dataContext = DataContext as ShowAndShareAroundMeViewModel;
            SetMapView();
            //SetMapControlItemsSource();
        }

        private void SetMapView()
        {
            if (_dataContext.MapItems.Count == 0)
            {
                var currentLocation = new GeoCoordinate(_dataContext.CurrentLocation.Latitude, _dataContext.CurrentLocation.Longitude);
                Map.SetView(currentLocation, Map.ZoomLevel);
            }
            else
            {
                var firstPartnerLocation = new GeoCoordinate(_dataContext.MapItems[0].Coordinate.Latitude, _dataContext.MapItems[0].Coordinate.Longitude);
                Map.SetView(firstPartnerLocation, Map.ZoomLevel);
            }
        }

        private void SetMapControlItemsSource()
        {
            MapExtensions.GetChildren(Map)
                .OfType<MapItemsControl>()
                .First()
                .ItemsSource = _dataContext.MapItems;
        }
    }
}
