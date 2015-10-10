using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.ServiceConsumer
{
    public interface IGetParkingAvailabilityService
    {
        void GetParkingAvailabilityAroundMe(double latitude, double longitude);
    }
}
