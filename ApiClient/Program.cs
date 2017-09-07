using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    
    class Program
    {
        static HttpClient client = new HttpClient();
        
        static async Task<Article> GetArticleAsync(string path)
        {
            Article article = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                article = await response.Content.ReadAsAsync<Article>();
            }
            return article;
        }
        static void Main()
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            

            Article article = await GetArticleAsync("api/articles/");
            
        }
    }
}