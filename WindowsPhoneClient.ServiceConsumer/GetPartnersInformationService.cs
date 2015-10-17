using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using WindowsPhoneClient.CommonConstants;
using System.Net.Http.Headers;

namespace WindowsPhoneClient.ServiceConsumer
{
    public class GetPartnersInformationService : IGetPartnersInformationService
    {
        private string _partnersInfo;
        
        public async Task<IEnumerable<Partner>> GetPartnersInformation()
        {
            var partnersInformation = new List<Partner>();
            using (var httpClient = new HttpClient())
            {
                #if DEBUG   
                ServiceUtils.AddAuthenticationHeader(httpClient);
                #endif

                var partnersJsonInfo = await httpClient.GetStringAsync(ServiceAddresses.GetPartnersInformationUrl);
                _partnersInfo = partnersJsonInfo;
                var partnersJsonArray = JArray.Parse(partnersJsonInfo);
                foreach (var partner in partnersJsonArray)
                {
                    var modelPartner = await CreatePartnerFromJsonString(partner);
                    if (modelPartner == null)
                        continue;
                    
                    partnersInformation.Add(modelPartner);
                }
            }
            return partnersInformation;
        }

        public int GetTimerDuration()
        {
            var partnersJsonArray = JArray.Parse(_partnersInfo);
            foreach (var partner in partnersJsonArray)
            {
                if ((string)partner["model"] == "mobile_api.applicationparameters")
                {
                    return (int)partner["fields"]["value"];
                }
            }
            return 0;
        }

        private async Task<Partner> CreatePartnerFromJsonString(JToken item)
        {
            if ((string)item["model"] == "mobile_api.applicationparameters")
                return null;
            
            var partner = new Partner();
            partner.PrimaryKey = (int)item["pk"];
            partner.Model = (string)item["model"];
            partner.Name = (string)item["fields"]["name"];
            partner.BranchKey = (int)item["fields"]["branch_key"];
            partner.VideoUrl = (string)item["fields"]["video"];
            partner.LogoRelativePath = (string)item["fields"]["logo"];
            partner.Logo = await DownloadImage(ServiceAddresses.DomainMediaUrl + "/" + partner.LogoRelativePath);
            partner.MarkerImageRelativePath = (string)item["fields"]["marker_image"];
            partner.MarkerImage = await DownloadImage(ServiceAddresses.DomainMediaUrl + "/" + partner.MarkerImageRelativePath);
            var thumbnails = new[]
                {
                    (string)item["fields"]["thumbnail_first"],
                    (string)item["fields"]["thumbnail_second"],
                    (string)item["fields"]["thumbnail_third"]
                };
            partner.Thumbnails = thumbnails;
            var advertismentImages = new[]
                {
                    (string)item["fields"]["advertisment_first"],
                    (string)item["fields"]["advertisment_second"],
                    (string)item["fields"]["advertisment_third"]
                };
            partner.AdvertismentImages = advertismentImages;
            return partner;
        }

        private async Task<byte[]> DownloadImage(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                #if DEBUG
                ServiceUtils.AddAuthenticationHeader(httpClient);
                #endif
                return await httpClient.GetByteArrayAsync(imageUrl);
            }
        }
    }
}
