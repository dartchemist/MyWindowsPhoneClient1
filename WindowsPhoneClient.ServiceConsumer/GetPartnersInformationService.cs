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

namespace WindowsPhoneClient.ServiceConsumer
{
    public class GetPartnersInformationService : IGetPartnersInformationService
    {   
        public async Task<IEnumerable<Partner>> GetPartnersInformation()
        {
            var partnersInformation = new List<Partner>();
            using (var httpClient = new HttpClient())
            {
                var partnersJsonInfo = await httpClient.GetStringAsync(ServiceAddresses.GetPartnersInformationUrl);
                var partnersJsonArray = JArray.Parse(partnersJsonInfo);
                foreach (var partner in partnersJsonArray)
                {
                    var modelPartner = CreatePartnerFromJsonString(partner);
                    if (modelPartner == null)
                        continue;
                    
                    partnersInformation.Add(modelPartner);
                }
            }
            return partnersInformation;
        }

        private Partner CreatePartnerFromJsonString(JToken item)
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
            partner.Logo = DownloadLogoImage(ServiceAddresses.DomainMediaUrl + "/" + partner.LogoRelativePath).Result;
            partner.MarkerImage = (string)item["fields"]["marker_image"];
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

        private async Task<byte[]> DownloadLogoImage(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var logoBytes = await httpClient.GetByteArrayAsync(imageUrl);
                return logoBytes;
            }
        }
    }
}
