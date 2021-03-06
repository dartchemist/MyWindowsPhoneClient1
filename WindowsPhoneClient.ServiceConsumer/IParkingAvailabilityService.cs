﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;

namespace WindowsPhoneClient.ServiceConsumer
{
    public interface IParkingAvailabilityService
    {
        Task<IEnumerable<NearestPartnerInformation>> GetParkingAvailability(double latitude, double longitude);
        Task ReportParkingAvailability(double latitude, double longitude);
    }
}
