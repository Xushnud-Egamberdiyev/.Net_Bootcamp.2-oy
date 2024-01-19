using Qoravul_bot2;

internal class Program
{
    static async Task Main(string[] args)
    {

        const string link = ("6424290141:AAHKDe8W2k8byII-RWy8n-TwvJId6zmGtEo");

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