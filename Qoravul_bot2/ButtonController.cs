using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Qoravul_bot2
{
    public class ButtonController
    {
        public static async Task CreateButton(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Channel username"),
                    new KeyboardButton("Post text "),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Image update"),
                   
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yes",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
            
        }
        public static async Task CreatePhoto(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    
                    new KeyboardButton("Post text "),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton(" Photo"),

                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yes",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);

        }
        public static async Task CreateText(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {

                    new KeyboardButton("Post text "),
                },
                new KeyboardButton[]
                {
                   

                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yes",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);

        }
        public static async Task CreateSend(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yes",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);

        }
    }
}
