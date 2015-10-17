using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;

namespace WindowsPhoneClient.ServiceConsumer
{
    public interface IGetPartnersInformationService
    {
        Task<IEnumerable<Partner>> GetPartnersInformation();
        int GetTimerDuration();
    }
}
