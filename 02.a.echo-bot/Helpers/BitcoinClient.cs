using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EchoBot.Models;
using Newtonsoft.Json;

namespace EchoBot
{
    public static class BitcoinClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<BitcoinResponse> GetBitcoinPrice()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BitcoinResponse>(responseBody);

            return result;
        }

    }
}
