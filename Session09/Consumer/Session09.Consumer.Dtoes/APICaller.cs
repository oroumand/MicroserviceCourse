using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Session09.Consumer.Dtoes
{
    public static class APICaller
    {
        static public async Task<HttpResponseMessage> Call(string url,string id)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(url) })
            {
                try
                {
                    var response = await client.GetAsync($"/api/person/?id={id}");
                    return response;
                }
                catch (System.Exception ex)
                {
                    throw new Exception("There was a problem connecting to Provider API.", ex);
                }
            }
        }
    }
}
