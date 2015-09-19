using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Models;
using WindowsPhoneClient.UI.Resources;
using WindowsPhoneClient.UI.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class HomePageViewModel : BindingBase
    {
        private readonly IGetPartnersInformationService _getPartnersInformationService;
        private readonly IMessageService                _messageService;

        private readonly ObservableCollection<PartnerModel> _partnersInformation = new ObservableCollection<PartnerModel>();
        public ObservableCollection<PartnerModel> PartnersInformation
        {
            get { return _partnersInformation; }
        }

        public HomePageViewModel(IGetPartnersInformationService getPartnersInformationService, IMessageService messageService)
        {
            _getPartnersInformationService = getPartnersInformationService;
            _messageService = messageService;
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
