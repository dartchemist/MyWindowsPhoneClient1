using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using WindowsPhoneClient.UI.Models;

namespace WindowsPhoneClient.UI.Infrastrucure.AutoMapper
{
    public static class AutoMapperConfigurator
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Partner, PartnerModel>();
        }
    }
}
