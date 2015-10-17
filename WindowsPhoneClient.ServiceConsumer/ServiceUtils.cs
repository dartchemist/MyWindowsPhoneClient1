using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.ServiceConsumer
{
    public static class ServiceUtils
    {
        public static void AddAuthenticationHeader(HttpClient client)
        {
            var authenticationByteArray = Encoding.UTF8.GetBytes("slav:slav32slav");
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationByteArray));
            client.DefaultRequestHeaders.Authorization = header;
        }
    }
}
