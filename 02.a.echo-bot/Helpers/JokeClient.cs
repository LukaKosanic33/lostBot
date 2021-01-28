using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EchoBot.Models;
using Newtonsoft.Json;

namespace EchoBot.Helpers
{
    public static class JokeClient
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<JokeResponse> GetRandomJoke()
        {
            HttpResponseMessage response = await client.GetAsync("https://official-joke-api.appspot.com/jokes/ten");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<JokeResponse>>(responseBody);

            return result.First();
        }
    }
}
