namespace Warnsdorff
{
    internal static class IO
    {
        internal static string? Get(string Description)
        {
            Console.Write($"{Description} ");
            var tmp = Console.ReadLine();
            return tmp;
        }
        internal static void Send(string Value)
        {
            Console.Write(Value);
        }
        internal static void SendLine(string Value)
        {
            Console.WriteLine(Value);
        }
        internal static ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }
    }
}
