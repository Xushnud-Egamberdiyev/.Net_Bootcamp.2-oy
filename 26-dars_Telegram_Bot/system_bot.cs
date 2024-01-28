using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using System.Reflection;

namespace _26_dars_Telegram_Bot
{
    public class system_bot
    {
        public string Token { get; set; }
        public system_bot(string token)
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
                UpdateType.CallbackQuery => CallbackQueryMessage(botClient, update, cancellationToken),
                UpdateType.Message => HandlaMessageAsync(botClient, update, cancellationToken),
                UpdateType.EditedMessage => HandleVideoMessageAync2(botClient, update, cancellationToken),
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

        async Task CallbackQueryMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery.Data == "3")
            {
                await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text: "Postni edit qilish",
                    cancellationToken: cancellationToken);

                var button2 = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Channel Update","4"),
                InlineKeyboardButton.WithCallbackData("Post text update", "5"),
                InlineKeyboardButton.WithCallbackData("Image update", "6"),
                InlineKeyboardButton.WithCallbackData("Orqaga qaytish", "7"),
            };
                 await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    replyMarkup: new InlineKeyboardMarkup(button2),
                    text: "tanlang",
                    cancellationToken: cancellationToken);
            }

            if (update.CallbackQuery.Data == "7")
            {
                await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text: "Orqaga qaytish",
                    cancellationToken: cancellationToken);

                var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
                await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    replyMarkup: new InlineKeyboardMarkup(button),
                    text: "              Tanglang",
                    cancellationToken: cancellationToken);

            }
        }

        private Task HandlaUnkowMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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
                MessageType.Sticker => HandLeSticerMessageAsync(botClient, update, cancellationToken),
                MessageType.Text => HandlaTextMessageAsync(botClient, update, cancellationToken),
                MessageType.Video => HandleVideoMessageAync(botClient, update, cancellationToken),
                MessageType.Voice => HandleAudioMessageAsync(botClient, update, cancellationToken),
                _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
            };
        }

        async Task HandleAudioMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            


        }

        async  Task HandleVideoMessageAync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandLeSticerMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandlaTextMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message.Text == "/start")
            {
                
            }
            
            
           

            var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
            await botClient.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                replyMarkup: new InlineKeyboardMarkup(button),
                text :                            "              Tanglang",
                cancellationToken: cancellationToken);

            
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
