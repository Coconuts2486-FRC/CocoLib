using CocoLib.Networking;
using CocoLib.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log data = new Log("C:\\Users\\Zach\\Desktop\\DataLog.txt");
            Console.WriteLine("Type a message...");
            string input = Console.ReadLine();
            data.AddToLog(input);
        }
    }
}
