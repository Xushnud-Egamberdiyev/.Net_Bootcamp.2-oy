using _28_dars_Insta_VideoSaver_subscriber;

internal class Program
{
    static async Task Main(string[] args)
    {

        const string link = ("6915580106:AAEordPFcwCJB6tjo5SAPTJjo_cN_ZWUJfk");

        system_Bot system_Bot = new system_Bot(link);

       

        try
        {
           system_Bot.Run().Wait();

        }
        catch (Exception ex)
        {
            throw new Exception("Xatoku!");
        }

    }
}