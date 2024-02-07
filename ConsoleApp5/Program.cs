namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = from obj in list
                        where obj > 4
                        select obj;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
