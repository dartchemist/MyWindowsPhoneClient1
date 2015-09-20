using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace WindowsPhoneClient.UI.ViewServices
{
    public class NavigationService : INavigationService
    {
        public void Navigate(string pageUri)
        {
            var currentPage = App.RootFrame.Content as PhoneApplicationPage;
            if (currentPage != null)
            {
                currentPage.NavigationService.Navigate(new Uri(pageUri, UriKind.Relative));
            }
        }

        public void GoBack()
        {
            var currentPage = App.RootFrame.Content as PhoneApplicationPage;
            if (currentPage != null)
            {
                currentPage.NavigationService.GoBack();
            }
        }
    }
}
