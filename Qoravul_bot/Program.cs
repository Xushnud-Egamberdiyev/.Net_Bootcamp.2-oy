using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;

internal class Program
{
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
                Console.WriteLine($"Error chiqadi: {ex.Message}");
            }

        }


        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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

    private static async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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
        if (update.CallbackQuery.Data == "1")
        {
            await botClient.SendTextMessageAsync(
             chatId: update.CallbackQuery.From.Id,
             text: Create,
             cancellationToken: cancellationToken);

        }
        if (update.CallbackQuery.Data == "2")
        {
            await botClient.SendTextMessageAsync(
             chatId: update.CallbackQuery.From.Id,
             text: " Rasim Yoki Video  link  Audio ",
             cancellationToken: cancellationToken);
        }
        if (update.CallbackQuery.Data == "4")
        {
            await botClient.SendTextMessageAsync(
            chatId: update.CallbackQuery.From.Id,
            text: " writing new channel",
            cancellationToken: cancellationToken);
        }

    }

    private static Task HandleEditMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;
        if (message == null)
        {
            await Console.Out.WriteLineAsync();
        }
        var handlar = message.Type switch
        {
            MessageType.Text => HandlaTextMessageAsync(botClient, update, cancellationToken),
            MessageType.Video => HandleVideoMessageAync(botClient, update, cancellationToken),
            MessageType.Photo => HandlePhotoMessageAync(botClient, update, cancellationToken),
            MessageType.Voice => HandleAudioMessageAsync(botClient, update, cancellationToken),
            _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
        };
    }

    private static async Task HandlePhotoMessageAync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Create = update.Message.Text;
        await botClient.SendPhotoAsync(
        chatId: urlbase,
        photo: InputFile.FromUri(""),
        cancellationToken: cancellationToken);

        var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
        await botClient.SendTextMessageAsync(
            chatId: update.Message.From.Id,
            replyMarkup: new InlineKeyboardMarkup(button),
            text: "              Tanglang",
            cancellationToken: cancellationToken);
    }

    public static string urlbase;
    public static string url_link;
    public static string Create;

    private static Task HandlaUnkowMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleAudioMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Create = update.Message.Text;
        await botClient.SendVoiceAsync(
        chatId: urlbase,
        voice: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"),
        cancellationToken: cancellationToken);

        var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
        await botClient.SendTextMessageAsync(
            chatId: update.Message.From.Id,
            replyMarkup: new InlineKeyboardMarkup(button),
            text: "              Tanglang",
            cancellationToken: cancellationToken);

    }

    private static async Task HandleVideoMessageAync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Create = update.Message.Text;
        await botClient.SendVideoAsync(
        chatId: urlbase,
        video: InputFile.FromUri("https://www.youtube.com/watch?v=22ZfB_2_4cc"),
         thumbnail: InputFile.FromUri("https://www.youtube.com/watch?v=22ZfB_2_4cc"),
         supportsStreaming: true,
        cancellationToken: cancellationToken);

        var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
        await botClient.SendTextMessageAsync(
            chatId: update.Message.From.Id,
            replyMarkup: new InlineKeyboardMarkup(button),
            text: "              Tanglang",
            cancellationToken: cancellationToken);
    }
    private static async Task HandlaTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {

        Create = update.Message.Text;
        string url = "@";
        var botton = new KeyboardButton("CreatePost");
        if (update.Message.Text == "/start")
        {
            await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Assalomu Aleykum",
            replyMarkup: new ReplyKeyboardMarkup(botton),
            cancellationToken: cancellationToken
            );
        }
        if (update.Message.Text == "CreatePost")
        {
            await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Chanel Name Kiriting",
            cancellationToken: cancellationToken
            );
        }
        if (update.Message.Text.Length > 18 && update.Message.Text.Length < 30)
        {
            for (int i = 13; i < update.Message.Text.Length; i++)
            {
                url += update.Message.Text[i];
            }
            urlbase = url;

            await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Postni  Kiritin",
            cancellationToken: cancellationToken
            );
            await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Rasim Yoki Video , link, Audio ",
            cancellationToken: cancellationToken
            );
        }
        if (update.Message.Text.Length > 18 && update.Message.Text.Length < 60)
        {
            url_link = update.Message.Text;
            await botClient.SendTextMessageAsync(
            chatId: url,
            text: url_link,
            replyMarkup: new ReplyKeyboardMarkup(botton),
            cancellationToken: cancellationToken);

            var button = new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData("Po'stni ko'rish","1"),
                InlineKeyboardButton.WithCallbackData("Postni joylash", "2"),
                InlineKeyboardButton.WithCallbackData("Postni edit qilish", "3"),
            };
            await botClient.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                replyMarkup: new InlineKeyboardMarkup(button),
                text: "              Tanglang",
                cancellationToken: cancellationToken);
        }

    }
}