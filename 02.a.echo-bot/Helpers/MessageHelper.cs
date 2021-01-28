using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoBot.Helpers;

namespace EchoBot
{
    public static class MessageHelper
    {
        public static Dictionary<string, string> MessageOptions = new Dictionary<string, string>()
        {
            { "help", "Welcome to Pro Bot 2.0 \n\nPossible Options:\n\nTime - current time\n\nBitcoin - current Bitcoin price\n\nJoke - Joke of the day\n\nAdvice - The best possible advice that you can get" },
            { "time", "Current time is {0}" },
            { "bitcoin", "Current BTC price is:\n\n{0} {1}\n\n{2} {3}\n\n{4} {5}" },
            { "btc", "Current BTC price is:\n\n{0} {1}\n\n{2} {3}\n\n{4} {5}" },
            { "joke", "{0}\n\n{1}" },
            { "advice", "" }
        };

        public static async Task<string> GetMessageResponse(string message)
        {
            var responseMessage = string.Empty;

                var selectedOption = string.Empty;

                foreach (var option in MessageOptions)
                {
                    if (message.ToLower().Contains(option.Key))
                    {
                        selectedOption = option.Key;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(selectedOption))
                {

                    switch (selectedOption.ToLower())
                    {
                        case "time":
                            responseMessage = string.Format(MessageOptions[selectedOption], DateTime.Now);
                            break;
                        case "btc":
                        case "bitcoin":
                            var bitcoinResponse = await BitcoinClient.GetBitcoinPrice();
                            responseMessage = string.Format(MessageOptions[selectedOption],
                                bitcoinResponse.bpi.EUR.rate_float.ToString("0.00"), bitcoinResponse.bpi.EUR.code,
                                bitcoinResponse.bpi.GBP.rate_float.ToString("0.00"), bitcoinResponse.bpi.GBP.code,
                                bitcoinResponse.bpi.USD.rate_float.ToString("0.00"), bitcoinResponse.bpi.USD.code);
                            break;
                        case "joke":
                            var jokeResponse = await JokeClient.GetRandomJoke();
                            responseMessage = string.Format(MessageOptions[selectedOption], jokeResponse.setup,
                                jokeResponse.punchline);
                            break;
                        case "advice":
                            var adviceResponse = await AdviceClient.GetRandomAdvice();
                            responseMessage = adviceResponse.slip.advice;
                            break;
                        default:
                            responseMessage = MessageOptions[selectedOption];
                            break;
                    }
                    return responseMessage;
                }

            return "Option doesn't exist. Write 'help' to see all the options'";
        }
    }
}
