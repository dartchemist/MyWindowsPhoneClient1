using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.CommonConstants
{
    public static class ServiceAddresses
    {
        private const string DomainUrl = "http://www.test.sinilink.com";
        public const string DomainMediaUrl = DomainUrl + "/media";
        public const string GetPartnersInformationUrl = DomainUrl + "/getPartnersInformation";
        public const string GetAvailabilityAndDisplayPartnersAroundMe = DomainUrl + "/getAvailabilityAndDisplayPartners/";
        public const string ReportParkingAvailability = DomainUrl + "/reportParkingAvailability";
    }
}
