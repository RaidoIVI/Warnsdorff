using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
