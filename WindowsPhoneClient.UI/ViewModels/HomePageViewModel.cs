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
using WindowsPhoneClient.UI.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class HomePageViewModel : BindingBase
    {
        private readonly IGetPartnersInformationService _getPartnersInformationService;
        private readonly IMessageService                _messageService;
        private readonly INavigationService             _navigationService;

        private readonly ObservableCollection<PartnerModel> _partnersInformation = new ObservableCollection<PartnerModel>();

        private readonly ICommand _showSinilinkMenuCommand = new DelegateCommand((parameter) =>
            {
                
            }, null);
        public ICommand ShowSinilinkMenuCommand
        {
            get { return _showSinilinkMenuCommand; }
        }
    
        public ObservableCollection<PartnerModel> PartnersInformation
        {
            get { return _partnersInformation; }
        }

        public HomePageViewModel(IGetPartnersInformationService getPartnersInformationService, IMessageService messageService, INavigationService navigationService)
        {
            _getPartnersInformationService = getPartnersInformationService;
            _messageService = messageService;
            _navigationService = navigationService;
        }

        public async void LoadPartnersInformation()
        {
            IEnumerable<Partner> partnersInformation = null;
            try
            {
                partnersInformation = await _getPartnersInformationService.GetPartnersInformation();
            }
            catch (Exception)
            {
                //TODO Implement Retry strategy
                _messageService.ShowMessage(AppResources.CannotLoadPartnersInformation, AppResources.ErrorTitle);
                return;
            }
            foreach (var partner in partnersInformation)
            {
                _partnersInformation.Add(Mapper.Map<Partner, PartnerModel>(partner));
            }
        }
    }
}
