using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.ServiceConsumer
{
    public class GetParkingAvailabilityService : IGetParkingAvailabilityService
    {
        public async void GetParkingAvailabilityAroundMe(double latitude, double longitude)
        {
            var uri = WindowsPhoneClient.CommonConstants.ServiceAddresses.GetAvailabilityAndDisplayPartnersAroundMe;
            
            using (var httpClient = new HttpClient())
            {
                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("lat", latitude.ToString()),
                    new KeyValuePair<string, string>("lng", longitude.ToString())
                });

                var response = await httpClient.PostAsync(uri, requestData);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var jsonContent = await response.Content.ReadAsStringAsync();
                
            }
        }
    }
}
