using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Runtime.Intrinsics.Arm;

namespace Qoravul_bot2
{
    public class System_bot
    {

        public static string? PostText;
        public static string? ChannelName;
        public static string? Photo;
        public static string? Link;

        public static bool IsPostText = false;
        public static bool IsChannelName = false;
        public static bool IsPhoto = false;
        public static bool IsLink = false;

        public string Token { get; set; }
        public System_bot(string token)
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

        private Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            var handlar = update.Type switch
            {
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
                
                MessageType.Text => HandlaTextMessageAsync(botClient, update, cancellationToken),
                MessageType.Video => HandleVideoMessageAync(botClient, update, cancellationToken),
                MessageType.Voice => HandleAudioMessageAsync(botClient, update, cancellationToken),
                _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
            };
        }

       
        private object HandleAudioMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private object HandleVideoMessageAync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandlaTextMessageAsync(ITelegramBotClient? botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message.Text;
            if (IsPostText)
            {
                PostText = message;
                IsPostText = false;
                await botClient.SendTextMessageAsync
                (
                   chatId: update.Message.Chat.Id,
                   replyToMessageId: update.Message.MessageId,
                   text: "Bajaril!",
                   cancellationToken: cancellationToken
                );
                await ButtonController.CreateSend(botClient, update, cancellationToken);
            }
            else if (IsChannelName)
            {
                ChannelName = message;
                IsChannelName = false;
                await botClient.SendTextMessageAsync
                (
                   chatId: update.Message.Chat.Id,
                   replyToMessageId: update.Message.MessageId,
                   text: "Bajarildi",
                   cancellationToken: cancellationToken
                );
                await ButtonController.CreatePhoto(botClient, update, cancellationToken);
            }
            else if (IsPhoto)
            {
                Photo = update.Message.Photo.Last().FileId;
                IsPhoto = false;
                await botClient.SendTextMessageAsync
                (
                   chatId: update.Message.Chat.Id,
                   replyToMessageId: update.Message.MessageId,
                   text: "Done",
                   cancellationToken: cancellationToken
                );
                await ButtonController.CreateText(botClient, update, cancellationToken);

            }


            var botton = new KeyboardButton("CreatePost");
            if (message == "/start")
            {
                await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Assalomu Aleykum",
            replyMarkup: new ReplyKeyboardMarkup(botton),
            cancellationToken: cancellationToken
            );
            }
            else if (message == "CreatePost")
            {
                await ButtonController.CreateButton(botClient, update, cancellationToken);
            }
            else if (message == "Channel username" || message == "Edit username name")
            {
                IsChannelName = true;

                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Kanal nomini kiriting!",
                cancellationToken: cancellationToken);
            }
            else if (message == "Post text" || message == "Edit post text")
            {
                IsPostText = true;
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Post kiriting!",
                cancellationToken: cancellationToken);
            }
            else if (message == "Send channel")
            {
                if (Photo != null && ChannelName != null && PostText != null)
                {
                    await botClient.SendPhotoAsync(
                        chatId: $"{ChannelName}",
                        photo: InputFile.FromFileId(Photo),
                        caption: $"{PostText}\nKanalga o'ting: @{ChannelName}\n{Link}",
                        cancellationToken: cancellationToken);
                }
            }
            else if (message == "Image update" || message == "Edit image")
            {
                IsPhoto = true;
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Rasm jo'nating!",
                cancellationToken: cancellationToken);
            }




        }





















        
    }
}

