using SomeLibrary.Targeted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"I'm uisng SomeLibrary that targets {TargetSpecificCode.Target}");
        }
    }
}
