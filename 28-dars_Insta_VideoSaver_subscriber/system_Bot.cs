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
            Token = token;
        }
        public async Task Run()
        {
            var botClient = new TelegramBotClient($"{Token}");

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

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //return;
            try
            {
                if (update.Message is not { } message) return;
                if (message.Chat is not { } chat) return;

                // Foydalanuvchining chat id'sini olish
                long userId = chat.Id;

                Console.WriteLine($"{userId} => {chat.Username} => {chat.Username}");

                // Kanalning username'sini o'zgartiring
                string channelUsername2 = "New_post_kanal_1";

                // Foydalanuvchini tekshirish
                var chatMember2 = await botClient.GetChatMemberAsync(channelUsername2, userId);
                Console.WriteLine(chatMember2.ToString());

                // Agar foydalanuvchi kanalda obuna bo'lsa
                if (chatMember2.Status == ChatMemberStatus.Member)
                {
                    Console.WriteLine($"User -> {message.Chat.FirstName} Chat Id -> {message.Chat.Id}\nMessage ->{message.Text}\n\n");

                    Controller controller = new Controller();
                    var handler = update.Type switch
                    {
                        UpdateType.Message => controller.HandleMessageAsync(botClient, update, cancellationToken),
                        //UpdateType.D=> messageController.EssentialAsyncMessage(botClient, update, cancellationToken),
                        _ => controller.OtherMessage(botClient, update, cancellationToken),
                    };
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                        chatId: userId,
                        text: "Siz kanalga obuna bo'lmagansiz. Iltimos, avval kanalga obuna bo'ling.",
                        replyMarkup: Button.inlineKeyboard,
                        cancellationToken: cancellationToken
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public async Task<Task> HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            await Console.Out.WriteLineAsync(ErrorMessage);
            return Task.CompletedTask;
        }

    }
}
