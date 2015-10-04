using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsPhoneClient.UI.Models;
using WindowsPhoneClient.UI.Resources;
using WindowsPhoneClient.UI.ViewModels;

namespace WindowsPhoneClient.UI
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.Current.Resources["HomePageViewModel"];
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void HomePageLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel.LoadPartnersInformation();
        }

        private void SponsorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = lbxPartners.SelectedItem as PartnerModel;
            if (selectedItem.LogoRelativePath.Contains("default"))
            {
                return;
            }
            var selectedValue = lbxPartners.ItemContainerGenerator.ContainerFromItem(lbxPartners.SelectedItem) as ListBoxItem;
            selectedValue.ContentTemplate = App.Current.Resources["SelectedSponsorDataTemplate"] as DataTemplate;
        }
    }
}