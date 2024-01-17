using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;
using System.Reflection;
using _26_dars_Telegram_Bot;

internal class Program
{
    static async Task Main(string[] args)
    {
            const string link = ("6424290141:AAHKDe8W2k8byII-RWy8n-TwvJId6zmGtEo");

            system_bot system_Bot = new system_bot(link);

            await system_Bot.BotHandle();

            try
            {
                await system_Bot.BotHandle();

            }
            catch (Exception ex)
            {
                throw new Exception("Xatoku!");
            }
        }
}
