using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using WindowsPhoneClient.UI.Models;
using SinilinkControls;

namespace WindowsPhoneClient.UI.Infrastrucure.AutoMapper
{
    public static class AutoMapperConfigurator
    {
        private class NearestPartnerInformationTypeConverter : ITypeConverter<NearestPartnerInformation, NearestPartnerInformationModel>
        {
            public NearestPartnerInformationModel Convert(ResolutionContext context)
            {
                var sourceValue = context.SourceValue as NearestPartnerInformation;
                return new NearestPartnerInformationModel(sourceValue.BranchKey, new CoordinateModel(sourceValue.Latitude, sourceValue.Longitude));
            }
        }
        
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Partner, PartnerModel>();
            Mapper.CreateMap<NearestPartnerInformation, NearestPartnerInformationModel>()
                .ConvertUsing(new NearestPartnerInformationTypeConverter());
        }
    }
}
