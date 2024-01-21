using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace _28_dars_Insta_VideoSaver_subscriber
{
    public class Button
    {
        public static InlineKeyboardMarkup inlineKeyboard = new(new[]
       {
            //First row. You can also add multiple rows.
            new []
            {
                InlineKeyboardButton.WithUrl(text: "Kanal 1", url: "https://t.me/code_en"),
                InlineKeyboardButton.WithUrl(text: "Kanal 2", url: "https://t.me/N11_Telegram")
            },
        });
    }
}
