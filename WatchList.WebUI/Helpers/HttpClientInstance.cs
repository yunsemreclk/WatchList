using System.Net.Http.Headers;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {

            HttpClient client = new();

            client.BaseAddress = new Uri("https://localhost:7111/api/");

            return client;
        }      
                
    }

}
