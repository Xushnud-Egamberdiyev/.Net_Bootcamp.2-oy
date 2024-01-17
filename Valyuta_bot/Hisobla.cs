using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Valyuta_bot
{
    public class Hisobla
    {


        public string Name { get; set; }
   

        public Hisobla(string name)
        {
            Name = name;
           
        }


        

        public async Task ShowName(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/uz/exchange-rates/json/");

            var response = httpClient.SendAsync(request).Result;

            var boby = response.Content.ReadAsStringAsync().Result;

            var courses = JsonSerializer.Deserialize<List<Model>>(boby);

            var isEnter = true;
            foreach (var item in courses)
            {
                if (item.code == Name)
                {
                    isEnter = false;
                    Message sentMessage5 = await botClient.SendTextMessageAsync(
                        chatId: update.CallbackQuery.From.Id,
                        text: item.cb_price,
                        cancellationToken: cancellationToken);
                }  



                
                
            }
                    if (isEnter)
            {

                Message sentMessage5 = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "eroor",
                    cancellationToken: cancellationToken); 
            }
        }
    }
}
