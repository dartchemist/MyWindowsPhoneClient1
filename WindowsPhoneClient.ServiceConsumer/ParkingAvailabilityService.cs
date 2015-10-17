using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;

namespace WindowsPhoneClient.ServiceConsumer
{
    public class ParkingAvailabilityService : IParkingAvailabilityService
    {
        public async Task<IEnumerable<NearestPartnerInformation>> GetParkingAvailability(double latitude, double longitude)
        {
            var uri = WindowsPhoneClient.CommonConstants.ServiceAddresses.GetAvailabilityAndDisplayPartnersAroundMe;
            
            using (var httpClient = new HttpClient())
            {
#if DEBUG
                ServiceUtils.AddAuthenticationHeader(httpClient);
#endif
                
                var latitudeString = latitude.ToString(CultureInfo.InvariantCulture);
                var longitudeString = longitude.ToString(CultureInfo.InvariantCulture);
                
                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("lat", latitudeString),
                    new KeyValuePair<string, string>("lng", longitudeString)
                });

                var response = await httpClient.PostAsync(uri, requestData);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var jsonContent = await response.Content.ReadAsStringAsync();

                return ParseResponse(jsonContent);
            }
        }

        public async Task ReportParkingAvailability(double latitude, double longitude)
        {

        }

        private IEnumerable<NearestPartnerInformation> ParseResponse(string jsonResponse)
        {
            var result = new List<NearestPartnerInformation>();
            var responseArray = JArray.Parse(jsonResponse);

            foreach (var responseEntry in responseArray)
            {
                var nearestPartner = new NearestPartnerInformation();
                nearestPartner.BranchKey = (int)responseEntry["fields"]["branch_key"];
                nearestPartner.Latitude = (double)responseEntry["fields"]["lat"];
                nearestPartner.Longitude = (double)responseEntry["fields"]["lng"];
                result.Add(nearestPartner);
            }

            return result;
        }
    }
}
