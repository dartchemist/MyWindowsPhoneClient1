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
using WindowsPhoneClient.UI.ViewModels;

namespace WindowsPhoneClient.UI
{
    public partial class ShowAndShareAroundMePage : PhoneApplicationPage
    {
        public ShowAndShareAroundMePage()
        {
            InitializeComponent();
            DataContext = Application.Current.Resources["ShowAndShareAroundMeViewModel"];
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var dataContext = DataContext as ShowAndShareAroundMeViewModel;
            dataContext.AvailableParkingSpace = 50;
            base.OnNavigatedFrom(e);
        }
    }
}