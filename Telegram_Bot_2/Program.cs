using Telegram.Bot;

namespace Telegram_Bot_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            const string link =  ("6915580106:AAEordPFcwCJB6tjo5SAPTJjo_cN_ZWUJfk");

            System_bot system_Bot = new System_bot(link);

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
}
