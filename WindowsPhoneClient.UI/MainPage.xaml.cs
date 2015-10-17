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
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.Current.Resources["HomePageViewModel"];
        }

        private void HomePageLoaded(object sender, RoutedEventArgs e)
        {
            //sinilinkMenu.Width = (double) App.Current.Resources["ScreenWidth"];
            //sinilinkMenu.Height = (double) App.Current.Resources["ScreenHeight"];
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
            //var x = App.Current.Resources["SponsorWithLogoDataTemplate"];
            var selectedValue = lbxPartners.ItemContainerGenerator.ContainerFromItem(lbxPartners.SelectedItem) as ListBoxItem;
            selectedValue.ContentTemplate = App.Current.Resources["SelectedSponsorDataTemplate"] as DataTemplate;
        }
    }
}