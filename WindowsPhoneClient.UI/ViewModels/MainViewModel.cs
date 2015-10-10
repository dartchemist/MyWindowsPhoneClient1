using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
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
        private readonly INavigationService             _navigationService;

        private readonly ObservableCollection<PartnerModel> _partnersInformation = new ObservableCollection<PartnerModel>();

        private bool _isSplashScreenVisible;
        public bool IsSplashScreenVisible
        {
            get { return _isSplashScreenVisible; }
            set { SetField<bool>(ref _isSplashScreenVisible, value); }
        }
        
        private readonly ICommand _showSinilinkMenuCommand = new DelegateCommand((parameter) =>
            {
                
            }, null);
        public ICommand ShowSinilinkMenuCommand
        {
            get { return _showSinilinkMenuCommand; }
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
            _navigationService.Navigate("/ShowAndSharePage.xaml");
        }
    
        public ObservableCollection<PartnerModel> PartnersInformation
        {
            get { return _partnersInformation; }
        }

        public MainViewModel(IStorageService storageService, IGetPartnersInformationService getPartnersInformationService, IMessageService messageService, INavigationService navigationService)
            :base(storageService)
        {
            _getPartnersInformationService = getPartnersInformationService;
            _messageService = messageService;
            _navigationService = navigationService;
        }

        public async void LoadPartnersInformation()
        {
            if (_partnersInformation.Count > 0)
            {
                return;
            }
            
            IEnumerable<Partner> partnersInformation = null;
            try
            {
                IsSplashScreenVisible = true;
                partnersInformation = await _getPartnersInformationService.GetPartnersInformation();
                foreach (var partner in partnersInformation)
                {
                    _partnersInformation.Add(Mapper.Map<Partner, PartnerModel>(partner));
                }
            }
            catch (Exception)
            {
                //TODO Implement Retry strategy
                _messageService.ShowMessage(AppResources.CannotLoadPartnersInformation, AppResources.ErrorTitle);
                return;
            }
            finally
            {
                IsSplashScreenVisible = false;
            }
        }
    }
}
