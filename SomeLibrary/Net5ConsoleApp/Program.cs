using SomeLibrary.Targeted;
using System;

namespace Net5ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"I'm uisng SomeLibrary that targets {TargetSpecificCode.Target}");
        }
    }
}
