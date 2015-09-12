using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.UI.Infrastrucure;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class HomePageViewModel : BindingBase
    {
        private readonly IGetPartnersInformationService _getPartnersInformationService;

        public HomePageViewModel(IGetPartnersInformationService getPartnersInformationService)
        {
            _getPartnersInformationService = getPartnersInformationService;
        }

        public void GetPartnersInformation()
        {
            _getPartnersInformationService.GetPartnersInformation();
        }
    }
}
