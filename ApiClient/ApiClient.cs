using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    class ApiClient : HttpClient
    {
        public static HttpClient client = new HttpClient();
        public void Client()
        {
            var byteArray = Encoding.ASCII.GetBytes("demo:RCiG7xCeTwHm0IFnNDXtwi2OFZPR5tMmv2PqJi9q");
            client.BaseAddress = new Uri("http://shop.localtest.me/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}
