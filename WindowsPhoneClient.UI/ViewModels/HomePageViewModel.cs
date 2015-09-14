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

namespace WindowsPhoneClient.UI.ViewModels
{
    public class HomePageViewModel : BindingBase
    {
        private readonly IGetPartnersInformationService _getPartnersInformationService;

        private readonly ObservableCollection<PartnerModel> _partnersInformation = new ObservableCollection<PartnerModel>();
        public ObservableCollection<PartnerModel> PartnersInformation
        {
            get { return _partnersInformation; }
        }

        public HomePageViewModel(IGetPartnersInformationService getPartnersInformationService)
        {
            _getPartnersInformationService = getPartnersInformationService;
        }

        public async void LoadPartnersInformation()
        {
            var partnersInformation = await _getPartnersInformationService.GetPartnersInformation();
            foreach (var partner in partnersInformation)
            {
                _partnersInformation.Add(Mapper.Map<Partner, PartnerModel>(partner));
            }
        }
    }
}
