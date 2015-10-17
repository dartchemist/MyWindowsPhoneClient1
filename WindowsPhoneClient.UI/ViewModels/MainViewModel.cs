using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using WindowsPhoneClient.CommonConstants;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Infrastrucure.Commands;
using WindowsPhoneClient.UI.Models;
using WindowsPhoneClient.UI.Resources;
using WindowsPhoneClient.UI.Services;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IGetPartnersInformationService _getPartnersInformationService;
        private readonly IMessageService                _messageService;

        private readonly ObservableCollection<PartnerModel> _partnersInformation = new ObservableCollection<PartnerModel>();

        private bool _isSplashScreenVisible;
        public bool IsSplashScreenVisible
        {
            get { return _isSplashScreenVisible; }
            set { SetField<bool>(ref _isSplashScreenVisible, value); }
        }
        
        private ICommand _showSinilinkMenuCommand;
        public ICommand ShowSinilinkMenuCommand
        {
            get
            {
                if (_showSinilinkMenuCommand == null)
                {
                    _showSinilinkMenuCommand = new DelegateCommand(ShowSinilinkMenu);
                }
                return _showSinilinkMenuCommand;
            }
        }

        private void ShowSinilinkMenu(object parameter)
        {
            _messageService.ShowMessage("Hello from Sinilink", "Sinilink Message");
        }

        private ICommand _showPartnerInformationCommand;
        public ICommand ShowPartnerInformationCommand
        {
            get
            {
                if (_showPartnerInformationCommand == null)
                {
                    _showPartnerInformationCommand = new DelegateCommand(ShowPartnerInformation, null);
                }
                return _showPartnerInformationCommand;
            }
        }

        private void ShowPartnerInformation(object parameter)
        {
            NavigationService.Navigate("/PartnerInformationPage.xaml");
        }
        
        private ICommand _showAroundMeCommand;
        public ICommand ShowAroundMeCommand
        {
            get
            {
                if (_showAroundMeCommand == null)
                {
                    _showAroundMeCommand = new DelegateCommand(ShowAroundMe, null);
                }
                return _showAroundMeCommand;
            }
        }

        private void ShowAroundMe(object parameter)
        {
            NavigationService.Navigate("/ShowAndSharePage.xaml");
        }
    
        public ObservableCollection<PartnerModel> PartnersInformation
        {
            get { return _partnersInformation; }
        }

        public MainViewModel(IStorageService storageService, IGetPartnersInformationService getPartnersInformationService, IMessageService messageService, INavigationService navigationService)
            :base(navigationService, storageService)
        {
            _getPartnersInformationService = getPartnersInformationService;
            _messageService = messageService;
        }

        public async void LoadPartnersInformation()
        {
            if (_partnersInformation.Count > 0)
            {
                return;
            }

            try
            {
                IsSplashScreenVisible = true;
                var partnersInformation = await _getPartnersInformationService.GetPartnersInformation();
                var updateTimerValue = _getPartnersInformationService.GetTimerDuration();
                StorageService.AddItem(ApplicationCommonConstants.UpdateTimerDurationStorageKey, updateTimerValue);
                foreach (var partner in partnersInformation)
                {
                    _partnersInformation.Add(Mapper.Map<Partner, PartnerModel>(partner));
                }
                StorageService.AddItem(ApplicationCommonConstants.PartnersInformationStorageKey, _partnersInformation);
            }
            catch (Exception)
            {
                //TODO: Implement Retry strategy
                _messageService.ShowMessage(AppResources.CannotLoadPartnersInformation, AppResources.ErrorTitle);
            }
            finally
            {
                IsSplashScreenVisible = false;
            }
        }
    }
}
