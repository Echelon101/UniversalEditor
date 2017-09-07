using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using Lenz.ShopwareApi;
using Lenz.ShopwareApi.Models.Articles;

namespace API_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string user = "demo";
            const string pass = "RCiG7xCeTwHm0IFnNDXtwi2OFZPR5tMmv2PqJi9q";

            // http://restsharp.org/
            var client =
                new RestClient(@"http://shop.localtest.me/api")
                {
                   Authenticator = new HttpBasicAuthenticator(user, pass)
                };

            var request = new RestRequest("articles/{id}", Method.GET);
            request.AddUrlSegment("id", 3.ToString(CultureInfo.InvariantCulture)); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            var response = client.Execute(request);

            if (response.ErrorException != null)
            {
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.ErrorException.Message);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.ResponseStatus);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.ErrorException.StackTrace);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.ErrorException.Source);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.Headers);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(@"################ ERROR ################");
                Console.WriteLine(response.StatusDescription);
            }
            else
            {
                var content = response.Content; // raw content as string

                dynamic json = JsonConvert.DeserializeObject(content);
                Console.WriteLine(json);
            }
            Console.ReadKey();
        }
        public class DigestAuthenticator :
        IAuthenticator
        {
            private readonly string _user;
            private readonly string _pass;

            public DigestAuthenticator(string user, string pass)
            {
                _user = user;
                _pass = pass;
            }

            public void Authenticate(IRestClient client, IRestRequest request)
            {
                request.Credentials = new NetworkCredential(_user, _pass);
            }
            
        }
        
    }
}
