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
            string replaxemessage = update.Message.Text.Replace("www.", "dd");

            if (update.Message.Text.StartsWith("https://www.instagram.com"))
            {

                Message sentMessage = await botClient.SendVideoAsync(
                    chatId: update.Message.Chat.Id,
                    video: $"{replaxemessage}",
                    supportsStreaming: true,
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
