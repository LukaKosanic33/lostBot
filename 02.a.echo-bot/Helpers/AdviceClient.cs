using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EchoBot.Models;
using Newtonsoft.Json;

namespace EchoBot
{
    public static class AdviceClient
    {
        static readonly HttpClient client = new HttpClient();
        
        public static async Task<AdviceResponse> GetRandomAdvice()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.adviceslip.com/advice");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AdviceResponse>(responseBody);

            return result;
        }

    }
}
