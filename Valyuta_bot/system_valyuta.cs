using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Valyuta_bot
{
    public class System_valyuta
    {
        public string Token { get; set; }
        public System_valyuta(string token)
        {
            this.Token = token;
        }

        public async Task BotHandle()
        {
            var botClient = new TelegramBotClient($"{this.Token}");

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            

            var handlar = update.Type switch
            {
                UpdateType.Message => HandlaMessageAsync(botClient, update, cancellationToken),
                UpdateType.EditedMessage => HandleVideoMessageAync2(botClient, update, cancellationToken),
                UpdateType.CallbackQuery => HandleCallBackQueryAsymc(botClient, update, cancellationToken),
                _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
            };

            
            try
            {
                await handlar;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Chiqdi! {ex.Message}");
            }

        }



        public async Task HandleCallBackQueryAsymc(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
           


            var buttons_Valyuta = new List<List<InlineKeyboardButton>>()
            {
                new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("1","USD"),
                    InlineKeyboardButton.WithCallbackData("2","ISK"),
                    InlineKeyboardButton.WithCallbackData("3","JPY"),
                    InlineKeyboardButton.WithCallbackData("4","KRW"),

                },
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData("5","KWD"),
                    InlineKeyboardButton.WithCallbackData("6","KZT"),
                    InlineKeyboardButton.WithCallbackData("7","LBP"),
                    InlineKeyboardButton.WithCallbackData("8","MYR"),

                },
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData("9","NOK"),
                    InlineKeyboardButton.WithCallbackData("10","PLN"),
                    InlineKeyboardButton.WithCallbackData("11","RUB"),
                    InlineKeyboardButton.WithCallbackData("12","SEK"),

                },
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData("13","SGD"),
                    InlineKeyboardButton.WithCallbackData("14","TRY"),
                    InlineKeyboardButton.WithCallbackData("15","UAH"),
                    InlineKeyboardButton.WithCallbackData("16","GBP"),

                },
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData("17","AED"),
                    InlineKeyboardButton.WithCallbackData("18","AUD"),
                    InlineKeyboardButton.WithCallbackData("19","CAD"),
                    InlineKeyboardButton.WithCallbackData("20","CHF"),

                },
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData("21","CNY"),
                    InlineKeyboardButton.WithCallbackData("22","DKK"),
                    InlineKeyboardButton.WithCallbackData("23","EGP"),
                    InlineKeyboardButton.WithCallbackData("24","EUR"),

                },

            };
            if (update.CallbackQuery.Data == "Yes")
            {
                Message sentMessage4 = await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text: "1—-> USD : Title ->AQSh dollari\r\n" +
                    "-----------------------------------------\n" +
                    "2—-_> ISK : Title ->Islandiya kronasi\r\n" +
                    "-------------------------------------------\n"+
                    "3—->  JPY : Title ->Yaponiya iyenasi\r\n" +
                    "-------------------------------------------\n" +
                    "4—->  KRW : Title ->Koreya respublikasi voni\r\n" +
                    "-------------------------------------------\n" +
                    "5—->  KWD : Title ->Quvayt dinori\r\n" +
                    "-------------------------------------------\n" +
                    "6—->  KZT : Title ->Qozog'iston tengesi\r\n" +
                    "-------------------------------------------\n" +
                    "7—->  LBP : Title ->Livan funti\r\n" +
                    "-------------------------------------------\n" +
                    "8—->  MYR : Title ->Malayziya ringgiti\r\n" +
                    "-------------------------------------------\n" +
                    "9—->  NOK : Title ->Norvegiya kronasi\r\n" +
                    "-------------------------------------------\n" +
                    "10—-> PLN : Title ->Polsha zlotiysi\r\n" +
                    "-------------------------------------------\n" +
                    "11—-> RUB : Title ->Rossiya rubli\r\n" +
                    "-------------------------------------------\n" +
                    "12—-> SEK : Title ->Shvetsiya kronasi\r\n" +
                    "-------------------------------------------\n" +
                    "13—-> SGD : Title ->Singapur dollari\r\n" +
                    "-------------------------------------------\n" +
                    "14—-> TRY : Title ->Turkiya lirasi\r\n" +
                    "-------------------------------------------\n" +
                    "15—-> UAH : Title ->Ukraina grivnasi\r\n" +
                    "-------------------------------------------\n" +
                    "16--> GBP : Title ->Angliya funt sterlingi\r\n" +
                    "-------------------------------------------\n" +
                    "17-—> AED : Title ->BAA dirhami\r\n" +
                    "-------------------------------------------\n" +
                    "18—-> AUD : Title ->Avstraliya dollari\r\n" +
                    "-------------------------------------------\n" +
                    "19—-> CAD : Title ->Kanada dollari\r\n" +
                    "-------------------------------------------\n" +
                    "20—-> CHF : Title ->Shveytsariya franki\r\n" +
                    "-------------------------------------------\n" +
                    "21—-> CNY : Title ->Xitoy yuani\r\n" +
                    "-------------------------------------------\n" +
                    "22—-> DKK : Title ->Daniya kronasi\r\n" +
                    "-------------------------------------------\n" +
                    "23—-> EGP : Title ->Misr funti\r\n" +
                    "-------------------------------------------\n" +
                    "24—-> EUR : Title ->Evro\r\n"+
                    "-------------------------------------------\n" ,


                   replyMarkup: new InlineKeyboardMarkup(buttons_Valyuta),

                    cancellationToken: cancellationToken);;
           
                
            }
            else
            {
                Message sentMessage4 = await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                   text: update.CallbackQuery.Data,
                    cancellationToken: cancellationToken);
                string name = update.CallbackQuery?.Data;







                Hisobla hisobla = new Hisobla(update.CallbackQuery.Data);

                hisobla.ShowName(botClient, update, cancellationToken);




            }



        }

        private Task HandleVideoMessageAync2(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandlaMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            var handlar = message.Type switch
            {   
                
                MessageType.Text => HandlaTextMessageAsync(botClient, update, cancellationToken),
                _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
            };
        }
 

        private Task HandlaUnkowMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        async Task HandlaTextMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            

            Console.WriteLine($"Received a '{update.Message.Text}' message in chat ,{update.Message.Chat.LastName} {update.Message.Chat.FirstName} ");

            var button = InlineKeyboardButton.WithCallbackData(text: "Boshlash", callbackData: "Yes");

            if (update.Message.Text == "/start")
            {

                Message sentMessage4 = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Ishni boshlash uchun bosing! \n",
                    replyMarkup: new InlineKeyboardMarkup(button),

                    cancellationToken: cancellationToken);

            if (update.Message.Text == "1")
                {
                    Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Yesssssssssssss! \n",
                    replyMarkup: new InlineKeyboardMarkup(button),

                    cancellationToken: cancellationToken);
                }

            }

        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        internal Task HandleCallBackQueryAsymc(List<Model>? courses)
        {
            throw new NotImplementedException();
        }
    }
}
