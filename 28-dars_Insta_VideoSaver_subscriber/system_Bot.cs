using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace _28_dars_Insta_VideoSaver_subscriber
{
    public class system_Bot
    {
        public string Token { get; set; }
        public system_Bot(string token)
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

        private Task HandleCallBackQueryAsymc(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {

            var botClientDev = new TelegramBotClient("6812304166:AAHJNYERlObqJa9AwISbcS4tTCfDuCS6vcY");

            //block 
            int blockLevel = 0;
            bool messDeleted = false;
            string[] badWords = new string[] { "bad word", "badword" };
            string[] veryBadWords = new string[] { "very bad word", "verybadword" };

            //Time
            int year;
            int month;
            int day;
            int hour;
            int minute;
            int second;

            //Messages and user info
            long chatId = 0;
            string messageText;
            int messageId;
            string firstName;
            string lastName;
            long id;
            Message sentMessage;

            //poll info
            int pollId = 0;

            //----------------------//

            //Read time and save variables
            year = int.Parse(DateTime.UtcNow.Year.ToString());
            month = int.Parse(DateTime.UtcNow.Month.ToString());
            day = int.Parse(DateTime.UtcNow.Day.ToString());
            hour = int.Parse(DateTime.UtcNow.Hour.ToString());
            minute = int.Parse(DateTime.UtcNow.Minute.ToString());
            second = int.Parse(DateTime.UtcNow.Second.ToString());
            Console.WriteLine("Data: " + year + "/" + month + "/" + day);
            Console.WriteLine("Time: " + hour + ":" + minute + ":" + second);

            //cts token
            using var cts = new CancellationTokenSource();

            // Bot StartReceiving, does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            botClientDev.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClientDev.GetMeAsync();

            //write on console a hello message by bot 
            Console.WriteLine($"\nHello! I'm {me.Username} and i'm your Bot!");

            // Send cancellation request to stop bot and close console
            Console.ReadKey();
            cts.Cancel();

            //----------------------//




            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
            return;
        // Only process text messages
        if (update.Message!.Type != MessageType.Text)
            return;

        //set variables
        chatId = update.Message.Chat.Id;
        messageText = update.Message.Text;
        messageId = update.Message.MessageId;
        firstName = update.Message.From.FirstName;
        lastName = update.Message.From.LastName;
        id = update.Message.From.Id;
        year = update.Message.Date.Year;
        month = update.Message.Date.Month;
        day = update.Message.Date.Day;
        hour = update.Message.Date.Hour;
        minute = update.Message.Date.Minute;
        second = update.Message.Date.Second;

        //when receive a message show data and time on console.
        Console.WriteLine("\nData message --> " + year + "/" + month + "/" + day + " - " + hour + ":" + minute + ":" + second);
        //show the message, the chat id and the user info on console.
        Console.WriteLine($"Received a '{messageText}' message in chat {chatId} from user:\n" + firstName + " - " + lastName + " - " + " 5873853");

        //set text all lowercase
        messageText = messageText.ToLower();

        if (messageText != null && int.Parse(day.ToString()) >= day && int.Parse(hour.ToString()) >= hour && int.Parse(minute.ToString()) >= minute && int.Parse(second.ToString()) >= second - 10)
        {



            if (messageText == "/start")
            {

                var getchatmember = await botClient.GetChatMemberAsync(/*ID or NAME of the chat*/"New_post_kanal_1",/*user id*/ id);
                var getchatmember2 = await botClient.GetChatMemberAsync(/*ID or NAME of the chat*/"@n11chan",/*user id*/ id);

                if (getchatmember.ToString() != "Member")
                {
                    await UserIsSubscriber(botClient, id, cancellationToken);

                }
                else if (getchatmember2.ToString() == "Member")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Thank You for subscription", //The message to display
                        cancellationToken: cancellationToken);
                }


            }

        }


        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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


    }


    async Task UserIsSubscriber(ITelegramBotClient botClient, long id, CancellationToken cancellationToken)
    {

        // create the "buttons" with the URL of the channel to join.
        InlineKeyboardMarkup inlineKeyboard = new(new[]
              {
                    //First row. You can also add multiple rows.
                    new []
                    {
                        InlineKeyboardButton.WithUrl(text: "Canale 1", url: "https://t.me/new_post_kanal_1"),
                        InlineKeyboardButton.WithUrl(text: "Canale 2", url: "https://t.me/n11chan"),
                    },
                });

        Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: id,
        text: "Before use the bot you must follow this channels.\nWhen you are ready, click -> /home <- to continue", //The message to display
        replyMarkup: inlineKeyboard,
        cancellationToken: cancellationToken);

    }

            string replaxemessage = update.Message.Text.Replace("www.", "dd");

            if (update.Message.Text.StartsWith("https://www.instagram.com"))
            {

                Message sentMessage = await botClient.SendVideoAsync(
                    chatId: update.Message.Chat.Id,
                    video: $"{replaxemessage}", 
                    supportsStreaming: true,
                    cancellationToken: cancellationToken

                    );
                Message sentMessage2 = await botClient.SendPhotoAsync( 
                    chatId: update.Message.Chat.Id,
                    photo: $"{replaxemessage}",
                    cancellationToken: cancellationToken

                    );
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

       
    }
}
