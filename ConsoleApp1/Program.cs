using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;
using System.IO.Compression;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

internal class Program
{
    public static List<long> list = new List<long>() { };
    static async Task Main(string[] args)
    {

        var botClient = new TelegramBotClient("6424290141:AAHKDe8W2k8byII-RWy8n-TwvJId6zmGtEo");

        using CancellationTokenSource cts = new();

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

        cts.Cancel();

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var Handlar = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                UpdateType.EditedMessage => HandleEditMessageAsync(botClient, update, cancellationToken),
                UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update, cancellationToken),
                _ => HandleMessageAsync(botClient, update, cancellationToken)
            };
            try
            {
                await Handlar;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error chiqadi: {ex}");
            }
        }
    }
    private static Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    async static Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message.Text == "/start")
        {
            if (list.Count == 0)
            {
                list.Add(update.Message.Chat.Id);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (update.Message.Chat.Id != list[i])
                    {
                        list.Add(update.Message.Chat.Id);
                    }
                }
            }

            await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Assalomu Aleykum",
            cancellationToken: cancellationToken
            );

            Random random = new Random();

            var Random = random.Next(100, 10000);

            string zipPath = @$"C:\Users\hp\Desktop\c#\C#_.Net_Bootcamp.{random}.zip";
            string startPath = @$"C:\Users\hp\Desktop\c#\C#_.Net_Bootcamp_2-oy\FolderTop";
            ZipFile.CreateFromDirectory(startPath, zipPath);
            await using Stream stream = System.IO.File.OpenRead(zipPath);
            for (int i = 0; i < list.Count; i++)
            {
                await botClient.SendDocumentAsync(
                chatId: list[i],
                document: InputFile.FromStream(stream: stream, fileName: "Zip"),
                cancellationToken: cancellationToken
                );
            }
        }
    }

    private static Task HandleCallbackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    private static Task HandleEditMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
